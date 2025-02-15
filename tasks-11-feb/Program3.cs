namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter days:");

        if(int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine($"{n / 7} week and {n % 7} days");
        }
    }
}
