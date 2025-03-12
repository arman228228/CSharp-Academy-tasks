namespace ConsoleApp7;

class Program
{
    static void Main()
    {
        CustomList list = new CustomList();

        list[0] = 5;
        
        list.AddElement(value: 15);
        
        list.AddElement(value: 10);
        
        list.AddElement(value: 20);
        
        list.AddElement(value: 25);
        
        list.RemoveElement(value: 20);

        list.ShowList();
    }
}

class CustomList
{
    private const int DefaultArraySize = 1;
    
    private int?[] values = new int?[DefaultArraySize];
    private int Length;

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= GetLength() || values[index] == null)
            {
                Console.WriteLine("Invalid index.");
                return -1;
            }
            
            return (int)values[index];
        }
        set
        {
            if (index < 0 || index >= GetLength())
            {
                Console.WriteLine("Invalid index.");
                return;
            }
            
            values[index] = value;
        }
    }

    public void AddElement(int value = 0)
    {
        if (Length >= values.Length)
        {
            Array.Resize(ref values, values.Length * 2);
        }

        values[Length++] = value;
    }

    public void RemoveElement(int value)
    {
        int index = -1;
        
        for(int i = 0; i < Length; i++)
        {
            if (values[i] == value)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            Console.WriteLine("Value not found in list.");
            return;
        }
        
        for(int i = index; i < Length - 1; i++)
        {
            values[i] = values[i + 1];
        }

        values[--Length] = null;
    }

    public int GetLength() => Length;

    public void ShowList()
    {
        Console.WriteLine("Custom list description: ");
        
        for(int i = 0; i < values.Length; i++)
        {
            Console.WriteLine("Index: " + i + ". Value: " + (values[i] == null ? "not assigned" : values[i]));
        }
    }
}