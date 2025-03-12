using System.Text;

namespace ConsoleApp7;

class Program
{
    static void Main()
    {
        Data[] data =
        {
            new Data(new StringBuilder("text 1"), SecurityAccess.MinimalReadLevel(), SecurityAccess.MinimalWriteLevel()),
            new Data(new StringBuilder("text 2"), 3, 3),
            new Data(new StringBuilder("text 3"), SecurityAccess.MinimalReadLevel(), SecurityAccess.MinimalWriteLevel()),
            new Data(new StringBuilder("text 4"), 0, 0)
        };

        Person person = new Person(2, 2);

        // no permission
        Console.WriteLine("Write result (no access):");
        person.Write(data[1], new StringBuilder("changed text"));
        
        Console.WriteLine("\nRead result (no access):");
        person.Read(data[1]);
        
        // have permission
        Console.WriteLine("\nWrite result (with access):");
        person.Write(data[0], new StringBuilder("changed text"));
        Console.WriteLine("Changed text: " + person.Read(data[0]));
    }
}

static class SecurityAccess
{
    static private readonly int[] ReadLevels = { 0, 1, 2, 3 };
    static private readonly int[] WriteLevels = { 0, 3, 5, 7 };
    
    public static int MinimalReadLevel() => ReadLevels[0];
    public static int MinimalWriteLevel() => WriteLevels[0];
    public static int MaximalReadLevel() => ReadLevels[ReadLevels.Length - 1];
    public static int MaximalWriteLevel() => WriteLevels[WriteLevels.Length - 1];
}

class Person
{
    public int ReadAccessLevel { get; }
    public int WriteAccessLevel { get; }

    public Person(int readAccessLevel, int writeAccessLevel)
    {
        ReadAccessLevel = readAccessLevel;
        WriteAccessLevel = writeAccessLevel;
    }
    
    public string? Read(Data data)
    {
        if (ReadAccessLevel < data.ReadAccessLevel)
        {
            Console.WriteLine("Don't have permission to read.");
            return null;
        }
        
        return data.Text.ToString();
    }
    
    public bool Write(Data data, StringBuilder newText)
    {
        if (WriteAccessLevel < data.WriteAccessLevel)
        {
            Console.WriteLine("Don't have permission to write.");
            return false;
        }

        data.Text.Clear();
        data.Text.Append(newText);
        return true;
    }
}

class Data
{
    public StringBuilder Text { get; } = null!;
    public int ReadAccessLevel { get; }
    public int WriteAccessLevel { get; }

    public Data(StringBuilder text, int readAccessLevel, int writeAccessLevel)
    {
        if (readAccessLevel < 0 || readAccessLevel > SecurityAccess.MaximalReadLevel())
        {
            Console.WriteLine("Read access invalid value.");
            return;
        }
        else if (writeAccessLevel < 0 || writeAccessLevel > SecurityAccess.MaximalWriteLevel())
        {
            Console.WriteLine("Write access invalid value.");
            return;
        }
        
        Text = text;
        ReadAccessLevel = readAccessLevel;
        WriteAccessLevel = writeAccessLevel;
    }
}