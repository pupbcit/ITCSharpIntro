using ATMCommon;
using System.Text.Json;

namespace ATMDataService
{
    public class JsonFileDataService : IBankDataService
    {
        static List<BankAccount> bankAccounts = new List<BankAccount>();
        static string jsonFilePath = "accounts.json";

        public JsonFileDataService()
        {
            ReadJsonDataFromFile();
        }

        private void ReadJsonDataFromFile()
        {
            string jsonText = File.ReadAllText(jsonFilePath);

            bankAccounts = JsonSerializer.Deserialize<List<BankAccount>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        private void WriteJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(bankAccounts, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(jsonFilePath, jsonString);
        }
        private int FindAccountIndex(string number, string pin)
        {
            var accounts = GetAccounts();

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].Number == number && accounts[i].PIN == pin)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool CreateAccount(BankAccount bankAccount)
        {
            bankAccounts.Add(bankAccount);
            WriteJsonDataToFile();
            return true;
        }

        public List<BankAccount> GetAccounts()
        {
            return bankAccounts;
        }

        public bool RemoveAccount(BankAccount bankAccount)
        {
            var index = FindAccountIndex(bankAccount.Number, bankAccount.PIN);

            bankAccounts.RemoveAt(index);
            WriteJsonDataToFile();

            return true;

        }

        public void UpdateAccount(BankAccount bankAccount)
        {
            var index = FindAccountIndex(bankAccount.Number, bankAccount.PIN);


            bankAccounts[index].Number = bankAccount.Number;
            bankAccounts[index].Name = bankAccount.Name;
            bankAccounts[index].Bank = bankAccount.Bank;
            bankAccounts[index].Balance = bankAccount.Balance;
            bankAccounts[index].PIN = bankAccount.PIN;

            WriteJsonDataToFile();

        }
    }
}
