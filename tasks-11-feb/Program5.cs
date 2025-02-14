namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        char c;

        Console.WriteLine("Enter char:");

        c = char.Parse(Console.ReadLine());

        Console.WriteLine(
            char.IsUpper(c) ? "UpperCase char" : char.IsLower(c) ? "LowerCase char" : "Neither" 
        );
    }
}
