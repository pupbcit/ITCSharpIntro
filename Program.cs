using System;
using System.Runtime.CompilerServices;
using System.Transactions;
using ATMCommon;
using ATMService;

namespace ITCSharpIntro
{
    internal class Program
    {
        static string[] actions = new string[] { "[1] View Balance", "[2] Withdraw", "[3] Deposit", "[4] Add", "[5] Exit" };
        static string accountNumber = string.Empty;
        static string userPin = string.Empty;
        static ATMService.ATMService atmService = new ATMService.ATMService();

        static void Main(string[] args)
        {
            Console.WriteLine("ATM");

            var accounts = atmService.GetBankAccounts();

            foreach (var account in accounts)
            {
                Console.WriteLine(account.Name);
                Console.WriteLine(account.Number);
                Console.WriteLine(account.Balance);
            }

            AddAccount();

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
                        AddAccount();
                        break;
                    case 5:
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

        private static void AddAccount()
        {
            Console.WriteLine("ADD BANKACCOUNT");
            
            Console.Write("Name");
            string accountName = Console.ReadLine();
            Console.Write("Number");
            string accountNumber = Console.ReadLine();
            Console.Write("PIN");
            string PIN = Console.ReadLine();
            Console.Write("Bank");
            string bankName = Console.ReadLine();
            Console.Write("Balance");
            double balance = Convert.ToDouble(Console.ReadLine());

            //if(atmService.AddBankAccount(accountNumber, PIN, balance, accountName, bankName))
            //{
            //    Console.WriteLine("Successfully added.");
            //}
            //else
            //{
            //    Console.WriteLine("Error when adding.");
            //}
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