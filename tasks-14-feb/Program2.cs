namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()), res = 0;

        while(n > 0)
        {
            res = res * 10 + n % 10;
            n /= 10;
        }

        Console.WriteLine(res);
    }
}
