namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        TimePeriod formattedTime = new TimePeriod();
        formattedTime.SetSeconds(3700);

        Console.WriteLine(formattedTime.FormattedTime);
    }
}

class TimePeriod
{
    int TotalSeconds { get; set; }

    public void SetSeconds(in int seconds)
    {
        TotalSeconds = seconds;
    }

    public string FormattedTime 
    { 
        get
        {
            int hours = TotalSeconds / 3600,
                minutes = (TotalSeconds % 3600) / 60,
                seconds = TotalSeconds % 60
            ;

            return $"{hours.ToString("00")}:{minutes.ToString("00")}:{seconds.ToString("00")}";
        }
    }
}
