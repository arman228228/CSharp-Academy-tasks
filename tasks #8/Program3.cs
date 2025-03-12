using System.Text;

namespace ConsoleApp7;

class Program
{
    static void Main()
    {
        Grid grid = new Grid(3, 3);
        
        // Invalid param
        grid[3, 3] = 5;
        
        // Valid param
        grid[1, 0] = 7;
        grid[2, 1] = 3;

        // Get row values
        int[] rows = grid.GetRow(2);
        
        // Get column values
        int[] columns = grid.GetColumn(0);
        
        Console.WriteLine("grid[2, 1] value: " + grid[2, 1] + ", rows: " + rows[1] + ", columns: " + columns[1]);
    }
}

class Grid
{
    private readonly int[,] grid;

    public Grid(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
        {
            Console.WriteLine("Invalid params.");
            return;
        }

        grid = new int[rows, columns];
    }

    public int this[int row, int column]
    {
        get
        {
            if (row < 0 || row >= RowsTotal ||
                column < 0 || column >= ColumnsTotal)
            {
                Console.WriteLine("Invalid params.");
                return -1;
            }
            
            return grid[row, column];
        }
        set
        {
            if (row < 0 || row >= RowsTotal ||
                column < 0 || column >= ColumnsTotal)
            {
                Console.WriteLine("Invalid params.");
                return;
            }
            
            grid[row, column] = value;
        }
    }
    
    public int RowsTotal => grid.GetLength(0);
    public int ColumnsTotal => grid.GetLength(1);

    public int[] GetRow(int row)
    {
        if (row < 0 || row >= RowsTotal)
        {
            Console.WriteLine("Invalid param.");
            return [0, 0];
        }

        int[] newData = new int[ColumnsTotal];

        for (int i = 0; i < ColumnsTotal; i++)
        {
            newData[i] = grid[row, i];
        }

        return newData;
    }

    public int[] GetColumn(int column)
    {
        if (column < 0 || column >= ColumnsTotal)
        {
            Console.WriteLine("Invalid param.");
            return [0, 0];
        }

        int[] newData = new int[RowsTotal];
        
        for (int i = 0; i < RowsTotal; i++)
        {
            newData[i] = grid[i, column];
        }

        return newData;
    }
}