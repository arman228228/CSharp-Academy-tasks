using System.Net;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter numbers:");

        int[] numbers = new int[5];

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"Enter {i} index number:");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Sum: " + CalculateSum.GetSum(numbers));
    }
}

class CalculateSum
{
    static public int GetSum(params int[] numbers)
    {
        int sum = 0;

        foreach (int i in numbers)
        {
            sum += i;
        }

        return sum;
    }
}
