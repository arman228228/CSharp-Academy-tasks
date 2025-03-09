namespace ConsoleApp4;

class Program
{
    static void Main(string[] args)
    {
        FlightTicket[] flightTickets = new FlightTicket[]
        {
            new FlightTicket("Bob", 1,  2 ),
            new FlightTicket("John", 1,  3 ),
            new FlightTicket("Alice", 1,  5 )
        };

        foreach (FlightTicket ticket in flightTickets)
        {
            Console.WriteLine("");
            ticket.ShowTicketInfo();
        }
    }
}

class FlightTicket
{
    private string _passengerName;
    private int _flightNumber;
    private int _seatNumber;

    public FlightTicket(string passengerName, int flightNumber, int seatNumber)
    {
        _passengerName = passengerName;
        _flightNumber = flightNumber;
        _seatNumber = seatNumber;
    }
    public void ShowTicketInfo()
    {
        Console.WriteLine($"Flight ticket details:\nPassenger name: {_passengerName}\nFlight number: {_flightNumber}\nSeat number: {_seatNumber}");
    }
}