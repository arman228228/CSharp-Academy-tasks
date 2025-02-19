namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number:");

        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(n == 0 ? "Zero number." : n > 0 ? "Positive number." : "Negative number.");
    }
}
