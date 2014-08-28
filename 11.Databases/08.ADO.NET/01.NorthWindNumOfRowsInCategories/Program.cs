using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NorthWindNumOfRowsInCategories
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using(dbCon)
            {
                string query = "SELECT COUNT(*) FROM Categories";
                SqlCommand cmdCount = new SqlCommand(query, dbCon);

                int categoriesCount = (int)cmdCount.ExecuteScalar();

                Console.WriteLine("Number of Categories = {0}", categoriesCount);
            }
        }
    }
}
