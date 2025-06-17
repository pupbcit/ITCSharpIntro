using ATMCommon;

namespace ATMDataService
{
    public class BankDataService
    {
        IBankDataService bankDataService;

        public BankDataService()
        {
            //bankDataService = new TextFileDataService();
            //bankDataService = new InMemoryDataService();
            //bankDataService = new JsonFileDataService();
            bankDataService = new DBDataService();

        }
        public List<BankAccount> GetAllAccounts()
        {
            return bankDataService.GetAccounts();
        }

        public bool AddAccount(BankAccount bankAccount)
        {
           return bankDataService.CreateAccount(bankAccount);
        }

        public void UpdateAccount(BankAccount bankAccount)
        {
            bankDataService.UpdateAccount(bankAccount);
        }

        public bool RemoveAccount(BankAccount bankAccount)
        {
           return bankDataService.RemoveAccount(bankAccount);
        }
    }
}
