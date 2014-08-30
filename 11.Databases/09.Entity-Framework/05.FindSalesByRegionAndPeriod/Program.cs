using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.NorthWindDBContext;

namespace _05.FindSalesByRegionAndPeriod
{

    class Program
    {
        static void Main(string[] args)
        {
            FindSales("RJ", new DateTime(1997, 1, 1), new DateTime(1998, 1, 1));
        }

        private static void FindSales(string region, DateTime startDate, DateTime endDate)
        {
            using (var ctx = new NorthwindEntities())
            {
                var sales = ctx.Orders.Where(o => o.ShipRegion == region && o.OrderDate > startDate && o.OrderDate < endDate).Select(o => new {o.ShipName, o.ShipAddress, o.ShipRegion, o.OrderDate});

                foreach (var sale in sales)
                {
                    Console.WriteLine("Name: {0}, Address: {1}, Region: {2}, Date: {3}", sale.ShipName, sale.ShipAddress, sale.ShipRegion, sale.OrderDate);
                }
            }
        }
    }
}
