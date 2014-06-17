using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TheBank.CustomerNS;

namespace _01.TheBank.AccountNS
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer is IndividualCustomer)
            {
                return base.CalculateInterestAmount(months <= 3 ? 0 : months);
            }
            else
            {
                return base.CalculateInterestAmount(months <= 2 ? 0 : months); ;
            }
        }
    }
}
