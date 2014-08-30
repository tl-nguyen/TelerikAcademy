using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.NorthWindDBContext;

namespace _10.SPTotalIncomeOfSupplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalIncome = TotalIncomeOfSupplier("Tokyo Traders", new DateTime(1995, 1, 1), new DateTime(2014, 1, 1));

            Console.WriteLine("total income : {0}", totalIncome);
        }

        private static decimal? TotalIncomeOfSupplier(string supplierName, DateTime startDate, DateTime endDate)
        {
            using (var ctx = new NorthwindEntities())
            {
                var totalIncome = ctx.usp_totalIncomeOfSupplier(supplierName, startDate, endDate).First();

                return totalIncome;
            }
        }
    }
}
