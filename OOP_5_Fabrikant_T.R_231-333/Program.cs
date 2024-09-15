using System;

namespace OOP5
{
    class Programm
    {
        static void Main(string[] args)
        {
            Solution();
        }

        static void Solution()
        {
            University university = new University();

            Humon humon1 = new Humon("Сёмен Скаллета", new DateTime(2005, 12, 20));
            Humon humon2 = new Humon("Илья Новый", new DateTime(2005, 6, 17));

            Student student1 = new Student("Алексей Шаман", new DateTime(2005, 4, 27), 5.0, university);
            Student student2 = new Student("Никита Тру", new DateTime(2005, 6, 1), 5.0, university);

            Console.WriteLine("Все люди: ");
            HumonDataBase.GetAllHumons();
            Console.WriteLine($"Человек с id = 1:");
            HumonDataBase.GetHumonById(1).AboutHumon();

            Console.WriteLine("Все студенты");
            university.GetAllStudents();

            Console.WriteLine($"Студент с номером зачётной книжки = 1:");
            university.GetStudentByRecordBook(1).AboutStudent();
        }
    }

    public class Humon
    {
        private static int count = 0;

        public int Id { get; private set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }


        public Humon(string fullName, DateTime birthDay) {
            FullName = fullName;
            BirthDay = birthDay;
            Id = count++;

            HumonDataBase.AddHumon(this);
        }

        public void AboutHumon()
        {
            Console.WriteLine($"Имя: {FullName}\nДень рождения: {BirthDay}\n");
        }
    }

    public static class HumonDataBase { 
        private static List<Humon> humons = new List<Humon>();

        public static void AddHumon(Humon humon) { 
            humons.Add(humon);
        }

        public static Humon GetHumonById(int id) {
            return humons.Find(h => h.Id == id);
        }

        public static void GetAllHumons()
        {
            for (int i = 0; i < humons.Count; i++)
            {
                Console.WriteLine($"Имя: {humons[i].FullName}\nДень рождения: {humons[i].BirthDay}\nId: {humons[i].Id}\n");
            }
        }
    }

    public class Student : Humon
    {
        
        private double avarageRating;
        private int numberRecordBook;


        public int NumberRecordBook
        {
            get { return numberRecordBook; }
            set { numberRecordBook = value; }
        }

        public double AvarageRating
        {
            get => avarageRating;
            set
            {
                if (value < 0 || value > 5)
                    throw new ArgumentException("Средний балл должен быть между 0 и 5");
                avarageRating = value;
            }
        }

        public Student(string fullName, DateTime birthDay, double avarageRating, University university) : base(fullName, birthDay) 
        { 
            AvarageRating = avarageRating;
            numberRecordBook = university.AssignRecordBook();
            university.AddStudent(this);
        }

        public void AboutStudent()
        {
            Console.WriteLine($"Имя: {FullName}\nДень рождения: {BirthDay}\nСредняя оценка: {AvarageRating}\nНомер зачётной книжки: {NumberRecordBook}\n");
        }
    }
    public class University
    {
        private List<Student> students = new List<Student>();
        private int nubmerRecordBook = 0;

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Студент не может быть null");
            students.Add(student);
        }

        public int AssignRecordBook() { return nubmerRecordBook++; }

        public Student GetStudentByRecordBook(int id) {
            return students.Find(s => s.NumberRecordBook == id);
        }

        public void GetAllStudents()
        {
            for (int i = 0; i < students.Count; i++) {
                students[i].AboutStudent();
            }
        }
    }
}
