namespace ConsoleApp6;

class Program
{
    static void Main()
    {
        Grid3D grid = new Grid3D();

        grid[5, 5, 5] = 3;
        grid[2, 2, 2] = 10;

        Console.WriteLine("grid[2, 2, 2] value: " + grid[2, 2, 2]);
    }
}

class Grid3D
{
    private int[,,] _space = new int[3, 3, 3];

    public int this[int x, int y, int z]
    {
        get
        {
            if (
                x < 0 || x > _space.GetLength(0) ||
                y < 0 || y > _space.GetLength(1) ||
                z < 0 || z > _space.GetLength(2)
            )
            {
                Console.WriteLine("Invalid arguments.");
                return -1;
            }
            
            return _space[x, y, z];
        }
        set
        {
            if (
                x < 0 || x > _space.GetLength(0) ||
                y < 0 || y > _space.GetLength(1) ||
                z < 0 || z > _space.GetLength(2)
            )
            {
                Console.WriteLine("Invalid arguments.");
                return;
            }
            
            _space[x, y, z] = value;
        }
    }
}