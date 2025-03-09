namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        WaterTank a = new WaterTank(100, 5);
        WaterTank b = new WaterTank(150, 5);

        a = a + b;
        Console.WriteLine(a);
    }
}

class WaterTank
{
    double Capacity;
    double CurrentLevel;

    public WaterTank(double capacity, double currentLevel)
    {
        Capacity = capacity;
        CurrentLevel = currentLevel;
    }

    public static WaterTank operator +(WaterTank first, WaterTank second)
    {
        double newWaterLevel = first.CurrentLevel + second.CurrentLevel;
        if(newWaterLevel > first.Capacity)
        {
            Console.WriteLine($"First water tank limit reached. ({first.Capacity} limit)");
            return null;
        }

        return new WaterTank(first.Capacity, newWaterLevel);
    }

    public static WaterTank operator -(WaterTank tank, double water)
    {
        double newWaterLevel = tank.CurrentLevel - water;
        if(newWaterLevel < 0)
        {
            Console.WriteLine($"Water tank do not go below 0");
            return null;
        }

        return new WaterTank(tank.Capacity, newWaterLevel);
    }

    public override string ToString()
    {
        return $"Capacity: {Capacity}, Current level: {CurrentLevel}";
    }
}
