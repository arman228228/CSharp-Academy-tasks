using System.Net;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter radius:");

        double radius = double.Parse(Console.ReadLine());

        double area = 0;
        CircleCalculations.GetArea(ref area, radius);

        double perimeter;
        CircleCalculations.GetPerimeter(out perimeter, radius);

        Console.WriteLine("Area: " + area + ". Perimeter: " + perimeter);
    }
}

class CircleCalculations
{
    static public void GetArea(ref double area, double radius)
    {
        area = radius * radius;
    }
    static public void GetPerimeter(out double perimeter, double radius) 
    {
        perimeter = radius * 2;
    }
}
