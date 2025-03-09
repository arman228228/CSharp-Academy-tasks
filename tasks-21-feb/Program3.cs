namespace ConsoleApp5;

class Program
{
    static void Main()
    {
        const int arrSize = 5;
        int[] arr = new int[arrSize];

        for(int i = 0; i < arrSize; i++)
        {
            Console.WriteLine($"Enter {i} index value:");
            arr[i] = int.Parse(Console.ReadLine());
        }

        int max = 0;
        FindMaxNumber(ref max, arr);
        
        Console.WriteLine("Max number: " + max);
    }

    static void FindMaxNumber(ref int max, params int[] arr)
    {
        max = arr[0];

        foreach (int i in arr)
        {
            if (max < i) max = i;
        }
    }
}