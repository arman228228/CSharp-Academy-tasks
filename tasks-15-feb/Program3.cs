using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            BankAccount userBank = new BankAccount();

            Console.WriteLine("Creating bank account. Enter details:\n");

            Console.WriteLine("Enter account number:");
            userBank.AccountNumber = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter holder name:");
            userBank.HolderName = Console.ReadLine();
            
            Console.WriteLine("Enter default balance:");
            userBank.Balance = int.Parse(Console.ReadLine());

            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine("Enter 0 - for deposit, 1 - for withdrawal, 2 - for exit");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        while (true)
                        {
                            Console.WriteLine("Enter sum for deposit, or enter \"0\" for exit");

                            int sum = int.Parse(Console.ReadLine());

                            if (sum == 0)
                            {
                                Console.WriteLine("Process canceled");
                                break;
                            }

                            if (userBank.Deposit(sum))
                            {
                                Console.WriteLine("Successful deposit." + " New balance: " + userBank.Balance);
                                break;
                            }
                        }

                        break;
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Enter sum for withdrawal, or enter \"0\" for exit");

                            int sum = int.Parse(Console.ReadLine());

                            if (sum == 0)
                            {
                                Console.WriteLine("Process canceled");
                                break;
                            }

                            if (userBank.Withdraw(sum))
                            {
                                Console.WriteLine("Successful withdraw." + " New balance: " + userBank.Balance);
                                break;
                            }
                        }

                        break;
                    case 2:
                        exit = true;
                        Console.WriteLine("Exit program");
                        break;
                    default:
                        Console.WriteLine("Invalid choise. Try again");
                        break;
                }
            }
        }
    }

    class BankAccount
    {
        public int AccountNumber;
        public string HolderName;
        public int Balance;

        public bool Deposit(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Balance limit");
                return false;
            }

            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Negative number is not correct");
                return false;
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("Balance cannot go less than zero");
                return false;
            }

            Balance -= amount;
            return true;
        }
    }
}