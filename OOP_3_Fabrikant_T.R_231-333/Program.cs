using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DataAccess
{

    public class Student
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private double _averageGrade;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым");
                _firstName = value;
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой");
                _lastName = value;
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Возраст должен быть от 0 до 150");
                _age = value;
            }
        }

        public double AverageGrade
        {
            get => _averageGrade;
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("Средний балл должен быть от 0 до 10");
                _averageGrade = value;
            }
        }

        public Student(string firstName, string lastName, int age, double averageGrade)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            AverageGrade = averageGrade;
        }
    }


    public class University
    {
        private readonly List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Студент не может быть null");
            _students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Студент не может быть null");
            _students.Remove(student);
        }

        public Student FindStudentByName(string firstName, string lastName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students.AsReadOnly();
        }
    }

    public class StudentsRepository
    {
        private readonly string _filePath;

        public StudentsRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            var json = JsonSerializer.Serialize(students);
            File.WriteAllText(_filePath, json);
        }

        public IEnumerable<Student> LoadStudents()
        {
            if (!File.Exists(_filePath))
                return Enumerable.Empty<Student>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<IEnumerable<Student>>(json);
        }
    }
}

class Program
{
    static void Main()
    {
        var university = new DataAccess.University();
        var repository = new DataAccess.StudentsRepository("students.json");


        var student1 = new DataAccess.Student("Иван", "Иванов", 20, 8.5);
        var student2 = new DataAccess.Student("Петр", "Петров", 22, 7.0);

        university.AddStudent(student1);
        university.AddStudent(student2);

        
        repository.SaveStudents(university.GetAllStudents());

    
        var loadedStudents = repository.LoadStudents();
        foreach (var student in loadedStudents)
        {
            Console.WriteLine($"Имя: {student.FirstName}, Фамилия: {student.LastName}, Возраст: {student.Age}, Средний балл: {student.AverageGrade}");
        }
    }
}
