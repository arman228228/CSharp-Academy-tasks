namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int fibonacc_n_1 = 0, fibonacc_n_2 = 1;

        Console.Write($"\nFibonacci numbers:\n{fibonacc_n_1}");

        for (int i = 1, next; i < n; i++) 
        {
            Console.Write(" " + fibonacc_n_2);

            next = fibonacc_n_1 + fibonacc_n_2;
            
            fibonacc_n_1 = fibonacc_n_2;
            fibonacc_n_2 = next;
        }
    }
}
