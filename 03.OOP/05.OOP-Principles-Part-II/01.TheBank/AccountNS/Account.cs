using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TheBank.CustomerNS;

namespace _01.TheBank.AccountNS
{
    public abstract class Account
    {
        public Customer Customer { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal InterestRate { get; protected set; }

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public void Deposit(decimal depositAmount)
        {
            this.Balance += depositAmount;
        }

        public virtual decimal CalculateInterestAmount(int months)
        {
            if (months < 0) throw new ArgumentException("Months can not be negative number");

            decimal result = months * this.InterestRate;

            Console.WriteLine("The Interest Amount of {0} = {1}",this.Customer.Name, result);

            return result;
        }

        public override string ToString()
        {
            return String.Format("{4} \n- Account Type: {3} \n- Customer Type: {0} \n- Balance : {1} \n- InterestRate : {2}", 
                        this.Customer.GetType().Name, 
                        this.Balance, 
                        this.InterestRate,
                        this.GetType().Name,
                        this.Customer.Name);
        }
    }
}
