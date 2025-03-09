namespace ConsoleApp2;

class Program
{
    static int Main(string[] args)
    {
        string? input = Console.ReadLine();

        if(input != null)
        {
            switch(input)
            {
                case "a":
                {
                    Console.WriteLine("\nNew password:");
                    
                    const int passwordLength = 8;

                    Random randGenerator = new Random();
                    
                    for(int i = 0; i < passwordLength; i++)
                    {
                        switch(randGenerator.Next(0, 3))
                        {
                            case 0:
                            {
                                Console.Write((char)randGenerator.Next(48, 58));
                                break;
                            }
                            case 1:
                            {
                                Console.Write((char)randGenerator.Next(65, 91));
                                break;
                            }
                            case 2:
                            {
                                Console.Write((char)randGenerator.Next(97, 123));
                                break;
                            }
                        }
                    }
                    break;
                }
                case "x":
                {
                    Console.WriteLine("x");
                    break;
                }
            }
        }
        return 0;
    }
}
