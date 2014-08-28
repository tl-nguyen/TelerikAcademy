using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace _10.BookStoreSqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection dbCon = new SQLiteConnection(@"Data Source=..\..\booksDb.s3db;Version=3;");

            AddBook("programming += algorithm", "Preslav Nakov", new DateTime(2000, 1, 1), "23123", dbCon);
            AddBook("programirane", "gosho", new DateTime(1900, 1, 1), "233123", dbCon);
            ListAllBooks(dbCon);
            FindBooksByName("programirane", dbCon);
        }

        private static void ListAllBooks(SQLiteConnection dbCon)
        {
            dbCon.Open();
            using (dbCon)
            {
                string query = "SELECT Title, Author, PublishDate, ISBN FROM books";
                SQLiteCommand cmd = new SQLiteCommand(query, dbCon);

                SQLiteDataReader bookReader = cmd.ExecuteReader();
                using (bookReader)
                {
                    while (bookReader.Read())
                    {
                        string title = (string)bookReader["Title"];
                        string author = (string)bookReader["Author"];
                        DateTime publishDate = (DateTime)bookReader["PublishDate"];
                        string isbn = (string)bookReader["ISBN"];

                        Console.WriteLine("Title: {0}; Author: {1}; PublishDate: {2}; ISBN: {3}", title, author, publishDate, isbn);
                    }
                }
            }
        }

        private static void AddBook(string title, string author, DateTime publishDate, string isbn, SQLiteConnection dbCon)
        {
            dbCon.Open();
            using (dbCon)
            {
                string query = "INSERT INTO books(Title, Author, PublishDate, ISBN) VALUES (@title, @author, @publishDate, @isbn)";
                SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@publishDate", publishDate);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                cmd.ExecuteNonQuery();

                Console.WriteLine("the new record is inserted");
            }
        }

        private static void FindBooksByName(string name, SQLiteConnection dbCon)
        {
            dbCon.Open();
            using (dbCon)
            {
                string query = "SELECT * FROM books WHERE title = @name";
                SQLiteCommand cmd = new SQLiteCommand(query, dbCon);
                cmd.Parameters.AddWithValue("@name", name);

                SQLiteDataReader bookReader = cmd.ExecuteReader();
                using (bookReader)
                {
                    while (bookReader.Read())
                    {
                        string title = (string)bookReader["Title"];
                        string author = (string)bookReader["Author"];
                        DateTime publishDate = (DateTime)bookReader["PublishDate"];
                        string isbn = (string)bookReader["ISBN"];

                        Console.WriteLine("Founded Books  => Title: {0}; Author: {1}; PublishDate: {2}; ISBN: {3}", title, author, publishDate, isbn);
                    }
                }
            }
        }
    }
}
