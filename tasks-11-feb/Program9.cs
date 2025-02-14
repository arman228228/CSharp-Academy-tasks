using System.Runtime.Intrinsics.X86;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = { { 2, 3, 4 }, { 3, 5, 9 }, { 4, 1, 8 } };

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Console.WriteLine($"Matrix[{i}][{j}]: {matrix[i, j]}");
            }
        }
    }
}