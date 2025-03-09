namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine($"Multiplication table for {n}:");
        
        for(int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{n} * {i} = {n * i}");
        }
    }
}
