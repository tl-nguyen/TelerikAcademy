using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TheBank.AccountNS;
using _01.TheBank.CustomerNS;

namespace _01.TheBank
{
    class Test
    {
        public static void Main()
        {
            Bank myBank = new Bank("CoolBank");
            List<Account> accounts = new List<Account>()
            {
                new MortgageAccount(new IndividualCustomer("Pesho"), 300, (decimal)0.9),
                new DepositAccount(new CompanyCustomer("Microsoft"), 2000000000, (decimal)1.2),
                new LoanAccount(new CompanyCustomer("Telerik"), 5000000, (decimal)1.2)
            };

            myBank.Accounts.AddRange(accounts);

            Console.WriteLine(myBank);

            foreach (var account in myBank.Accounts)
            {
                account.CalculateInterestAmount(6);
            }
        }
    }
}
