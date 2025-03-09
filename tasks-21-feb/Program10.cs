namespace ConsoleApp5;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter any text:");
        string? text = Console.ReadLine();
        
        string[] words = text.Split(' ');

        int wordLength;

        Console.WriteLine("Longest word: " + WordsCalculations.GetLongestWord(out wordLength, words) + ", with length: " + wordLength);
    }
}

class WordsCalculations
{
    public static string GetLongestWord(out int wordLength, params string[] words)
    {
        int index = 0;
        wordLength = words[0].Length;

        for (int i = 0; i < words.Length; i++)
        {
            if (wordLength < words[i].Length)
            {
                wordLength = words[i].Length;
                index = i;
            }
        }

        return words[index];
    }
}