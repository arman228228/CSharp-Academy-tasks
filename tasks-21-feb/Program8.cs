using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Fibonacci: " + FibonacciCalculations.GetNumberIndex(n));
    }
}

class FibonacciCalculations
{
    public static int GetNumberIndex(int n) 
    {
        if(n < 2) return n;

        return GetNumberIndex(n - 1) + GetNumberIndex(n - 2);
    }
}