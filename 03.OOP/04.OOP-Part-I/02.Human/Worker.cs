using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Human
{
    class Worker : Human
    {
        public const int WorkDaysPerWeek = 5;
        public dynamic WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }
       
        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {

        }

        public Worker(string firstName, string lastName, dynamic weekSalary, int workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public dynamic MoneyPerHour()
        {
            return (this.WeekSalary / Worker.WorkDaysPerWeek) / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return base.ToString() + " - Money per Hour : " + this.MoneyPerHour() ;
        }
    }
}
