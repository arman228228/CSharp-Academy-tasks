using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            const int totalStudent = 5;

            Student[] student = new Student[]
            {
                new Student { Name = "Student 1", Age = 19, Grade = 8 },
                new Student { Name = "Student 2", Age = 20, Grade = 4 },
                new Student { Name = "Student 3", Age = 18, Grade = 3 },
                new Student { Name = "Student 4", Age = 22, Grade = 9 },
                new Student { Name = "Student 5", Age = 21, Grade = 10 }
            };

            for (int i = 0; i < totalStudent; i++)
            {
                student[i].DisplayDetails();
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"Student details:\nName: {Name}\nAge: {Age}\nGrade: {Grade}");
        }
    }
}