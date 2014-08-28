using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddNewProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection("Server=.\\SQLEXPRESS; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdInsertProduct = new SqlCommand(
                    "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                    "VALUES (@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", dbCon);
                cmdInsertProduct.Parameters.AddWithValue("@productName", "Bunny");
                cmdInsertProduct.Parameters.AddWithValue("@supplierId", 1);
                cmdInsertProduct.Parameters.AddWithValue("@categoryId", 1);
                cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", "10 boxes");
                cmdInsertProduct.Parameters.AddWithValue("@unitPrice", 10.0);
                cmdInsertProduct.Parameters.AddWithValue("@unitsInStock", 30);
                cmdInsertProduct.Parameters.AddWithValue("@unitsOnOrder", 1);
                cmdInsertProduct.Parameters.AddWithValue("@reorderLevel", 10);
                cmdInsertProduct.Parameters.AddWithValue("@discontinued", 0);

                cmdInsertProduct.ExecuteNonQuery();
                SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
                int insertedProductId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();

                Console.WriteLine("The ProductID for the inserted product = {0}", insertedProductId);
            }
        }
    }
}
