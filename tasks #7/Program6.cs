namespace ConsoleApp6;

class Program
{
    static void Main()
    {
        Person[] persons =
        {
            new Person(1, "Bob"),
            new Person(35, "David"),
            new Person(22, "Ann")
        };
        
        ContactArray contacts = new ContactArray(persons);
        Console.WriteLine(contacts[35]);
        Console.WriteLine(contacts["Ann"]);
        
        //
        
        Console.WriteLine(contacts[50] == null ? ("Not found") : contacts[50]);
        Console.WriteLine(contacts["Alex"] == null ? ("Not found") : contacts["Alex"]);
    }
}

class ContactArray
{
    private readonly Person[] contacts;

    public ContactArray(Person[] contacts)
    {
        this.contacts = contacts;
    }

    public Person? this[int id]
    {
        get
        {
            if (id < 0)
            {
                Console.WriteLine("Invalid ID.");
                return null;
            }
            
            foreach (Person person in contacts)
            {
                if (person.ID != id)
                    continue;

                return person;
            }

            return null;
        }
    }

    public Person? this[string name]
    {
        get
        {
            foreach (Person person in contacts)
            {
                if (person.Name != name)
                    continue;

                return person;
            }

            return null;
        }
    }
}

class Person
{
    public int ID { get; private set; }
    public string Name { get; private set; }

    public Person(int id, string name)
    {
        ID = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Person ID: {ID}, Name: {Name}";
    }
}