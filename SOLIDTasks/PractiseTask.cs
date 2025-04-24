namespace SOLID_Practise_2;

class Program
{
    static void Main()
    {
        INotificationSender[] senders =
        {
            new EmailSender(),
            new SMSSender(),
            new PushNotificationSender(),
            new TelegramSender()
        };

        NotificationManager manager = new(senders);

        NotificationMessage message = new()
        {
            Title = "Balance update.",
            Body = "Account balance has been updated",
            Recipient = "bank@gmail.com"
        };
        
        manager.OnNotificationSent += (time, msg) => Console.WriteLine($"Notifications sent at {time}. Message title: {msg.Title}");
        
        manager.PrepareNotification(message);
    }
}

interface INotificationSender
{
    void Send(NotificationMessage message);
}
class NotificationMessage
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string Recipient { get; set; }
}

class EmailSender : INotificationSender
{
    public void Send(NotificationMessage message)
    {
        Console.WriteLine("[Email]: " + message.Title + " " + message.Body + ". Recipient: " + message.Recipient);
    }
}

class SMSSender : INotificationSender
{
    public void Send(NotificationMessage message)
    {
        Console.WriteLine("[SMS]: " + message.Title + " " + message.Body + ". Recipient: " + message.Recipient);
    }
}

class PushNotificationSender : INotificationSender
{
    public void Send(NotificationMessage message)
    {
        Console.WriteLine("[Push]: " + message.Title + " " + message.Body + ". Recipient: " + message.Recipient);
    }   
}

class TelegramSender : INotificationSender
{
    public void Send(NotificationMessage message)
    {
        Console.WriteLine("[Telegram]: " + message.Title + " " + message.Body + ". Recipient: " + message.Recipient);
    }  
}

class NotificationManager
{
    public event Action<NotificationMessage> OnNotificationReady;
    public event Action<DateTime, NotificationMessage> OnNotificationSent;
    
    private readonly IEnumerable<INotificationSender> _senders;

    public NotificationManager(IEnumerable<INotificationSender> senders)
    {
        _senders = senders;
    }
    
    public void PrepareNotification(NotificationMessage message)
    {
        OnNotificationReady?.Invoke(message);
        
        foreach(var sender in _senders)
            sender.Send(message);
        
        OnNotificationSent?.Invoke(DateTime.Now, message);
    }
}