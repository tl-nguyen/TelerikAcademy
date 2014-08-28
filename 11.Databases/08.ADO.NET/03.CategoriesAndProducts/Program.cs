using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CategoriesAndProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                string query = "SELECT CategoryName, ProductName " + 
                                "FROM Categories c, Products p " + 
                                "WHERE c.CategoryID = p.CategoryID ORDER BY CategoryName";
                SqlCommand cmd = new SqlCommand(query, dbCon);

                SqlDataReader prodAndCatReader = cmd.ExecuteReader();
                using(prodAndCatReader)
                {
                    while(prodAndCatReader.Read())
                    {
                        string categoryName = (string)prodAndCatReader["CategoryName"];
                        string productName = (string)prodAndCatReader["ProductName"];
                        Console.WriteLine("Category: {0} - Product: {1}", categoryName, productName);
                    }
                }
            }
        }
    }
}
