using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        BankAccount bankAccount = new BankAccount(1, 200);
        BankAccount bankAccount2 = new BankAccount(2, 300);

        bool c = bankAccount2 > bankAccount;
        Console.WriteLine(bankAccount - 100 + ", Check: " + c);
    
    }
}

class BankAccount
{
    int AccountNumber;
    int Balance;

    public BankAccount(int AccountNumber, int Balance)
    {
        this.AccountNumber = AccountNumber;
        this.Balance = Balance;
    }

    public int GetBalance()
    {
        return this.Balance;
    }

    public override string ToString()
    {
        return "Account: " + AccountNumber + ", Balance: " + Balance + " USD";
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        BankAccount other = obj as BankAccount;
        return other != null && AccountNumber == other.AccountNumber;
    }

    public override int GetHashCode()
    {
        return AccountNumber.GetHashCode() ^ Balance.GetHashCode();
    }

    public static BankAccount operator +(BankAccount n)
    {
        return new BankAccount(n.AccountNumber, n.Balance);
    }

    public static BankAccount operator +(BankAccount account, int deposit)
    {
        return new BankAccount(account.AccountNumber, account.Balance + deposit);
    }

    public static BankAccount operator -(BankAccount account, int withdraw)
    {
        if(account.Balance - withdraw < 0)
        {
            Console.WriteLine("Balance overdraft");
            return null;
        }
        return new BankAccount(account.AccountNumber, account.Balance - withdraw);
    }

    public static bool operator >(BankAccount account, BankAccount account2)
    {
        return account.Balance > account2.Balance;
    }

    public static bool operator <(BankAccount account, BankAccount account2)
    {
        return account.Balance < account2.Balance;
    }

    public static bool operator >=(BankAccount account, BankAccount account2)
    {
        return account.Balance >= account2.Balance;
    }

    public static bool operator <=(BankAccount account, BankAccount account2)
    {
        return account.Balance <= account2.Balance;
    }
}