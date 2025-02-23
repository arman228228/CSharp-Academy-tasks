namespace ConsoleApp5;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter seconds to convert:");
        int totalSeconds = int.Parse(Console.ReadLine()), hours, minutes, seconds;

        TimeConverter.Convert(totalSeconds, out hours, out minutes, out seconds);

        Console.WriteLine($"Hours: {hours}, minutes: {minutes}, seconds: {seconds}");
    }
}

class TimeConverter
{
    public static void GetHours(int totalSeconds, out int hours)
    {
        hours = totalSeconds / 3600;
    }

    public static void GetMinutes(int totalSeconds, int totalHours, out int minutes)
    {
        minutes = (totalSeconds - (totalHours * 3600)) / 60;
    }

    public static void GetSeconds(int totalSeconds, int hours, int minutes, out int seconds)
    {
        seconds = totalSeconds - (hours * 3600) - (minutes * 60);
    }

    public static void Convert(int totalSeconds, out int hours, out int minutes, out int seconds)
    {
        GetHours(totalSeconds, out hours);
        GetMinutes(totalSeconds, hours, out minutes);
        GetSeconds(totalSeconds, hours, minutes, out seconds);
    }
}