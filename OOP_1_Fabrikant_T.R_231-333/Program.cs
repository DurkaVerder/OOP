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
            CheckDataEmployee checkerDataEmployee = new CheckDataEmployee();

            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string job_title = Console.ReadLine();

            if (!checkerDataEmployee.CheckData(firstName, lastName, job_title))
            {
                Console.WriteLine("Invalid data for employee");
                return;
            }

            Employee emp = new Employee(firstName, lastName, job_title);
            emp.AboutEmployee();
        }
    }

    class CheckDataEmployee
    {
        public bool CheckData(string firstName, string lastName, string job_title)
        {
            if (CheckName(firstName) && CheckName(lastName) && CheckJob(job_title)) {
                return true;
            }
            return false;
        }

        private bool CheckName(string name) 
        {   
            if ( name.Length == 0 )
            {
                return false;
            }
            if (name[0] < 65 || name[0] > 90)
            {
                return false;
            }
            for (int i = 1; i <name.Length; i++)
            {
                if (name[i] > 122 || name[i] < 97)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckJob(string job)
        {
            if (job.Length == 0)
            {
                return false;
            }
            for (int i = 0; i <job.Length; i++)
            {
                if (job[i] > 122 || job[i] < 97)
                {
                    if (job[i] < 65 || job[i] > 90)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    class Employee {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Job_title { get; set; }

        public Employee(string firstName, string lastName, string job_title) { 
            FirstName = firstName;
            LastName = lastName;
            Job_title = job_title;
        }

        public void AboutEmployee()
        {
            Console.WriteLine("First name: " +  FirstName + "\nLastName: " +  LastName + "\nJob_title: " + Job_title);
        }

    }

}


