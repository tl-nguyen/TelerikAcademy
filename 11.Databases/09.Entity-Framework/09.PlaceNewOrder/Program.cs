using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.NorthWindDBContext;

namespace _09.PlaceNewOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertOrder(new Order
                {
                    CustomerID = "GREAL",
                    EmployeeID = 4,
                    ShipName = "test",
                    ShipCountry = "Bulgaria",
                    ShipAddress = "test",
                    ShipCity = "test",
                    ShipRegion = "test",
                    ShipPostalCode = "11111",
                    OrderDate = new DateTime(1999,9,9),
                    RequiredDate = new DateTime(2000, 9, 9),
                    ShippedDate = new DateTime(2000, 1, 1),
                    ShipVia = 3,
                    Freight = 14
                });
        }

        private static void InsertOrder(Order order)
        {
            using (var ctx = new NorthwindEntities())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Orders.Add(order);
                    ctx.SaveChanges();
                    transaction.Commit();
                    Console.WriteLine("The new order is inserted successfully");
                }
            }
        }
    }
}
