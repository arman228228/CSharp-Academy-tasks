using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a:");
        int a = int.Parse(Console.ReadLine());

        if(a == 0) 
        {
            Console.WriteLine("not valid number.");
        }

        Console.WriteLine("Enter b:");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter c:");
        int c = int.Parse(Console.ReadLine());

        double root1 = 0, root2 = 0;

        if(QuadraticEquationCalculations.GetRoots(a, b, c, ref root1, ref root2) == false) 
        {
            Console.WriteLine("The equation does not have roots");
        }
        else 
        {
            Console.WriteLine("Root 1: " + root1 + ". Root 2: " + root2);
        }
    }
}

class QuadraticEquationCalculations
{
    static public bool GetRoots(int a, int b, int c, ref double root1, ref double root2)
    {
        double discriminant = b * b - 4 * a * c;

        if(discriminant < 0)
        {
            return false;
        }
        else if(discriminant == 0)
        {
            root1 = root2 = -b  / (2 * a);
        }

        root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

        return true;
    }
}
