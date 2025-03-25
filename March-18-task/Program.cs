namespace ConsoleApp12;

class Program
{
    static void Main()
    {
        Course[] courses = new Course[]
        {
            new Web("Frontend Development", 500000, "frontend", new Module[] 
            { 
                new Module("HTML & CSS", 2), new Module("JavaScript", 3) 
            }),
            new Web("Fullstack Development", 60000, "fullstack", new Module[] 
            { 
                new Module("Node.js", 4), new Module("React", 5) 
            }),
            new AI("Machine Learning", 80000, new Module[] 
            { 
                new Module("Python for AI", 6), new Module("Deep Learning", 8) 
            }),
            new Game("Game Development", 72000, "Unity", new Module[] 
            { 
                new Module("C# for Unity", 5), new Module("Physics in Games", 4) 
            }),
            new Game("Game Dev Advanced", 42000, "Unreal", new Module[] 
            { 
                new Module("Blueprints", 6), new Module("C++ for Unreal", 7), new Module("C# for Unreal", 7) 
            })
        };
        
        Group[] groups = new Group[]
        {
            new Group("Frontend Group 1", 15, courses[0]),   // Frontend Development
            new Group("Fullstack Group 1", 12, courses[1]),  // Fullstack Development
            new Group("AI Group 1", 10, courses[2]),         // Machine Learning
            new Group("Game Dev Group 1", 20, courses[3]),   // Unity Game Development
            new Group("Game Dev Group 2", 18, courses[4])    // Unreal Game Development
        };

        // task 1
        
        int totalWebStudents = 0;
        
        foreach (var i in groups)
        {
            if (i.Course is Web)
            {
                totalWebStudents += i.TotalStudents;
            }
        }

        Console.WriteLine("Total students in web development: " + totalWebStudents);
        
        // task 2
        
        int totalIncome = 0;
        
        foreach (var group in groups)
        {
            if (group.Course is Game)
            {
                foreach (var module in group.Course.Modules)
                {
                    if (module.Name.Contains("Unreal"))
                    {
                        totalIncome += group.Course.MonthlyPayment * group.TotalStudents;
                    }
                }
            }
        }

        Console.WriteLine("Total income from game development, unreal module: " + totalIncome);
        
        // task 3

        int biggestGroup = groups[0].TotalStudents;
        Group groupIndex = groups[0];
        
        foreach (var group in groups)
        {
            if (biggestGroup < group.TotalStudents)
            {
                biggestGroup = group.TotalStudents;
                groupIndex = group;
            }
        }
        
        Console.WriteLine("Best group: " + groupIndex.Name + ". Course: " + groupIndex.Course.Name);
    }
}

class Course(string name, int monthlyPayment, Module[] modules)
{
    public string Name { get; } = name;
    public int MonthlyPayment { get; } = monthlyPayment;
    public Module[] Modules { get; } = modules;
}

class Module(string name, int hours)
{
    public string Name { get; } = name;
    private int Hours = hours;
}

class Group(string name, int totalStudents, Course course)
{
    public string Name { get; } = name;
    public int TotalStudents { get; } = totalStudents;
    public Course Course { get; } = course;
}

class Web(string name, int monthlyPayment, string position, Module[] modules)
    : Course(name, monthlyPayment, modules)
{
    private string Position { get; set; } = position;
}

class Game(string name, int monthlyPayment, string engine, Module[] modules)
    : Course(name, monthlyPayment, modules)
{
    private string Engine { get; set; } = engine;
}

class AI(string name, int monthlyPayment, Module[] modules) 
    : Course(name, monthlyPayment, modules);