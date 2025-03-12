using System.Text;

namespace ConsoleApp7;

class Program
{
    static void Main()
    {
        Document[] document =
        {
            new Document("text 1"),
            new Document("text 2"),
            new Document("text 3")
        };

        Cache cache = new Cache(document);

        Document tempDocument = new Document("temp doc");
        
        // Invalid index
        cache[4] = tempDocument;
        
        // Valid index
        Console.WriteLine("Cache in 2 index: " + cache[2]);
        
        cache[2] = tempDocument;
        Console.WriteLine("Changed cache in 2 index: " + cache[2].Content);

        // Timer check
        Console.WriteLine("Cache in 0 index: " + cache[0].Content);
        
        System.Threading.Thread.Sleep(15000);
        
        Console.WriteLine("After timer cache in 0 index: " + (cache[0] != null ? cache[0].Content : null));
    }
}

class Document
{
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public Document(string content)
    {
        Content = content;
        CreatedAt = DateTime.Now;
    }
}

class Cache
{
    private readonly Document?[] document;

    public Cache(Document[] document)
    {
        this.document = document;
    }

    public Document this[int index]
    {
        get
        {
            Cleanup();
            
            if (index < 0 || index >= document.Length || document[index] == null)
            {
                Console.WriteLine("Entered index not cached.");
                return null;
            }

            return document[index];
        }
        set
        {
            Cleanup();

            if (index < 0 || index >= document.Length || document[index] == null)
            {
                Console.WriteLine("Entered index not cached.");
                return;
            }

            document[index] = value;
        }
    }

    public void Cleanup()
    {
        for (int i = 0; i < document.Length; i++)
        {
            if (document[i] == null || (DateTime.Now - document[i].CreatedAt).TotalSeconds <= 15)
                continue;
            
            for (int j = i; j < document.Length - 1; j++)
            {
                document[j] = document[j + 1];
            }

            document[document.Length - 1] = null;

            i--;
        }
    }
}