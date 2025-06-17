using ATMCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        ATMService.ATMService atmService = new ATMService.ATMService();

        [HttpGet]
        public IEnumerable<BankAccount> GetUsers()
        {
            var accounts = atmService.GetBankAccounts();

            return accounts;
        }

        [HttpPatch("withdraw")]
        public bool Withdraw(double amountToWithdraw, string accountNumber, string PIN)
        {
            var actions = ATMService.Actions.Withdraw;
            
            var result = atmService.UpdateBalance(actions, amountToWithdraw, accountNumber, PIN);

            return result;
        }

        [HttpPatch("deposit")]
        public bool Deposit(double amountToDeposit, string accountNumber, string PIN)
        {
            var actions = ATMService.Actions.Deposit;
           
            var result = atmService.UpdateBalance(actions, amountToDeposit, accountNumber, PIN);

            return result;
        }

        [HttpDelete]
        public bool RemoveBankAccount(string accountNumber, string PIN)
        {
            return atmService.DeleteBankAccount(accountNumber, PIN);
        }

        [HttpPost]
        public bool AddBankAccount(BankAccount request)
        {
            return atmService.AddBankAccount(request.Number, request.Name, request.PIN, request.Balance, request.Bank);
        }

    }
}
