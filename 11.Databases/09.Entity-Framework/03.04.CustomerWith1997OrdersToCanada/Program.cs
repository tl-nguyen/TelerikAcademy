using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.NorthWindDBContext;

namespace _03.CustomerWith1997OrdersToCanada
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomersWithOrders(1997, "Canada");
            CustomersWithOrdersNativeSQL("1997", "Canada");
        }

        private static void CustomersWithOrdersNativeSQL(string orderYear, string shipCountry)
        {
            using (var ctx = new NorthwindEntities ())
            {
                var query = "SELECT 'Name: ' + c.ContactName + ' - ' + 'ShipName: ' + o.ShipName + ' - ' + 'ToAddress: '" +
                            " + o.ShipAddress + ' - ' + 'ToCountry: ' + o.ShipCountry + ' - ' + CONVERT(char, o.OrderDate) " +
                            "FROM Customers c, Orders o " +
                            "WHERE c.CustomerID = o.CustomerID AND o.ShipCountry = '{0}' AND YEAR(o.OrderDate) = '{1}'";

                var customersWithOrders = ctx.Database.SqlQuery<string>(string.Format(query, shipCountry, orderYear));

                foreach (var customer in customersWithOrders)
                {
                    Console.WriteLine(customersWithOrders);
                }
            }
        }

        private static void CustomersWithOrders(int orderYear, string shipCountry)
        {
            using (var ctx = new NorthwindEntities())
            {
                var customersWithOrders = ctx.Customers.Join(ctx.Orders,
                                                                c => c.CustomerID,
                                                                o => o.CustomerID,
                                                                (c, o) => new
                                                                {
                                                                    ContactName = c.ContactName,
                                                                    ShipName = o.ShipName,
                                                                    ShipAddress = o.ShipAddress,
                                                                    ShipCountry = o.ShipCountry,
                                                                    OrderDate = o.OrderDate
                                                                }).Where(c => c.OrderDate.Value.Year == orderYear && c.ShipCountry == shipCountry);

                foreach (var customer in customersWithOrders)
                {
                    Console.WriteLine("Name: {0} - ShipName: {1} - ToAddress: {2} - ToCountry: {3} - Date: {4}", customer.ContactName,
                                                                                                                customer.ShipName,
                                                                                                                customer.ShipAddress,
                                                                                                                customer.ShipCountry,
                                                                                                                customer.OrderDate);
                }
            }
        }

    }
}
