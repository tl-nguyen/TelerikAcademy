using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.TheBank.AccountNS;

namespace _01.TheBank
{
    public class Bank
    {
        public List<Account> Accounts { get; private set; }
        public string Name { get; private set; }

        public Bank(string name)
        {
            this.Accounts = new List<Account>();
            this.Name = name;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(String.Format("<<<<< {0} >>>>>\n", this.Name));

            foreach (var account in this.Accounts)
            {
                output.AppendLine(account.ToString());
            }

            return output.ToString();
        }
    }
}
