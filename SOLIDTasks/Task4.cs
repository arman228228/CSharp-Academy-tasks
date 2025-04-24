namespace SOLIDPractise3;

// Violations not found

public abstract class Shape
{
    public abstract double GetArea();
}
public class Circle : Shape
{
    public double Radius { get; set; }
    public override double GetArea() => 3.14 * Radius * Radius;
}
public class Square : Shape
{
    public double Side { get; set; }
    public override double GetArea() => Side * Side;
}
public class AreaCalculator
{
    public double CalculateArea(Shape shape)
    {
        return shape.GetArea();
    }
}