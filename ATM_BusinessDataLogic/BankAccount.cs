using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_BusinessDataLogic
{
    public class BankAccount
    {
        private string _pin = "1234";
        public string PIN 
        {
            get { return _pin; } 
            set
            {
                if (value.Length == 4 || value.Length == 6)
                {
                    _pin = value;
                }
            }
        }

        public double Balance { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public string Bank { get; set; }
    }
}
