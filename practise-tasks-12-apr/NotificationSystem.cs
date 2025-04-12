namespace NotificationSystem;

class Program
{
    static void Main(string[] args)
    {
        Notifier.Delegate? op = null;

        string? input = Console.ReadLine();

        if(int.TryParse(input, out int option)) 
        {
            switch(option)
            {
                case 0:
                    op = Notifier.ConsolePrint;
                    break;
                case 1:
                    op = Notifier.FileLoggerPrint;
                    break;
                case 2:
                    op = Notifier.EmailPrint;
                    break;
                default:
                    return;
            }
        }

        op?.Invoke("text");
    }
}

class Notifier
{
    public delegate void Delegate(string mes);

    public static void ConsolePrint(string mes)
    {
        Console.WriteLine("[Console]: " + mes);
    }

    public static void FileLoggerPrint(string mes)
    {
        Console.WriteLine("[File logger]: " + mes);
    }

    public static void EmailPrint(string mes)
    {
        Console.WriteLine("[Email]: " + mes);
    }
}