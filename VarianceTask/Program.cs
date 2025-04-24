namespace VariancePractise;

class Program
{
    static void Main()
    {
        MyList<string> list = new();
        
        list.Add("hello");
        Console.WriteLine("0 item: " + list[0]);

        list[1] = "world";
        Console.WriteLine("1 item: " + list[1]);

        //Covariance
        VarianceTests.ReadTest(list);    }
        
        //Contravariance
        MyList<object> objList = new();
        VarianceTests.WriteTest(list);
    }
}

interface IReadBox<out T>
{
    T this[int index]
    {
        get;
    }
}

interface IWriteBox<in T>
{
    void Add(T item);
}

class MyList<T> : IReadBox<T>, IWriteBox<T>
{
    private T?[]? Items;
    private int Capacity { get; set; }
    private int Size { get; set; }
    
    public MyList()
    {
        Capacity = 2;
        Size = 0;

        Items = new T[Capacity];
    }
    
    public T this[int index]
    {
        get => Items[index];
        set
        {
            if (index < Size)
                Items[index] = value;
            else
                Add(value);
        }
    }

    public void Add(T item)
    {
        if (Size == Capacity)
        {
            Capacity *= 2;
            
            Array.Resize(ref Items, Capacity);
        }
        
        Items[Size++] = item;
    }
}

class VarianceTests
{
    public static void ReadTest(IReadBox<object> box)
    {
        Console.WriteLine($"[Covariance - ReadTest]: 0 element: {box[0]}");
    }
    
    public static void WriteTest(IReadBox<string> box)
    {
        Console.WriteLine($"[Contravariance - ReadTest]: 0 element: {box[0]}");
    }
}