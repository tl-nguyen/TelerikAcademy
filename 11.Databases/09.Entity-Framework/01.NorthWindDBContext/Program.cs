using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NorthWindDBContext
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new NorthwindEntities();
            var categories = dbContext.Categories;

            foreach (var cat in categories)
            {
                Console.WriteLine(cat.CategoryName);
            }

        }
    }
}
