using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.NorthWindDBContext;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace _06.NorthwindTwin
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new NorthwindEntities())
            {
                var cloneNorthwindQuery = ((IObjectContextAdapter)ctx).ObjectContext.CreateDatabaseScript();

                var createDBQuery = "CREATE DATABASE NorthwindTwin";

                var createDbConn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=master;Integrated Security=true");

                createDbConn.Open();
                using (createDbConn)
                {
                    var createDBCommand = new SqlCommand(createDBQuery, createDbConn);
                    createDBCommand.ExecuteNonQuery();

                    var cloneDbConn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=NorthwindTwin;Integrated Security=true");

                    cloneDbConn.Open();
                    using (cloneDbConn)
                    {
                        var cloneDBCommand = new SqlCommand(cloneNorthwindQuery, cloneDbConn);
                        cloneDBCommand.ExecuteNonQuery();

                        Console.WriteLine("Successfully created NorthwindTwin DB");
                    }
                }
            }
        }
    }
}
