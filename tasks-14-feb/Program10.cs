namespace ConsoleApp2;

class Program
{
    static int Main(string[] args)
    {
        char[,] arr = new char[10, 10];

        Random randGenerator = new Random();

        for(int i = 0; i < arr.GetLength(0); i++)
        {
            for(int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = '-';
            }
        }

        int xRow = randGenerator.Next(0, arr.GetLength(0)),
            xCol = randGenerator.Next(0, arr.GetLength(1));

        arr[xRow, xCol] = 'X';
        arr[0, 0] = 'P';

        for(int i = 0, pRow = 0, pCol = 0, found = 0; i < arr.GetLength(0); i++)
        {
            for(int j = 0; j < arr.GetLength(1); j++)
            {
                arr[pRow, pCol] = '-';

                pRow = i;
                pCol = j;

                if(xRow == pRow && xCol == pCol)
                {
                    arr[pRow, pCol] = 'P';

                    found = 1;

                    Console.WriteLine($"X found in pos: [{xRow}, {xCol}]");

                    break;
                }

                arr[pRow, pCol] = 'P';
            }

            if(found == 1) 
            {
                break;
            }
        }

        return 0;
    }
}
