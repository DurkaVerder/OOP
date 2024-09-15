using System;


namespace OOP1
{
    class Programm
    {

        static void Main(string[] args)
        {
            Solution();
        }

        static void Solution()
        {
            Person person = new Person("Timur", 19, "vrrrr227@gmail.com");
            person.GetInfo();
        }
    }

    class Person
    {
        public string name = "Ben";
        public int age = 18;
        public string email = "ben@gmail.com";
        public Person(string name)
        {
            this.name = name;
        }
        public Person(string name, int age) : this(name)
        {
            this.age = age;
        }
        public Person(string name, int age, string email) :
        this("Bob", age)
        {
            this.email = email;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Name: {name}\nAge: {age}\nEmail: {email}");
        }
    }
}