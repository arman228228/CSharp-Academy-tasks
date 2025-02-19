namespace ConsoleApp4;

class Program
{
    static void Main()
    {
        Product[] products =
        {
            new Product("Art", 7, 0),
            new Product("Book", 4, 1),
            new Product("Furniture", 9, 3)
        };

        foreach (var product in products)
        {
            product.ShowProductDetails();
        }
    }
}

class Product
{
    private string name;
    private int price;
    private int stockQuantity;

    public Product(string name, int price, int stockQuantity)
    {
        this.name = name;
        this.price = price;
        this.stockQuantity = stockQuantity;
    }
    
    public void ShowProductDetails()
    {
        Console.WriteLine(
            $"Product details - name: {name}, price: {price:C}, stock quantity: {stockQuantity}");
    }
}