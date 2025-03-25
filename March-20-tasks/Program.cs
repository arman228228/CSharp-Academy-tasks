namespace ConsoleApp13;

readonly struct DefaultWords
{
    static readonly string[] EnglishWords =
    [
        "Apple", "Banana", "Orange", "Mango", "Pineapple", "Grape", "Strawberry", "Cherry", "Watermelon", "Peach"
    ];
    
    static readonly string[] RussianWords =
    [
        "Яблоко", "Банан", "Апельсин", "Манго", "Ананас", "Виноград", "Клубника", "Вишня", "Арбуз", "Персик"
    ];
    
    static readonly string[] SpanishWords =
    [
        "Manzana", "Plátano", "Naranja", "Mango", "Piña", "Uva", "Fresa", "Cereza", "Sandía", "Melocotón"
    ];
    
    static readonly string[] FrenchWords =
    [
        "Pomme", "Banane", "Orange", "Mangue", "Ananas", "Raisin", "Fraise", "Cerise", "Pastèque", "Pêche"
    ];

    public static string GetRussianWord(string text)
    {
        for (int word = 0; word < EnglishWords.Length; word++)
        {
            if (DefaultWords.EnglishWords[word] == text)
            {
                return RussianWords[word];
            }
        }

        return "none";
    }
    
    public static string GetSpanishWord(string text)
    {
        for (int word = 0; word < EnglishWords.Length; word++)
        {
            if (DefaultWords.EnglishWords[word] == text)
            {
                return SpanishWords[word];
            }
        }

        return "none";
    }
    
    public static string GetFrenchWord(string text)
    {
        for (int word = 0; word < EnglishWords.Length; word++)
        {
            if (DefaultWords.EnglishWords[word] == text)
            {
                return FrenchWords[word];
            }
        }

        return "none";
    }
}

abstract class Translator
{
    public abstract string Translate(string text);
}

class Russian : Translator
{
    public override string Translate(string text)
    {
        return DefaultWords.GetRussianWord(text);
    }
}

class Spanish : Translator
{
    public override string Translate(string text)
    {
        return DefaultWords.GetSpanishWord(text);
    }
}

class French : Translator
{
    public override string Translate(string text)
    {
        return DefaultWords.GetFrenchWord(text);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Translator[] words = new Translator[3];
        
        words[0] = new Spanish();
        words[1] = new French();
        words[2] = new Russian();
        
        foreach(Translator t in words)
        {
            Console.WriteLine(t.Translate("Apple"));
        }
    }
}