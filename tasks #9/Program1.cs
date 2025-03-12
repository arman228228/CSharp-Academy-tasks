namespace ConsoleApp8;

class Program1
{
    static void Main()
    {
        BankAccount bankAccount = new BankAccount(5000);
        
        bool exit = false;
        
        while (!exit)
        {
            Console.WriteLine("\nMain menu:\n\n1. Add payment method\n2. Select available payment method\n3. Continue transaction:");
        
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Enter payment method name:");
                    string? methodName = Console.ReadLine();
                    
                    bankAccount.AddPaymentMethod(methodName);
                    
                    Console.WriteLine("Payment method added successfully.");
                    break;
                case 2:
                    if (bankAccount.GetPaymentMethodsCount() == 0)
                    {
                        Console.WriteLine("You don't added any payment method.");
                        break;
                    }
                    
                    bool nestedExit = false;

                    while (!nestedExit)
                    {
                        Console.WriteLine("Your payment methods, select one, or enter \"0\" to exit:");

                        bankAccount.ShowPaymentMethods();

                        int selectedMethod = int.Parse(Console.ReadLine());

                        if (selectedMethod == 0)
                        {
                            nestedExit = true;
                            break;
                        }

                        if (selectedMethod < 1 || selectedMethod > bankAccount.GetPaymentMethodsCount())
                        {
                            Console.WriteLine("Invalid param.");
                            continue;
                        }

                        bankAccount.PaymentMethod = selectedMethod - 1;

                        Console.WriteLine("Payment method selected successfully.");
                        
                        nestedExit = true;
                    }

                    break;
                case 3:
                    if (bankAccount.GetPaymentMethodsCount() == 0)
                    {
                        Console.WriteLine("You don't added any payment method.");
                        break;
                    }
                    
                    int randomPrice = new Random().Next(500, 1500);
                    
                    nestedExit = false;

                    while (!nestedExit)
                    {
                        Console.WriteLine(
                            $"Your current payment method: {bankAccount.PaymentMethods[bankAccount.PaymentMethod].Name}.\nPrice: ${randomPrice}\n\n1. Pay\n2. Back");

                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                if (TransactionSystem.Transaction(bankAccount, randomPrice))
                                {
                                    Console.WriteLine("Payment completed. New balance: " + bankAccount.Balance);
                                    nestedExit = true;
                                }

                                break;
                            case 2:
                                nestedExit = true;
                                break;
                            default:
                                Console.WriteLine("Invalid param.");
                                break;
                        }
                    }

                    break;
                default:
                    Console.WriteLine("Invalid selection. Try again..");
                    break;
            }
        }
    }
}

class BankAccount
{
    public double Balance { get; set; }
    public int PaymentMethod { get; set; }
    
    public List<PaymentMethodInfo> PaymentMethods { get; }
    
    public BankAccount(double balance)
    {
        Balance = balance;
        PaymentMethods = new List<PaymentMethodInfo>();
    }

    public void AddPaymentMethod(string method)
    {
        foreach (var excitingMethod in PaymentMethods)
        {
            if (method == excitingMethod.Name)
                return;
        }

        PaymentMethods.Add(new PaymentMethodInfo(method, new Random().Next(0, 5)));
    }

    public void ShowPaymentMethods()
    {
        for(int i = 0; i < PaymentMethods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Payment method: {PaymentMethods[i].Name}. Fee: {PaymentMethods[i].Fee}");
        }
    }

    public int GetPaymentMethodsCount()
    {
        return PaymentMethods.Count;
    }
}
class PaymentMethodInfo
{
    public string Name { get; }
    public double Fee { get; }
    
    public PaymentMethodInfo(string method, double fee)
    {
        Name = method;
        Fee = fee;
    }
}

static class TransactionSystem
{
    static public bool Transaction(BankAccount account, in int amount)
    {
        if (account.GetPaymentMethodsCount() == 0)
        {
            Console.WriteLine("No payment methods available.");
            return false;
        }
        
        double fee = account.PaymentMethods[account.PaymentMethod].Fee,
            sumWithFee = amount + ((amount * fee) / 100);

        if (sumWithFee < 0)
        {
            Console.WriteLine("Invalid amount.");
            return false;
        }
        
        account.Balance -= sumWithFee;

        return true;
    }
}