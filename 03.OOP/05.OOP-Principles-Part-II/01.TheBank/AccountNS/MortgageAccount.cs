using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TheBank.CustomerNS;

namespace _01.TheBank.AccountNS
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer is IndividualCustomer)
            {
                return base.CalculateInterestAmount(months <= 6 ? 0 : months);
            }
            else
            {
                return base.CalculateInterestAmount(months <= 12 ? months/2 : months); ;
            }
        }
    }
}
