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
        public bool CreateAccount(BankAccount bankAccount);
        public void UpdateAccount(BankAccount bankAccount);
        public bool RemoveAccount(BankAccount bankAccount);

    }
}
