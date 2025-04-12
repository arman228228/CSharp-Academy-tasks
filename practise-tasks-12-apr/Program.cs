namespace ConsoleApp2;

public delegate double Operation(double arg1, double arg2);

class Program
{
    static void Main()
    {
        Operation op = null;

        Console.WriteLine("Enter operation:");
        
        switch(Console.ReadLine())
        {
            case "+":
            {
                op = Add;
                break;
            }
            case "-":
            {
                op = Subtract;
                break;
            }
            case "*":
            {
                op = Multiply;
                break;
            }
            case "/":
            {
                op = Divide;
                break;
            }
            default:
            {
                return;
            }
        }

        Console.WriteLine("Enter 2 values:");

        string[]? input = Console.ReadLine().Split(" ");
       
        int[] inputArray = new int[2];
        inputArray[0] = int.Parse(input[0]);
        inputArray[1] = int.Parse(input[1]);

        Console.WriteLine("Result: " + op(inputArray[0], inputArray[1]));
    }

    static double Add(double x, double y)
    {
        return x + y;
    }

    static double Subtract(double x, double y)
    {
        return x - y;
    }

    static double Multiply(double x, double y)
    {
        return x * y;
    }

    static double Divide(double x, double y)
    {
        return x / y;
    }
}
