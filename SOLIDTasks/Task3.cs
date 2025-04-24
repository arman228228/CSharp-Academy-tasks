namespace SOLIDPractise2;

// Single responsibility principle, open/closed principle, dependency inversion principle violations fix

public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle(double radius) : Shape
{
    private double Radius { get; } = radius;

    public override double CalculateArea() => Math.PI * Radius * Radius;
}

public class Square(double side) : Shape
{
    private double Side { get; } = side;

    public override double CalculateArea() => Side * Side;
}