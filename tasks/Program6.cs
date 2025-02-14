using System.Runtime.Intrinsics.X86;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        double height;

        Console.WriteLine("Enter height:");

        height = double.Parse(Console.ReadLine());

        double weight;

        Console.WriteLine("Enter weight:");

        weight = double.Parse(Console.ReadLine());

        double BMI = weight / (height * height);

        Console.WriteLine($"BMI: {BMI}. " +
            (
                BMI < 18.5 ? "Underweight" : 
                BMI <= 24.9 ? "Normal weight" : 
                BMI <= 29.9 ? "Overweight" :
                "Obese"
            )
        );
    }
}
