namespace ConsoleApp2;

class Program
{
    static int Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()),
            iterCount = 0;

        for(int i = 1; i <= n; i++)
        {
            for(int j = 0; j < i; j++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
        return 0;
    }
}
