using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FindProductsByString
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using(dbCon)
            {
                Console.Write("Enter ur product : ");
                string input = Console.ReadLine();
                string query = "SELECT ProductName FROM Products WHERE ProductName LIKE @input";
                SqlCommand cmdCount = new SqlCommand(query, dbCon);
                cmdCount.Parameters.AddWithValue("@input", "%" + input + "%");
                SqlDataReader reader = cmdCount.ExecuteReader();

                using (reader)
                {
                    while(reader.Read())
                    {
                        Console.WriteLine(reader["ProductName"].ToString());
                    }
                }
            }
        }
    }
}
