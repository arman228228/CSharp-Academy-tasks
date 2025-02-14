using System.Runtime.Intrinsics.X86;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter string:");

        string str = Console.ReadLine();

        Console.WriteLine("Enter specific char:");

        char c = char.Parse(Console.ReadLine());

        Console.WriteLine(
            str[0] == c ? "Char in the start" : 
            str[^1] == c ? "Char in the end" :
            "Error"
        );
    }
}