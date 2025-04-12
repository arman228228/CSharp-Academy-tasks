namespace GenericTransformer;

public delegate void Transformer<T>(T arg);
class Program
{
    static void Main(string[] args)
    {
        Transformer<string> op = StringToInt;

        op("434");

        op = s => IntToString(int.Parse(s));
        op(5.ToString());
    }

    static void IntToString(int n)
    {
        Console.WriteLine("func" + n.ToString());
    }

    static void StringToInt(string n)
    {
        Console.WriteLine(int.Parse(n));
    }

    static void StringToUpper(string n)
    {
        Console.WriteLine(n.ToUpper());
    }
}
