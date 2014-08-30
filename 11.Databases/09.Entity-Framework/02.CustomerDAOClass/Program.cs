using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.NorthWindDBContext;

namespace _02.CustomerDAOClass
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerDAO.Create(new Customer
                {
                    CustomerID = "GOSHO",
                    ContactName = "Gosho 123",
                    Address = "Mladost 1",
                    City = "Sofia",
                    CompanyName = "Telerik",
                    ContactTitle = "Programist",
                    Country = "Bulgaria",
                    Phone = "43243242324",
                    Region = "sofia",
                    PostalCode = "1000",
                    Fax = "111111111111"
                });

            CustomerDAO.Update(new Customer
                {
                    CustomerID = "GOSHO",
                    ContactName = "Gosho Goshov"
                });

            CustomerDAO.Delete(new Customer
                {
                    CustomerID = "GOSHO"
                });
        }
    }
}
