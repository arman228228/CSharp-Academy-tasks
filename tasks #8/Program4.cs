using System.Text;

namespace ConsoleApp7;

class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount("David", 4, 30, "USD");
        BankAccount account2 = new BankAccount("Ann", 10, 15000, "AMD");

        Transactions.Deposit(ref account1, 400, "AMD", out string transactionDetails);
        Console.WriteLine(transactionDetails);
        
        //
        
        Transactions.Withdraw(ref account2, 500, out transactionDetails);
        Console.WriteLine(transactionDetails);
        
        //
        
        Transactions.Transfer(ref account2, ref account1, 400, out transactionDetails);
        Console.WriteLine(transactionDetails);
    }
}

class BankAccount
{
    public string Name { get; set; }
    public int ID { get; set; }
    public double Balance { get; set; }
    public string Currency { get; set; }

    public BankAccount(string Name, int ID, double Balance, string Currency)
    {
        this.Name = Name;
        this.ID = ID;
        this.Balance = Balance;
        this.Currency = Currency;
    }
}

static class Transactions
{
    public static void Deposit(ref BankAccount account, in double amount, in string depositCurrency, out string transactionDetails)
    {
        if (amount <= 0)
        {
            transactionDetails = "Invalid deposit amount.";
            return;
        }

        double convertedAmount;

        if (account.Currency != depositCurrency)
        {
            convertedAmount = CurrencyConverter.Convert(in amount, depositCurrency, account.Currency);
        }
        else
        {
            convertedAmount = amount;
        }
        
        account.Balance += convertedAmount;
        transactionDetails = $"Deposit amount: " + amount + ", new balance: " + account.Balance;
    }
    public static bool Withdraw(ref BankAccount account, in double amount, out string transactionDetails)
    {
        if (amount <= 0)
        {
            transactionDetails = "Invalid withdrawal amount.";
            return false;
        }
        if (amount > account.Balance)
        {
            transactionDetails = "Insufficient balance.";
            return false;
        }
        
        account.Balance -= amount;
        transactionDetails = $"Withdraw amount: " + amount + ", new balance: " + account.Balance;
        return true;
    }

    public static void Transfer(ref BankAccount fromAccount, ref BankAccount toAccount, in double amount, out string transactionDetails)
    {
        if (!Withdraw(ref fromAccount, amount, out transactionDetails))
        {
            return;
        }

        Deposit(ref toAccount, amount, fromAccount.Currency, out transactionDetails);
        transactionDetails = $"Transfer amount: " + amount + ", new first balance: " + fromAccount.Balance + ", new second balance: " + toAccount.Balance;
    }
}

static class CurrencyConverter
{
    public static double Convert(in double amount, in string fromCurrency, in string toCurrency)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid amount.");
            return 0;
        }

        switch (fromCurrency)
        {
            case "USD":
                switch (toCurrency)
                {
                    case "EUR":
                        return amount / 0.92;
                    case "AMD":
                        return amount * 392;
                    default:
                        Console.WriteLine("Entered currency not available.");
                        break;
                }

                break;
            
            case "EUR":
                switch (toCurrency)
                {
                    case "USD":
                        return amount * 1.08;
                    case "AMD":
                        return amount * 430;
                    default:
                        Console.WriteLine("Entered currency not available.");
                        break;
                }

                break;
            
            case "AMD":
                switch (toCurrency)
                {
                    case "USD":
                        return amount * 0.0025;
                    case "EUR":
                        return amount * 0.0025;
                    default:
                        Console.WriteLine("Entered currency not available.");
                        break;
                }

                break;
        }

        return 0;
    }
}