using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NameAndDescOfCategories
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                string query = "SELECT CategoryName, Description FROM Categories";
                SqlCommand cmd = new SqlCommand(query, dbCon);

                SqlDataReader categoriesReader = cmd.ExecuteReader();
                using(categoriesReader)
                {
                    while(categoriesReader.Read())
                    {
                        string categoryName = (string)categoriesReader["CategoryName"];
                        string categoryDesc = (string)categoriesReader["Description"];
                        Console.WriteLine("Name: {0} - Description: {1}", categoryName, categoryDesc);
                    }
                }
            }
        }
    }
}
