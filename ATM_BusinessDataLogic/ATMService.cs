using ATMCommon;
using ATMDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATMService
{
    public class ATMService
    {
        double minWithdrawAmount = 500;
        BankDataService bankDataService = new BankDataService();

        public bool UpdateBalance(Actions userAction, double amountToUpdate, string accountNumber, string userPin)
        {
            var bankAccount = GetBankAccount(accountNumber, userPin);

            if (userAction == Actions.Withdraw && amountToUpdate <= bankAccount.Balance)
            {
                bankAccount.Balance -= amountToUpdate;

                bankDataService.UpdateAccount(bankAccount);

                return true;
            }

            if (userAction == Actions.Deposit)
            {
                bankAccount.Balance += amountToUpdate;

                bankDataService.UpdateAccount(bankAccount);

                return true;
            }

            return false;
        }

        public bool CheckAmountToWithdraw(double amount)
        {
            return amount >= minWithdrawAmount;
        }

        public bool ValidateAccount(string accountNumber, string userPin)
        {
            var account = GetBankAccount(accountNumber, userPin);

            if (account.Number != null)
            {
                return true;
            }

            return false;
        }

        private BankAccount GetBankAccount(string accountNumber, string PIN)
        {
            var bankAccounts = bankDataService.GetAllAccounts();
            var foundAccount = new BankAccount();

            foreach (var account in bankAccounts)
            {
                if (account.Number == accountNumber && account.PIN == PIN)
                {
                    foundAccount = account;
                }
            }
            return foundAccount;
        }

        public List<BankAccount> GetBankAccounts()
        {
            return bankDataService.GetAllAccounts();
        }
        public double GetAccountBalance(string accountNumber, string PIN)
        {
            var bankAccount = GetBankAccount(accountNumber, PIN);
            return bankAccount.Balance;
        }


        public bool DeleteBankAccount(string accountNumber, string PIN)
        {
            var bankAccount = new BankAccount { Number = accountNumber, PIN = PIN };

            return bankDataService.RemoveAccount(bankAccount);
        }

        public bool AddBankAccount(string number, string name, string PIN, double balance,  string bank)
        {
            var bankAccount = new BankAccount
            {
                Number = number,
                PIN = PIN,
                Balance = balance, 
                Name = name, 
                Bank = bank
            };

            return bankDataService.AddAccount(bankAccount);
        }
    }
}
