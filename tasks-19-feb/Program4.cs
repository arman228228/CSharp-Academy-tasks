namespace ConsoleApp4;

class Program
{
    static void Main()
    {
        WeatherReport[] weatherReport =
        {
            new WeatherReport(10.8f, 70, "Rain"),
            new WeatherReport(5.4f, 60, "Cloudly"),
            new WeatherReport(14.2f, 53, "Sunny")
        };

        string[] cities = { "New York", "Los Angeles", "Detroit" };

        for (int i = 0; i < weatherReport.Length; i++)
        {
            Console.WriteLine($"\nCity: {cities[i]}");
            weatherReport[i].ShowReport();
        }
    }
}

class WeatherReport
{
    private float _temperature;
    private int _humidity;
    private string _weatherCondition;
    
    public WeatherReport(float temperature, int humidity, string weatherCondition)
    {
        _temperature = temperature;
        _humidity = humidity;
        _weatherCondition = weatherCondition;
    }

    public void ShowReport()
    {
        Console.WriteLine($"Temperature: {_temperature}, humidity: {_humidity}, weather condition: {_weatherCondition}");
    }
}