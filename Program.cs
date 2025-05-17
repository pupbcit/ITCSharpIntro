using System;
using System.Runtime.CompilerServices;
using System.Transactions;
using ATMService;

namespace ITCSharpIntro
{
    internal class Program
    {
        static string[] actions = new string[] { "[1] View Balance", "[2] Withdraw", "[3] Deposit", "[4] Exit" };
        static string accountNumber = string.Empty;
        static string userPin = string.Empty;
        static ATMService.ATMService atmService = new ATMService.ATMService();

        static void Main(string[] args)
        {
            Console.WriteLine("ATM");


            do
            {
                Console.Write("Enter Account Number: ");
                accountNumber = Console.ReadLine();

                Console.Write("Enter PIN: ");
                userPin = Console.ReadLine();

                if (!atmService.ValidateAccount(accountNumber, userPin))
                {
                    Console.WriteLine("FAILED: Incorrect Number or PIN. Please try again.");
                }

            } while (!atmService.ValidateAccount(accountNumber, userPin));

            DisplayActions();
            double userInput = GetUserInput();

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

        static double GetUserInput() //method with return value
        {
            Console.Write("[User Input]: ");
            double userInput = Convert.ToDouble(Console.ReadLine());

            return userInput;
        }


        static void DisplayBalance()
        {
            Console.WriteLine($"AVAILABLE BALANCE: {atmService.GetAccountBalance(accountNumber, userPin)}");
        }

        static void Withdraw()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("WITHDRAW MONEY");
            Console.WriteLine("Enter amount to WITHDRAW");
            double toWithdraw = Convert.ToDouble(GetUserInput());

            if (atmService.CheckAmountToWithdraw(toWithdraw))
            {
                atmService.UpdateBalance(Actions.Withdraw, toWithdraw, accountNumber, userPin);
            }
            else
            {
                Console.WriteLine("ERROR: Either balance is insufficient or you need to enter amount 500 and above.");
            }

            DisplayBalance();
        }

        static void Deposit()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("DEPOSIT MONEY");
            Console.WriteLine("Enter amount to DEPOSIT");
            double toDeposit = Convert.ToDouble(GetUserInput());
            atmService.UpdateBalance(Actions.Deposit, toDeposit, accountNumber, userPin);
            DisplayBalance();
        }
    }
}