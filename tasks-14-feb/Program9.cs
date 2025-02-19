namespace ConsoleApp2;

class Program
{
    static int Main(string[] args)
    {
        string? input = Console.ReadLine();

        if(input != null)
        {
            string[] words = input.Split(' ');

            string longestWord = "";

            foreach(string word in words)
            {
                if(longestWord.Length < word.Length)
                {
                    longestWord = word;
                }
            }

            Console.WriteLine("Longest word: " + longestWord);
        }
        return 0;
    }
}
