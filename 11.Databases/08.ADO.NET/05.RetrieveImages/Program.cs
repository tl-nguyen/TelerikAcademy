using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RetrieveImages
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);
                var reader = command.ExecuteReader();

                using(reader)
                {
                    while (reader.Read())
                    {
                        byte[] rawContents = (byte[])reader["Picture"];
                        string fileName = @"..\..\" + reader["CategoryName"].ToString().Replace("/", "_") + ".jpg";
                        WriteBinaryFile(fileName, rawContents);
                    }
                }

                Console.WriteLine("Images saved successfully!");
            }
        }

        private static void WriteBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }
    }
}
