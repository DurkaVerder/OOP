using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private int age;
    private double avarageRating;

    public string FirstName
    {
        get => firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Имя не может быть пустым");
            firstName = value;
        }
    }

    public string LastName
    {
        get => lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Фамилия не может быть пустой");
            lastName = value;
        }
    }

    public int Age
    {
        get => age;
        set
        {
            if (value < 0)
                throw new ArgumentException("Возраст не может быть отрицательным");
            age = value;
        }
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

    public Student(string firstName, string lastName, int age, double avarageRating)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        AvarageRating = avarageRating;
    }
}

public class University
{
    private List<Student> students = new List<Student>();


    public void AddStudent(Student student)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student), "Студент не может быть null");
        students.Add(student);
    }

 
    public void RemoveStudent(string firstName, string lastName)
    {
        Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        if (student != null)
            students.Remove(student);
    }

    public Student FindStudent(string firstName, string lastName)
    {
        Student student = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        return student;
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}

public class StudentsRepository
{
    private readonly string filePath;

    public StudentsRepository(string filePath)
    {
        this.filePath = filePath;
    }

    public void SaveStudents(List<Student> students)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Student student in students)
            {
                writer.WriteLine($"{student.FirstName},{student.LastName},{student.Age},{student.AvarageRating}");
            }
        }
    }

    public List<Student> LoadStudents()
    {
        List<Student> students = new List<Student>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                if (data.Length == 5)
                {
                    Student student = new Student(data[0], data[1], int.Parse(data[2]), double.Parse(data[3] + "," + data[4]));
                    students.Add(student);
                }
            }
        }
        return students;
    }
}

class Program
{
    static void Main()
    {
        University university = new University();

        Student student1 = new Student("Иван", "Иванов", 20, 4.5);
        Student student2 = new Student("Петр", "Петров", 22, 3.7);

        university.AddStudent(student1);
        university.AddStudent(student2);

        StudentsRepository repository = new StudentsRepository("C:\\Users\\vrrrr\\source\\repos\\OOP\\OOP_3_Fabrikant_T.R_231-333\\student.txt");
        repository.SaveStudents(university.GetAllStudents());

        List<Student> loadedStudents = repository.LoadStudents();

        foreach (var student in loadedStudents)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}, возраст: {student.Age}, средний балл: {student.AvarageRating}");
        }

        
    }
}
