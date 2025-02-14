using System.Runtime.Intrinsics.X86;

namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        int[][] arr = new int[3][];
        arr[0] = new int[] { 2, 3, 4 };
        arr[1] = new int[] { 3, 5 };
        arr[2] = new int[] { 4, 1, 8 };

        for(int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\nRow {i}:\n");

            for(int j = 0; j < arr[i].Length; j++)
            {
                Console.WriteLine($"arr[{i}][{j}]: {arr[i][j]}");
            }
        }
    }
}