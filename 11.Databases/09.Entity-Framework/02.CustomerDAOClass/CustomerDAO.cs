using _01.NorthWindDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomerDAOClass
{
    class CustomerDAO
    {
        public static void Create(Customer customer)
        {
            using (var ctx = new NorthwindEntities())
            {
                ctx.Customers.Add(customer);
                ctx.SaveChanges();
            }
        }

        public static void Update(Customer customer)
        {
            using (var ctx = new NorthwindEntities())
            {
                var customerToUpdate = ctx.Customers.Where(c => c.CustomerID == customer.CustomerID).FirstOrDefault();

                if (customer.Address != null && customerToUpdate.Address != customer.Address)
                {
                    customerToUpdate.Address = customer.Address;
                }

                if (customer.City != null && customerToUpdate.City != customer.City)
                {
                    customerToUpdate.City = customer.City;
                }

                if (customer.CompanyName != null && customerToUpdate.CompanyName != customer.CompanyName)
                {
                    customerToUpdate.CompanyName = customer.CompanyName;
                }

                if (customer.ContactName != null && customerToUpdate.ContactName != customer.ContactName)
                {
                    customerToUpdate.ContactName = customer.ContactName;
                }

                if (customer.ContactTitle != null && customerToUpdate.ContactTitle != customer.ContactTitle)
                {
                    customerToUpdate.ContactTitle = customer.ContactTitle;
                }

                if (customer.Country != null && customerToUpdate.Country != customer.Country)
                {
                    customerToUpdate.ContactTitle = customer.ContactTitle;
                }

                ctx.SaveChanges();
            }
        }

        public static void Delete(Customer customer)
        {
            using (var ctx = new NorthwindEntities())
            {
                var customerToDelete = ctx.Customers.Where(c => c.CustomerID == customer.CustomerID).FirstOrDefault();
                ctx.Customers.Remove(customerToDelete);
                ctx.SaveChanges();
            }
        }
    }
}
