using System.Drawing;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        InkReservoir a = new InkReservoir("red", 5);
        InkReservoir b = new InkReservoir("red", 2);

        // a = a + b;
        Console.WriteLine(a.Equals(b) ? "true" : "false");

        // Console.WriteLine("-------");

        // InkReservoir c = new InkReservoir("red", 3);
        // c = a + a;
        // Console.WriteLine(c);
    }
}

class InkReservoir
{
    string Color;
    double InkAmount;

    public InkReservoir(string color, double inkAmount)
    {
        Color = color;
        InkAmount = inkAmount;
    }

    public static InkReservoir operator +(InkReservoir a, InkReservoir b)
    {
        if(a.Color != b.Color)
        {
            Console.WriteLine("Incompatible colors");
            return a;
        }

        return new InkReservoir(a.Color, a.InkAmount + b.InkAmount);
    }

    public static InkReservoir operator -(InkReservoir reservoir, double amount)
    {
        double result = reservoir.InkAmount - amount;

        if(result < 0)
        {
            Console.WriteLine("Not enough ink");
            return reservoir;
        }

        return new InkReservoir(reservoir.Color, result);
    }

    public override string ToString()
    {
        return $"Color: {Color}, Amount: {InkAmount}";
    }

    public override bool Equals(object? obj)
    {
        return obj is InkReservoir reservoir ? Color == reservoir.Color : false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Color, InkAmount);
    }
}
