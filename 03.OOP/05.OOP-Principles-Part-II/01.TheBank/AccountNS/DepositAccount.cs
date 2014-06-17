using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TheBank.CustomerNS;

namespace _01.TheBank.AccountNS
{
    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public void Withdraw(decimal withdrawAmount)
        {
            this.Balance -= withdrawAmount;
        }

        public override decimal CalculateInterestAmount(int months)
        {
            return base.CalculateInterestAmount(this.Balance < 1000 ? 0 : months);
        }

    }
}
