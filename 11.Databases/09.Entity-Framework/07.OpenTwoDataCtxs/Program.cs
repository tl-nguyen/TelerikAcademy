using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.NorthWindDBContext;

namespace _07.OpenTwoDataCtxs
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx1 = new NorthwindEntities())
            {
                using (var ctx2 = new NorthwindEntities())
                {
                    var beverageCategory = ctx1.Categories.FirstOrDefault();
                    var bevarageCategory2 = ctx2.Categories.FirstOrDefault();

                    beverageCategory.CategoryName = "BeveragesCattt";
                    bevarageCategory2.CategoryName = "Beveragesss";

                    ctx1.SaveChanges();
                    ctx2.SaveChanges();

                    Console.WriteLine(ctx1.Categories.FirstOrDefault().CategoryName);
                    Console.WriteLine(ctx2.Categories.FirstOrDefault().CategoryName);

                    //The first one called at Console.WriteLine will be the actually saved one in the db ( optimistic concurency )
                }
            }
                
        }
    }
}
