namespace ConsoleApp5;

class Program
{
    static void Main()
    {
        int firstN, secondN;
        
        while (true)
        {
            Console.WriteLine("Enter first number:");

            if (int.TryParse(Console.ReadLine(), out firstN))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        while (true)
        {
            Console.WriteLine("Enter second number:");

            if (int.TryParse(Console.ReadLine(), out secondN))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        SwapValues(ref firstN, ref secondN);
        
        Console.WriteLine("Numbers after swapping: " + firstN + " " + secondN);
    }

    static void SwapValues(ref int firstN, ref int secondN)
    {
        int temp = firstN;
        firstN = secondN;
        secondN = temp;
    }
}