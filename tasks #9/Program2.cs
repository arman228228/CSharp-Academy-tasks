namespace ConsoleApp8;

class Program
{
    static void Main()
    {
        LandVehicle car = new LandVehicle("Toyota", 150.0f, 7.5f);
        AirVehicle plane = new AirVehicle("Airbus", 400.0f, 30.8f);
        WaterVehicle water = new WaterVehicle("Boat", 50.0f, 10.2f);
        
        User user = new User();
        user.AddVehicle(car);
        user.AddVehicle(plane);
        user.AddVehicle(water);

        foreach (var vehicle in user.VehicleList)
        {
            vehicle.Move();
            Console.WriteLine($"Fuel consuption: {vehicle.FuelConsuption}, speed: {vehicle.Speed}");
        }
        
        Console.WriteLine(car.FuelConsuption);
    }
}

interface IVehicle
{ 
    void Move();
}

class Vehicle
{
    public string Name { get; private set; }
    public float Speed { get; private set; }
    public float FuelConsuption { get; set; }

    public Vehicle()
    {
        Console.WriteLine("vEH movement");
    }
    
    public Vehicle(string name, float speed, float fuelConsuption)
    {
        Name = name;
        Speed = speed;
        FuelConsuption = fuelConsuption;
    }

    public virtual void Move()
    {
        Console.WriteLine($"{Name} moving.");
    }
}

class LandVehicle : Vehicle, IVehicle
{
    public LandVehicle(string name, float speed, float fuelConsuption) : base(name, speed, fuelConsuption)
    {
        
    }
    
    public override void Move()
    {
        Console.WriteLine("Car movement");
    }
}

class AirVehicle : Vehicle, IVehicle
{
    public AirVehicle(string name, float speed, float fuelConsuption) : base(name, speed, fuelConsuption)
    {
        
    }
    
    public override void Move()
    {
        Console.WriteLine("Plane movement");
    }
}

class WaterVehicle : Vehicle, IVehicle
{
    public WaterVehicle(string name, float speed, float fuelConsuption) : base(name, speed, fuelConsuption)
    {
        
    }
    
    public override void Move()
    {
        Console.WriteLine("Plane movement");
    }
}

class User
{
    public List<Vehicle> VehicleList { get; set; }

    public User()
    {
        VehicleList = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        VehicleList.Add(vehicle);
        Console.WriteLine($"{vehicle.Name} added to user.");
    }
}