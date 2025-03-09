namespace ConsoleApp4;

class Program
{
    static void Main()
    {
        Smartwatch[] smartwatch =
        {
            new Smartwatch("Bob", 0),
            new Smartwatch("David", 3)
        };

        Console.WriteLine("Steps:");
        smartwatch[0].ShowSteps();
        smartwatch[1].ShowSteps();
        
        smartwatch[0].AddSteps(13);
        smartwatch[1].AddSteps(8);

        Console.WriteLine("\nNew steps:");
        smartwatch[0].ShowSteps();
        smartwatch[1].ShowSteps();
    }
}

class Smartwatch
{
    private string _ownerName;
    private int _stepCount;
    
    public Smartwatch(string ownerName, int stepCount)
    {
        _ownerName = ownerName;
        _stepCount = stepCount;
    }

    public void AddSteps(int steps)
    {
        _stepCount += steps;
    }

    public void ShowSteps()
    {
        Console.WriteLine($"Owner name: {_ownerName}, steps: {_stepCount}");
    }
}