using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Student[] Students = new Student[]
            {
                new Student("Bob", 12, 80),
                new Student("Alex", 13, 76),
                new Student("Anna", 14, 90),
                new Student("Alice", 11, 90)
            };
            
            Teacher[] Teachers = new Teacher[]
            {
                new Teacher("Mr. Bob", "Math", 5),
                new Teacher("Mr. David", "Science", 2),
                new Teacher("Ms. Anna", "English", 7),
                new Teacher("Ms. Alice", "Sport", 0)
            };

            School school = new School(Students, Teachers);

            school.StudentsWithHighestGrade();

            Console.WriteLine("");
            
            school.TeachersWithLessThanTwoYearsExperience();
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public Student(string name, int age, int grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
    }

    class Teacher
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public int YearsOfExperience { get; set; }

        public Teacher(string name, string subject, int yearsOfExperience)
        {
            Name = name;
            Subject = subject;
            YearsOfExperience = yearsOfExperience;
        }
    }

    class School
    {
        public Student[] Students { get; set; }
        public Teacher[] Teachers { get; set; }

        public School(Student[] students, Teacher[] teachers)
        {
            Students = students;
            Teachers = teachers;
        }

        public void StudentsWithHighestGrade()
        {
            int highestGrade = Students[0].Grade;

            foreach (Student student in Students)
            {
                if (student.Grade > highestGrade)
                    highestGrade = student.Grade;
            }

            Console.WriteLine($"Highest value between students: {highestGrade}");
            
            foreach (Student student in Students)
            {
                if (student.Grade >= highestGrade)
                    Console.WriteLine($"Student: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

        public void TeachersWithLessThanTwoYearsExperience()
        {
            Console.WriteLine("Teachers with less than 2 years experience:");
            
            foreach (Teacher teacher in Teachers)
            {
                if (teacher.YearsOfExperience < 3)
                {
                    Console.WriteLine(
                        $"Teacher: {teacher.Name}, Subject: {teacher.Subject}, Years of experience: {teacher.YearsOfExperience}");
                }
            }
        }
    }
}