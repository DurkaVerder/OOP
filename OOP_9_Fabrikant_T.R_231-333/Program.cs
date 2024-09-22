using System;

namespace OOP9
{
    class Program
    {
        static void Main(string[] args) 
        {
            INotificationContainer<Notification> notificationContainer;

            NotificationContainer<EmailNotification> emailContainer = new NotificationContainer<EmailNotification>();
            NotificationContainer<SMSNotification> smsContainer = new NotificationContainer<SMSNotification>();
            NotificationContainer<SMSNotification> smsContainerEmpty = new NotificationContainer<SMSNotification>();

            emailContainer.Add(new EmailNotification("Привет!", DateTime.Now.AddHours(-1), "timur@gmail.com"));
            emailContainer.Add(new EmailNotification("Да!", DateTime.Now.AddHours(-2), "timur@gmail.com"));
            emailContainer.Add(new EmailNotification("Ок", DateTime.Now.AddHours(0), "timur@gmail.com"));

            smsContainer.Add(new SMSNotification("Пока", DateTime.Now.AddHours(-1), "89608370193"));
            smsContainer.Add(new SMSNotification("Давай", DateTime.Now.AddHours(-2), "89608312093"));
            smsContainer.Add(new SMSNotification("Хороший", DateTime.Now.AddHours(0), "89608312043"));

            notificationContainer = emailContainer;

            Console.WriteLine("Работа ковариантности");
            foreach (var notification in notificationContainer.Get()) 
            {
                notification.Info();
            }
            Console.WriteLine();

            Console.WriteLine($"Наличие уведомлений на электронной почте: {emailContainer.Has()}");
            Console.WriteLine($"Наличие SMS уведомлений: {smsContainer.Has()}");
            Console.WriteLine($"Наличие SMS уведомлений 2: {smsContainerEmpty.Has()}\n");


            emailContainer.Sort();
            smsContainer.Sort();

            emailContainer.PrintAll();
            smsContainer.PrintAll();

            
            
            
        }
    }

    public interface INotificationContainer<out T> where T : Notification
    {
        IEnumerable<T> Get();
    }


    public class NotificationContainer<T> : INotificationContainer<T> where T : Notification, IComparable<T> 
    {
        private List<T> notifications = new List<T>();

    
        public void Add(T notification)
        {
            notifications.Add(notification);
        }

       
        public IEnumerable<T> Get()
        {
            return notifications;
        }

        public void PrintAll()
        {
            for (int i = 0; i < notifications.Count; i++)
            {
                notifications[i].Info();
            }
            Console.WriteLine();
        }

        public bool Has()
        {
            return notifications.Count > 0;
        }

        
        public void Sort()
        {
            notifications.Sort();
        }
    }


    public abstract class Notification : IComparable<Notification>
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public Notification(string message, DateTime date)
        {
            Message = message;
            Date = date;
        }

       
        public int CompareTo(Notification other)
        {
            return Date.CompareTo(other.Date);
        }

        public abstract void Info();
    }

   
    public class EmailNotification : Notification
    {
        public string EmailAddress { get; set; }

        public EmailNotification(string message, DateTime date, string emailAddress)
            : base(message, date)
        {
            EmailAddress = emailAddress;
        }

        public override void Info()
        {
            Console.WriteLine($"Отправитель {EmailAddress}: {Message} (Дата: {Date})");
        }
    }

 
    public class SMSNotification : Notification
    {
        public string PhoneNumber { get; set; }

        public SMSNotification(string message, DateTime date, string phoneNumber)
            : base(message, date)
        {
            PhoneNumber = phoneNumber;
        }

        public override void Info()
        {
            Console.WriteLine($"Отправитель {PhoneNumber}: {Message} (Дата: {Date})");
        }
    }


}
