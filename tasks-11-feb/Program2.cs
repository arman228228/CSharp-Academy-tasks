namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number:");

        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(n % 400 == 0 ? "Leap year." : n % 4 == 0 && n % 100 != 0 ? "Leap year" : "Not leap year.");
    }
}
