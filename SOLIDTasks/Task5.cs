namespace SOLIDPractise4;

// DIP, OCP violations

public interface IMessageService
{
    void Send(string message);
}
public class EmailService : IMessageService
{
    public void Send(string message)
    {
        Console.WriteLine("Sending Email: " + message);
    }
}
public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Alert(string message)
    {
        _messageService.Send(message);
    }
}