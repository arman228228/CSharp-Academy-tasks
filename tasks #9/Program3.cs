namespace ConsoleApp8;

enum Role { Admin, Manager, Employee }

class Program
{
    static void Main()
    {
        User admin = new User("Bob", Role.Admin);
        User manager = new User("Alice", Role.Manager);
        User employee = new User("Alex", Role.Employee);

        Action(admin, "write");
        
        Action(manager, "write");
        Action(manager, "delete");
        
        Action(employee, "write");
        Action(employee, "delete");

        employee.SetRole(Role.Admin, manager);
        employee.SetRole(Role.Admin, admin);
        
        Action(employee, "delete");
    }

    static void Action(User user, string action)
    {
        switch (action)
        {
            case "read":
                Console.WriteLine($"{user.Name} can read.");
                break;
            case "write":
                if (user.CanWrite()) Console.WriteLine($"{user.Name} can write.");
                else Console.WriteLine($"{user.Name} can not write.");
                break;
            case "delete":
                if (user.CanDelete()) Console.WriteLine($"{user.Name} can delete.");
                else Console.WriteLine($"{user.Name} can not delete.");
                break;
            default:
                Console.WriteLine("Invalid action");
                break;
        }
    }
}

class User
{
    public string Name { get; set; }
    public Role Role { get; set; }

    public User(string name, Role role)
    {
        Name = name;
        Role = role;
    }

    public void SetRole(Role newRole, User executor)
    {
        if (executor.Role == Role.Admin)
        {
            Role = newRole;
        }
        else
        {
            Console.WriteLine($"{executor.Name} don't have access to change roles.");
        }
    }

    public bool CanRead() => true;
    public bool CanWrite() => Role == Role.Manager || Role == Role.Admin;
    public bool CanDelete() => Role == Role.Admin;
}