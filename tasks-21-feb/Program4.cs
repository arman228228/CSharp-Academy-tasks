using System.Net;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        float temp;

        Console.WriteLine("Enter new temperature:");

        temp = float.Parse(Console.ReadLine());

        Console.WriteLine("Enter operation:\n0 - convert to fahrenheit\n1 - convert to kelvin");

        int operation = int.Parse(Console.ReadLine());

        switch(operation) 
        {
            case 0:
                TemperatureConverter.ToFahrenheit(ref temp);
                Console.WriteLine("Converted fahrenheit temperature: " + temp);
                break;
            case 1:
                TemperatureConverter.ToKelvin(ref temp);
                Console.WriteLine("Converted kelvin temperature: " + temp);
                break;
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }
}

class TemperatureConverter
{
    static public void ToFahrenheit(ref float temperature)
    {
        temperature = (temperature * 9f / 5f) + 32;
    }
    static public void ToKelvin(ref float temperature) 
    {
        temperature = temperature + 273.15f;
    }
}
