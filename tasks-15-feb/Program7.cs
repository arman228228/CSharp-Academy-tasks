using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            MovieTicket[] tickets = new MovieTicket[5];

            for (int i = 0; i < 5; i++)
            {
                tickets[i] = new MovieTicket("Random Movie", i + 1);
            }
            
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Available seats:");

                foreach (MovieTicket movie in tickets)
                {
                    if (movie.IsBooked) continue;

                    Console.WriteLine($"Movie name: {movie.MovieName}, Seat number: {movie.SeatNumber}");
                }

                Console.WriteLine("Enter seat number to booking a movie:");

                int seat = int.Parse(Console.ReadLine());

                if (tickets[seat - 1].BookTicket() == false)
                {
                    Console.WriteLine("Entered seat number is reserved.");
                    continue;
                }

                Console.WriteLine("Seat booked.");
            }
        }
    }
    class MovieTicket
    {
        public string MovieName { get; private set; }
        public int SeatNumber { get; private set; }
        public bool IsBooked { get; private set; }

        public bool BookTicket()
        {
            if (!IsBooked)
            {
                IsBooked = true;
                return true;
            }
            return false;
        }

        public MovieTicket(string movieName, int seatNumber)
        {
            MovieName = movieName;
            SeatNumber = seatNumber;
            IsBooked = false;
        }
    }
}