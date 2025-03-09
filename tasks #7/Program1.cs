namespace ConsoleApp6;

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person
        {
            FirstName = "Arman",
            LastName = "Vardanyan"
        };

        Console.WriteLine("Full name: " + person.FullName);
    }
}

class Person
{
    public string FirstName { private get; set; }
    public string LastName { private get; set; }
    private string _FullName;

    public string FullName
    {
        get
        {
            if (_FullName == null)
            {
                _FullName = FirstName + " " + LastName;
            }

            return _FullName;
        }
    }
}