namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Students students = new Students();
        
        Console.WriteLine("Ann grade: " + students["Ann"]);
    }
}

class Students
{
    private string[] subjects = {"Bob", "Ann", "David"};
    private int[] grades = {78, 90, 50};

    public int this[string subject]
    {
        get
        {
            for(int i = 0; i < subjects.Length; i++)
            {
                if(subjects[i] != subject)
                {
                    continue;
                }

                return grades[i];
            }

            return -1;
        }
    }
}
