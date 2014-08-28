using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ExcelContentReader
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
                cmd.CommandText = "SELECT Name, Score From [" + sheetName + "]";
                OleDbDataReader reader =  cmd.ExecuteReader();
                using (reader)
                {
                    while(reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];
                        Console.WriteLine("{0} - {1} points", name, score);
                    }
                }
            }
        }
    }
}
