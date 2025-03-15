using System;
using System.Runtime.CompilerServices;

namespace ITCSharpIntro
{
    internal class Program
    {
        static string[] actions = new string[] { "[1] View Balance", "[2] Withdraw", "[3] Deposit", "[4] Exit" };
        static double balance = 10000.0;

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME");

            int pin = 1234;
            int userPin = 0;

            do
            {
                Console.Write("Enter PIN: ");
                userPin = Convert.ToInt16(Console.ReadLine());

                if (userPin != pin)
                {
                    Console.WriteLine("FAILED: Incorrect PIN. Please try again.");
                }

            } while (userPin != pin);

            DisplayActions();
            int userInput = GetUserInput();

            while (userInput != 4)
            {
                switch (userInput)
                {
                    case 1:
                        DisplayBalance();
                        break;
                    case 2:
                        Withdraw();
                        break;
                    case 3:
                        Deposit();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Incorrect. Please enter between 1-4 only.");
                        break;
                }
                DisplayActions();
                userInput = GetUserInput();
            }

        }

        static void DisplayActions() //simple method -- no return, no parameter
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("ATM MENU");

            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserInput() //method with return value
        {
            Console.Write("[User Input]: ");
            int userInput = Convert.ToInt16(Console.ReadLine());

            return userInput;
        }

        static void UpdateBalance(int userAction, double amount) //method parameter 
        {
            if (userAction == 2) //withdraw
            {
                if (amount <= balance)
                {
                    balance -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient balance. Please enter smaller amount.");
                }
            }

            if (userAction == 3) //deposit
            {
                balance += amount;
            }
        }

        static void DisplayBalance()
        {
            Console.WriteLine($"AVAILABLE BALANCE: {balance}");
        }

        static void Withdraw()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("WITHDRAW MONEY");
            Console.WriteLine("Enter amount to WITHDRAW");
            double toWithdraw = Convert.ToDouble(GetUserInput());

            UpdateBalance(2, toWithdraw);
            DisplayBalance();
        }

        static void Deposit()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("DEPOSIT MONEY");
            Console.WriteLine("Enter amount to DEPOSIT");
            double toDeposit = Convert.ToDouble(GetUserInput());
            UpdateBalance(3, toDeposit);
            DisplayBalance();
        }
    }
}