namespace ConsoleApp6;

class Program
{
    static void Main()
    {
        Product product = new Product
        {
            Price = -500
        };

        Stock stock = new Stock
        {
            Count = -4
        };

        Console.WriteLine("Product price: " + product.Price + ". Stock: " + stock.Count);
    }
}

class Product
{
    private double _price;
    
    public double Price 
    {
        get
        {
            return _price;
        }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            
            _price = value;
        }
    }
}

class Stock
{
    private int _count;

    public int Count
    {
        get
        {
            return _count;
        }
        set
        {
            if (value < 0)
            {
                value = 10;
            }

            _count = value;
        }
    }
}