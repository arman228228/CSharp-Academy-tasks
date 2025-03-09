using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Product[] products = new Product[0];
            
            while (true)
            {
                Array.Resize(ref products, products.Length + 1);
                
                int lastIndex = products.Length - 1;
                
                products[lastIndex] = new Product();
                
                Console.WriteLine("Enter product name:");

                products[lastIndex].Name = Console.ReadLine();
                
                Console.WriteLine("Enter product price:");
                products[lastIndex].Price = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Enter product quantity:");
                products[lastIndex].Quantity = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Do you want to add another product? (yes/no):");

                if (Console.ReadLine() != "yes")
                {
                    break;
                }
            }

            Console.WriteLine("\nProduct list:");

            int totalCost = 0, totalItems = 0, priceForItem = 0;
            
            foreach (Product product in products)
            {
                priceForItem = product.TotalPrice();
                totalCost += priceForItem;
                totalItems += product.Quantity;
                
                Console.WriteLine(
                    $"Product name: {product.Name}, price: {product.Price}, quantity: {product.Quantity}, total price for product: {priceForItem}");
                
            }

            Console.WriteLine($"\nTotal items: {totalItems}. Total cost: {totalCost}");

            if (totalItems > 5)
            {
                Console.WriteLine($"More than 5 items purchased. Applying a 10% discount. Total price without discount: {totalCost}, with discount: {totalCost * 0.9m}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
  
        public int TotalPrice()
        {
            return Price * Quantity;
        }
    }
}