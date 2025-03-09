using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Employee[] employee = new Employee[3]
            {
                new Employee { Name = "Employee 1", Position = 1, SalaryPerHour = 15, HoursWorked = 32},
                new Employee { Name = "Employee 2", Position = 2, SalaryPerHour = 20, HoursWorked = 45},
                new Employee { Name = "Employee 3", Position = 3, SalaryPerHour = 18, HoursWorked = 42}
            };

            foreach (Employee employeeID in employee)
            {
                Console.WriteLine(
                    $"Employee Name: {employeeID.Name}, " +
                    $"position: {employeeID.Position}, " +
                    $"salary per hour: {employeeID.SalaryPerHour}, " +
                    $"hours worked: {employeeID.HoursWorked}, " +
                    $"total salary: {employeeID.CalculateSalary()}");
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public int SalaryPerHour { get; set; }
        public int HoursWorked { get; set; }

        public double CalculateSalary()
        {
            return HoursWorked >= 40 ? (SalaryPerHour * HoursWorked) * 1.5 
                : SalaryPerHour * HoursWorked;
        }
    }
}