
using ATMCommon;
using System;
using System.Security.Principal;

namespace ATMDataService
{
    public class TextFileDataService : IBankDataService
    {
        string filePath = "accounts.txt";
        List<BankAccount> bankAccounts = new List<BankAccount>();

        public TextFileDataService()
        {
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                bankAccounts.Add(new BankAccount
                {
                    Name = parts[0],
                    Number = parts[1],
                    Bank = parts[2],
                    Balance = Convert.ToDouble(parts[3]),
                    PIN = parts[4],
                });
            }
        }

        private void WriteDataToFile()
        {
            var lines = new string[bankAccounts.Count];

            for (int i = 0; i < bankAccounts.Count; i++)
            {
                lines[i] = $"{bankAccounts[i].Name}|{bankAccounts[i].Number}|{bankAccounts[i].Bank}|{bankAccounts[i].Balance}|{bankAccounts[i].PIN}";
            }

            File.WriteAllLines(filePath, lines);
        }

        public int FindIndex(BankAccount account)
        {
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                if (bankAccounts[i].Number == account.Number)
                {
                    return i;
                }
            }

            return -1;
        }

        public List<BankAccount> GetAccounts()
        {
            return bankAccounts;
        }

        public void CreateAccount(BankAccount bankAccount)
        {
            var newLine = $"{bankAccount.Name}|{bankAccount.Number}|{bankAccount.Bank}|{bankAccount.Balance}|{bankAccount.PIN}";

            File.AppendAllText(filePath, newLine);
        }

        public void UpdateAccount(BankAccount account)
        {
            int index = FindIndex(account);

            bankAccounts[index].Name = account.Name;
            bankAccounts[index].Balance = account.Balance;

            WriteDataToFile();

        }

        public void RemoveAccount(BankAccount account)
        {
            int index = -1;
            for (int i = 0; i < bankAccounts.Count; i++)
            {
                if (bankAccounts[i].Number == account.Number)
                {
                    index = i;
                }
            }

            bankAccounts.RemoveAt(index);

            WriteDataToFile();
        }
    }
}
