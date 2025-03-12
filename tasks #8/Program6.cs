using System.Text;

namespace ConsoleApp7;

class Program
{
    static void Main()
    {
        NotificationSystem system = new NotificationSystem(5);

        system.Send("hello", "user1");
        system.Send("message", "user2");
        system.Send("text", "user3");

        Console.WriteLine(system.Get("user3"));
        Console.WriteLine(system.Get("user2"));
    }
}

class Notification
{
    public string Message { get; }
    public string Name { get; }

    public Notification(string message, string name)
    {
        Message = message;
        Name = name;
    }
}

class NotificationSystem
{
    private readonly Notification?[] notifications;

    public NotificationSystem(int capacity)
    {
        notifications = new Notification[capacity];
    }

    public bool Send(string message, string user)
    {
        for (int i = 0; i < notifications.Length; i++)
        {
            if (notifications[i] != null)
                continue;

            notifications[i] = new Notification(message, user);
            return true;
        }

        Console.WriteLine("Not enough space to save notification.");
        return false;
    }
    
    public string Get(string user)
    {
        for (int i = 0; i < notifications.Length; i++)
        {
            if (notifications[i].Name != user)
                continue;
            
            return notifications[i].Message;
        }

        return null;
    }
}

