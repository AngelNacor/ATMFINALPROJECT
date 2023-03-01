using System;
using System.Collections.Generic;

namespace ATM
{
    class Program
    {
        public static string Stars= "****************************************";
        public static string Star= "********";
        public static int Pin = 0629;
        public static int pin;
        public static int newpin;
        
        static void Main(string[] args)
        {
            
            double balance = 10000.0;
            
            
            List<Transaction> transactionHistory = new List<Transaction>();
            
            Message();
            
            
            while (true)
            {
               Console.WriteLine("Enter your Pin: ");
                pin=int.Parse(Console.ReadLine());
                
		if (pin == Pin)
		{
			ShowMainMenu();
		}
		else if (pin == newpin)
		{
			ShowMainMenu();
		}
		else
		{
		    Console.WriteLine("Incorrect PIN");
		}

                
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Your balance is ₱" + balance);
                        break;
                    case 2:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        balance += depositAmount;


                        Transaction depositTransaction = new Transaction(depositAmount, TransactionType.DEPOSIT);
                        transactionHistory.Add(depositTransaction);

                        Console.WriteLine("Deposit successful. New balance is ₱" + balance);
                        break;
                    case 3:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawalAmount = double.Parse(Console.ReadLine());
                        if (withdrawalAmount > balance)
                        {
                            Console.WriteLine("Insufficient funds!");
                        }
                        else
                        {
                            balance -= withdrawalAmount;


                            Transaction withdrawalTransaction = new Transaction(withdrawalAmount, TransactionType.WITHDRAWAL);
                            transactionHistory.Add(withdrawalTransaction);

                            Console.WriteLine("Withdrawal successful. New balance is ₱" + balance);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Transaction history:");
                        foreach (Transaction transaction in transactionHistory)
                        {
                            Console.WriteLine(transaction);
                        }
                        break;
                    case 5:
                        
                        Console.WriteLine("Enter New Pin: ");
                        newpin=int.Parse(Console.ReadLine());
                        
                        if (pin == newpin)
                        {
                            ShowMainMenu();
                        }
                        else
                        {
                        }
                        break;
                    case 6:
                        Console.WriteLine("Thank you for using the ATM!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    static void ShowMainMenu()
    {
        Console.WriteLine(Stars);
        Console.WriteLine(Stars);
        Console.WriteLine("Welcome to the ATM!");
        Console.WriteLine(Stars);
        Console.WriteLine(Stars);
        Console.WriteLine("1. Check balance");
        Console.WriteLine("2. Deposit");
        Console.WriteLine("3. Withdraw");
        Console.WriteLine("4. Transaction history");
        Console.WriteLine("5. Change PIN");
        Console.WriteLine("6. Exit");
        Console.WriteLine(Stars);
        Console.WriteLine("Enter your choice: ");
    }
    
    static void Message()
    {
        Console.WriteLine(Stars);
        Console.WriteLine(Stars);
        Console.WriteLine(Star+ " WELCOME TO ANGEL'S ATM " + Star);
        Console.WriteLine(Stars);
        Console.WriteLine(Stars);
    }
}

    // Transaction class to store transaction information
    class Transaction
    {
        public double Amount { get; }
        public TransactionType Type { get; }
        public DateTime Date { get; }

        public Transaction(double amount, TransactionType type)
        {
            Amount = amount;
            Type = type;
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            string typeString = (Type == TransactionType.DEPOSIT) ? "deposit" : "withdrawal";
            return Date + " - " + typeString + " ₱" + Amount;
        }
    }

    // Enum to represent transaction types
    enum TransactionType
    {
        DEPOSIT,
        WITHDRAWAL
    }
}
