namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        int[] triangle = new int[3];

        Console.WriteLine("Enter first side size:");

        triangle[0] = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second side size:");

        triangle[1] = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter third side size:");

        triangle[2] = int.Parse(Console.ReadLine());

        Console.WriteLine(
            triangle[0] == triangle[1] && triangle[1] == triangle[2] ? "Equilateral" : 
            triangle[0] == triangle[1] || triangle[0] == triangle[2] || triangle[1] == triangle[2] ? "Isosceles" : 
            "Scalene"
        );
    }
}
