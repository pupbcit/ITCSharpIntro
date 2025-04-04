using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ATM_BusinessDataLogic
{
    public class ATMProcess
    {
        public static double balance = 10000.0;
        static int pin = 1234;
        static double minWithdrawAmount = 500;

        public static bool UpdateBalance(Actions userAction, double amount)
        {
            if (userAction == Actions.Withdraw && amount <= balance)
            {
                balance -= amount;
                return true;
            }

            if (userAction == Actions.Deposit)
            {
                balance += amount;
                return true;
            }

            return false;
        }

        public static bool CheckAmountToWithdraw(double amount)
        {
            return amount >= minWithdrawAmount && amount <= balance;
        }

        public static bool ValidatePIN(int userPin)
        {
            return userPin == pin;
        }
    }
}
