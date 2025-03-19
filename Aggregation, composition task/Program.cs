namespace ConsoleApp11;

class Program
{
    static void Main()
    {
        Random rnd = new Random();

        for (int i = 0; i < Child.Children.Length; i++)
        {
            int rndParent = rnd.Next(0, 8);

            Child.Children[i] = new Child(
                Child.ChildrenNames[i], rnd.Next(8, 18), 
                new Parent(Parent.ParentNames[rndParent], rnd.Next(23, 40), rnd.Next(150_000, 800_000)), 
                new Parent(Parent.ParentNames[rndParent + 1], rnd.Next(23, 50), rnd.Next(150_000, 800_000))
            );
        }
        
        // task 1

        foreach (var c in Child.Children)
        {
            if (c.Parent[0].Age + c.Parent[1].Age <= 70)
            {
                Console.WriteLine(c);
            }
        }
        
        // task 2

        int biggestChildAge = Child.Children[0].Age;
        int biggestChildIndex = 0;
        
        for (int i = 0; i < Child.Children.Length; i++)
        {
            if (Child.Children[i].Age > biggestChildAge)
            {
                biggestChildAge = Child.Children[i].Age;
                biggestChildIndex = i;
            }
        }

        Console.WriteLine($"The biggest child age: {biggestChildAge}, parent 1: {Child.Children[biggestChildIndex].Parent[0]}, parent 2: {Child.Children[biggestChildIndex].Parent[1]}");
        
        // task 3

        int biggestSalary = Child.Children[0].Age;
        Child biggestSalaryChild = Child.Children[0];
        
        foreach (var c in Child.Children)
        {
            if (c.Parent[0].Salary + c.Parent[1].Salary > biggestSalary)
            {
                biggestSalary = c.Parent[0].Salary + c.Parent[1].Salary;
                biggestSalaryChild = c;
            }
        }

        Console.WriteLine($"The biggest salary: {biggestSalary}, parent 1: {biggestSalaryChild.Parent[0]}, parent 2: {biggestSalaryChild.Parent[1]}");
        
        // task 4

        int youngestChildAge = Child.Children[0].Age;
        int youngestChildIndex = 0;
        
        for (int i = 0; i < Child.Children.Length; i++)
        {
            if (Child.Children[i].Age < youngestChildAge)
            {
                youngestChildAge = Child.Children[i].Age;
                youngestChildIndex = i;
            }
        }

        Console.WriteLine($"The youngest child age: {youngestChildAge}, parent 1: {Child.Children[youngestChildIndex].Parent[0]}, parent 2: {Child.Children[youngestChildIndex].Parent[1]}");

        (Child.Children[youngestChildIndex], Child.Children[biggestChildIndex]) = (Child.Children[biggestChildIndex], Child.Children[youngestChildIndex]);

        Console.WriteLine("\nFinal result:\n");
        
        foreach (var c in Child.Children)
        {
            Console.WriteLine(c);
        }
    }
}

class Parent
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Salary { get; set; }

    public Parent(string name, int age, int salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }
    
    public static readonly string[] ParentNames = ["Armen", "Mari", "David", "Ann", "Aram", "Meri", "Allen", "Elen", "Hayk", "Diana"];
    
    public override string ToString()
    {
        return $"Name: {Name}. Age: {Age}. Salary: {Salary}";
    }
}

class Child
{
    private string Name { get; }
    public int Age { get; }
    public Parent[] Parent { get; }

    public Child(string name, int age, params Parent[] parent)
    {
        Name = name;
        Age = age;
        Parent = parent;
    }
    
    public static readonly string[] ChildrenNames = ["Armen", "Aram", "David", "Arman", "Ann", "Mari", "Meri", "Elen", "Hayk", "Diana"];
    public static readonly Child[] Children = new Child[10];

    public override string ToString()
    {
        return $"Name: {Name}. Age: {Age}. Parent 1 name: {Parent[0].Name}, age: {Parent[0].Age}, salary: {Parent[0].Salary}, Parent 2 name: {Parent[1].Name}, age: {Parent[1].Age}, salary: {Parent[1].Salary}";
    }
}