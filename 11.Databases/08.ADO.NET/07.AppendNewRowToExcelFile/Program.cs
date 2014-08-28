using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AppendNewRowToExcelFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                       "Data Source=..\\..\\StudentsDB.xls;" +
                                       "Extended Properties=\"Excel 8.0;HDR=Yes\"";

            OleDbConnection excelConn = new OleDbConnection(connectionString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = excelConn;

            // Open connection
            excelConn.Open();
            using (excelConn)
            {
                DataTable dtExcelSchema = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null); ;

                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                cmd.CommandText = "INSERT INTO [" + sheetName + "] (Name, Score) VALUES(@name, @score)";
                cmd.Parameters.AddWithValue("@name", "Pesho");
                cmd.Parameters.AddWithValue("@score", 30);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Inserted Pesho");
            }
        }
    }
}
