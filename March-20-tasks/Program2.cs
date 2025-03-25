namespace ConsoleApp14;

abstract class Shape
{
    public abstract int Surface();
    public abstract void Draw();

    public void Print()
    {
        Console.WriteLine($"{this.GetType().Name}, S = {Surface()}");
        Draw();
    }
}

class Square(int value) : Shape
{
    public override int Surface()
    {
        return value * value;
    }
    
    public override void Draw()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write("+ ");
            }

            Console.WriteLine("");
        }
    }
}

class Rectangle(int firstValue, int secondValue) : Shape
{
    public override int Surface()
    {
        return firstValue * secondValue;
    }
    
    public override void Draw()
    {
        for (int i = 0; i < firstValue; i++)
        {
            for (int j = 0; j < secondValue; j++)
            {
                Console.Write("+ ");
            }

            Console.WriteLine("");
        }
    }
}

class Program
{
    static void Main()
    {
        Shape[] shapes = new Shape[2];
        shapes[0] = new Square(4);
        shapes[1] = new Rectangle(4, 6);
        
        foreach(Shape s in shapes)
        {
            s.Print();
        }
    }
}