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

        public bool UpdateBalance(Actions userAction, double amount, string accountNumber)
        {
            double balance = bankDataService.GetAccountBalance(accountNumber);

            if (userAction == Actions.Withdraw && amount <= balance)
            {
                balance -= amount;
                bankDataService.UpdateAccountBalance(accountNumber, balance);

                return true;
            }

            if (userAction == Actions.Deposit)
            {
                balance += amount;
                bankDataService.UpdateAccountBalance(accountNumber, balance);

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
            return bankDataService.ValidateBankAccount(accountNumber, userPin);
        }

        public double GetAccountBalance(string accountNumber)
        {
            return bankDataService.GetAccountBalance(accountNumber);
        }
    }
}
