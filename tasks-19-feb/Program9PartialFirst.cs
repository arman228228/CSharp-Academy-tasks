namespace ConsoleApp4;

class ProgramPartialFirst
{
    static void Main()
    {
        Character[] characters =
        {
            new Character { characterName = "Bob", level = 3 },
            new Character { characterName = "John", level = 15 }
        };

        foreach (var character in characters)
        {
            character.ShowCharacterInfo();
        }
    }
}

partial class Character
{
    public string? characterName { get; set; }
    public int level { get; set; }
}