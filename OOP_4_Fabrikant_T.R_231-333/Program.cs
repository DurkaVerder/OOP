using System;

namespace OOP4 {

    class Program
    {
        static void Main()
        {
            Person person = new Person
            {
                Name = "Timur",
                Address = "Moscow",
                Age = 19
            };

            Console.WriteLine(person.GetInfo());
            Console.WriteLine(person.GetInfo(false));
        }
    }

    class Person
    {

        public string Name { get; set; }


        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("Возвраст не может быть отрицательным");
                }
            }
        }


        public bool IsYoung => Age < 25;


        public string GetInfo()
        {
            return $"Name: {Name}, Address: {Address}, Age: {Age}, IsYoung: {IsYoung}";
        }


        public string GetInfo(bool includeIntProperty)
        {
            if (includeIntProperty)
            {
                return GetInfo();
            }
            else
            {
                return $"Name: {Name}, Address: {Address}, IsYoung: {IsYoung}";
            }
        }
    }
}