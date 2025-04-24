namespace EventTask;

class Program
{
    static void Main()
    {
        Shop shop = new Shop() { Name = "MShop", Discount = 10 };
        
        Customer[] customers =
        [
            new Customer { Name = "John" },
            new Customer { Name = "Mary" },
            new Customer { Name = "David" }
        ];

        foreach (var i in customers)
        {
            shop.DiscountChanged += i.OnNotifyPriceChanged;
        }
        
        shop.Discount = 20;
    }
}

class Shop
{
    public string? Name { get; init; }
    private double _discount;
    
    public double Discount
    {
        get => _discount;
        set
        {
            if (_discount.CompareTo(value) == -1)
            {
                OnDiscountChanged(new DiscountChangedEventArgs(_discount, value));
                _discount = value;
            }
        }
    }
    public event EventHandler<DiscountChangedEventArgs>? DiscountChanged;

    private void OnDiscountChanged(DiscountChangedEventArgs e) => DiscountChanged?.Invoke(this, e);
}

class DiscountChangedEventArgs(double oldDiscount, double newDiscount) : EventArgs
{
    public double OldDiscount { get; set; } = oldDiscount;
    public double NewDiscount { get; set; } = newDiscount;
}

class Customer
{
    public string? Name { get; init; }

    public void OnNotifyPriceChanged(object? s, DiscountChangedEventArgs e)
    {
        if(s is Shop sender)
            Console.WriteLine($"{Name} SMS: In {sender.Name} discount changed from {e.OldDiscount} to {e.NewDiscount}");
    }
}