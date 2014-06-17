using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    public abstract class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Human(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public Human()
        {
            // TODO: Complete member initialization
        }

        public override string ToString()
        {
            return String.Format(this.FirstName + " " + this.LastName);
        }
    }
}
