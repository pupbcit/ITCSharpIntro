using ATMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataService
{
    public class InMemoryDataService : IBankDataService
    {
        List<BankAccount> accounts = new List<BankAccount>();
        public InMemoryDataService()
        {
            CreateDummyBankAccounts();
        }
        private void CreateDummyBankAccounts()
        {
            BankAccount account1 = new BankAccount();
            account1.Name = "Indaleen Quinsayas";
            account1.Number = "000-111-222";
            account1.PIN = "1111";
            account1.Balance = 110000;
            account1.Bank = "BPI";

            accounts.Add(account1);

            BankAccount account2 = new BankAccount
            {
                Name = "Juan Dela Cruz",
                Number = "111-222-333",
                PIN = "123456",
                Balance = 5000,
                Bank = "LandBank"
            };

            accounts.Add(account2);

            accounts.Add(new BankAccount
            {
                Name = "Maria Dela Cruz",
                Number = "111-111-111",
                PIN = "1234",
                Balance = 15000,
                Bank = "LandBank"
            });

            accounts.Add(new BankAccount
            {
                Name = "Ana Garcia",
                Number = "555-555-555",
                PIN = "999",
                Balance = 25000,
                Bank = "BPI"
            });
        }
        public bool CreateAccount(BankAccount bankAccount)
        {
            return true;
        }

        public List<BankAccount> GetAccounts()
        {
            return accounts;
        }

        public bool RemoveAccount(BankAccount bankAccount)
        {
            return true;
            
        }

        public void UpdateAccount(BankAccount bankAccount)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Number == bankAccount.Number)
                {
                    accounts[i].Balance = bankAccount.Balance;
                }
            }
        }
    }
}
