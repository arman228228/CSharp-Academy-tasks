namespace ConsoleApp2;

class Program
{
    static int Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        
        for(int i = 2; i < n; i++)
        {
            if(n % i == 0)
            {
                Console.WriteLine("Not prime number.");
                return 0;
            }
        }

        Console.WriteLine("Prime number.");
        return 0;
    }
}
