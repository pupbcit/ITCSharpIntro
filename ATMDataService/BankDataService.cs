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

        public void AddAccount(BankAccount bankAccount)
        {
            bankDataService.CreateAccount(bankAccount);
        }

        public void UpdateAccount(BankAccount bankAccount)
        {
            bankDataService.UpdateAccount(bankAccount);
        }

        public void RemoveAccount(BankAccount bankAccount)
        {
            bankDataService.RemoveAccount(bankAccount);
        }
    }
}
