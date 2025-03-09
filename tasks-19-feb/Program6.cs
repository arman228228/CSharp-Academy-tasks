namespace ConsoleApp4;

class Program
{
    static void Main()
    {
        Movie movie = new Movie();

        movie.Rating = 3;
        Console.WriteLine($"Movie rating: {movie.Rating}");
        
        movie.Rating = 10;
        Console.WriteLine($"Movie rating: {movie.Rating}");
    }
}

class Movie
{
    private int _rating;

    public int Rating
    {
        get
        {
            return _rating;
        }
        set
        {
            if (value < 1 || value > 5)
            {
                Console.WriteLine("Warning! The rating is set not in range of 1 to 5.");
            }
            
            _rating = value;
        }
    }
}