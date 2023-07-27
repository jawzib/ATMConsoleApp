/*
Author: Jazib Muhammad 
Date: 07/18/2023
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string GetNum()
    {
        return cardNum;
    }

    public int GetPin()
    {
        return pin;
    }

    public string GetFirstName()
    {
        return firstName;
    }

    public string GetLastName()
    {
        return lastName;
    }

    public double GetBalance()
    {
        return balance;
    }

    // Setters
    public void SetNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void SetPin(int newPin)
    {
        pin = newPin;
    }

    public void SetFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void SetLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void SetBalance(double newBalance)
    {
        balance = newBalance;
    }

    static void PrintOptions()
    {
        Console.WriteLine("Please choose from one of the following options...");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Show Balance");
        Console.WriteLine("4. Exit");
    }

    static void Deposit(CardHolder currentUser)
    {
        Console.WriteLine("How much $$ would you like to deposit: ");
        double deposit = double.Parse(Console.ReadLine());
        currentUser.SetBalance(deposit + currentUser.GetBalance());
        Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.GetBalance());
    }

    static void Withdraw(CardHolder currentUser)
    {
        Console.WriteLine("How much $$ would you like to withdraw: ");
        double withdrawal = double.Parse(Console.ReadLine());
        // Check if the user has enough money
        if (currentUser.GetBalance() < withdrawal)
        {
            Console.WriteLine("Insufficient balance :(");
        }
        else
        {
            currentUser.SetBalance(currentUser.GetBalance() - withdrawal);
            Console.WriteLine("You're good to go! Thank you :)");
        }
    }

    static void Balance(CardHolder currentUser)
    {
        Console.WriteLine("Current balance: " + currentUser.GetBalance());
    }

    public static void Main(string[] args)
    {
        List<CardHolder> cardHolders = new List<CardHolder>();
        cardHolders.Add(new CardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new CardHolder("4532761841325802", 4321, "Kevin", "Durant", 150.31));
        cardHolders.Add(new CardHolder("5128381368581872", 9999, "Billy", "Jenkins", 150.31));
        cardHolders.Add(new CardHolder("6011188364697109", 2468, "Jazib", "Muhammad", 851.84));
        cardHolders.Add(new CardHolder("34900693153147110", 4826, "Dawn", "Smith", 54.27));

        // Prompt User
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        CardHolder currentUser = null;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // Check against our db (the sample data)
                // This allows us to enumerate a list and search for certain properties and return the entire object
                currentUser = cardHolders.FirstOrDefault(a => a.GetNum() == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // Check against our db (the sample data)
                // This allows us to enumerate a list and search for certain properties and return the entire object
                if (currentUser.GetPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.GetFirstName() + " :)");
        int option = 0;
        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1)
            {
                Deposit(currentUser);
            }
            else if (option == 2)
            {
                Withdraw(currentUser);
            }
            else if (option == 3)
            {
                Balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4); // 4 is the exit key as mentioned earlier
        Console.WriteLine("Thank you! Have a nice day :)");
    }
}
