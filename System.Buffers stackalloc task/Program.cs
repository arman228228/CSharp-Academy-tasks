namespace ConsoleApp9;

class Program
{
    unsafe static void Main()
    {
        int* arr = stackalloc int[10];
        
        for (int i = 0; i < 10; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        int index = 0, max = arr[0];
        
        for (int i = 0; i < 10; i++)
        {
            if (max < arr[i])
            {
                index = i;
                max = arr[i];
            }
        }
        
        Console.WriteLine($"Max: {max}, Index: {index}");
    }
}