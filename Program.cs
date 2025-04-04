using System;
using System.Runtime.CompilerServices;
using ATM_BusinessDataLogic;

namespace ITCSharpIntro
{
    internal class Program
    {
        static string[] actions = new string[] { "[1] View Balance", "[2] Withdraw", "[3] Deposit", "[4] Exit" };

        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME");

            int userPin = 0;

            do
            {
                Console.Write("Enter PIN: ");
                userPin = Convert.ToInt16(Console.ReadLine());

                if (!ATMServices.ValidatePIN(userPin))
                {
                    Console.WriteLine("FAILED: Incorrect PIN. Please try again.");
                }

            } while (!ATMServices.ValidatePIN(userPin));

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

        
        static void DisplayBalance()
        {
            Console.WriteLine($"AVAILABLE BALANCE: {ATMServices.balance}");
        }

        static void Withdraw()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("WITHDRAW MONEY");
            Console.WriteLine("Enter amount to WITHDRAW");
            double toWithdraw = Convert.ToDouble(GetUserInput());

            if (ATMServices.CheckAmountToWithdraw(toWithdraw))
            {
                ATMServices.UpdateBalance(Actions.Withdraw, toWithdraw);
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
            ATMServices.UpdateBalance(Actions.Deposit, toDeposit);
            DisplayBalance();
        }
    }
}