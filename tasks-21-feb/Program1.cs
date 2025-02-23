namespace ConsoleApp5;

class Program
{
    static void Main()
    {
        Calculator.RecursiveCalculator();
    }
}

static class Calculator
{
    public static void RecursiveCalculator()
    {
        Console.WriteLine("Enter first, second number or X for exit");

        string? input = Console.ReadLine();

        string[] splitString = input.Split(' ');

        if (splitString[0] == "X")
        {
            Console.WriteLine("Exit program");
        }
        else if (splitString.Length < 2)
        {
            Console.WriteLine("Invalid input");
            RecursiveCalculator();
        }
        else
        {
            int firstN = int.Parse(splitString[0]);
            int secondN = int.Parse(splitString[1]);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine($"first number: {firstN}, second number: {secondN}");
                Console.WriteLine("Enter process: +, -, *, / or X to back");

                int result = 0;
                char process = char.Parse(Console.ReadLine());
                bool validProcess = true;

                switch (process)
                {
                    case '+':
                        result = Add(firstN, secondN);
                        break;
                    case '-':
                        result = Subtract(firstN, secondN);
                        break;
                    case '*':
                        result = Multiply(firstN, secondN);
                        break;
                    case '/':
                        result = Divide(firstN, secondN);
                        break;
                    case 'X':
                        RecursiveCalculator();
                        validProcess = false;
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid process");
                        validProcess = false;
                        break;
                }

                if (validProcess)
                {
                    Console.WriteLine("Result: " + result);
                    RecursiveCalculator();
                }
            }
        }
            
    }
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Subtract(int a, int b)
    {
        return a - b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }

    public static int Divide(int a, int b)
    {
        return a / b;
    }
}