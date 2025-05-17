using ATMCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMDataService
{
    public interface IBankDataService
    {
        public List<BankAccount> GetAccounts();
        public void CreateAccount(BankAccount bankAccount);
        public void UpdateAccount(BankAccount bankAccount);
        public void RemoveAccount(BankAccount bankAccount);

    }
}
