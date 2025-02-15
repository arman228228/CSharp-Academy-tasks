namespace ConsoleApp2;

class Program
{
    static int Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()),
            iterCount = 0;

        while(n != 1)
        {
            if(n % 2 == 0)
            {
                n /= 2;
            }
            else
            {
                n = (3 * n) + 1;
            }

            iterCount++;
        }

        Console.WriteLine("Iterations count: " + iterCount);
        return 0;
    }
}
