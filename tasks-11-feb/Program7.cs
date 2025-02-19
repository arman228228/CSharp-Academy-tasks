using System.Runtime.Intrinsics.X86;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number:");

        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter bit pos:");

        int k = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter operation (0 - set. 1 - clear):");

        int operation = int.Parse(Console.ReadLine());

        if(operation == 0) n |= 1 << k;
        else n &= ~(1 << k);

        Console.WriteLine($"Result: {n}");
    }
}