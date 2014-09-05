using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.InvokeToList
{
    class Program
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities ctx = new TelerikAcademyEntities();

            using (ctx)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                var isThereSofiaInTownsSlowWay = ctx.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Any(t => t.Name == "Sofia");

                Console.WriteLine("is there Sofia in towns (with ToList): {0}", isThereSofiaInTownsSlowWay);

                stopwatch.Stop();
                Console.WriteLine("Time : {0}", stopwatch.Elapsed);

                stopwatch.Reset();
                stopwatch.Start();

                var isThereSofiaInTownsFastWay = ctx.Employees.Select(e => e.Address).Select(a => a.Town).Any(t => t.Name == "Sofia");

                Console.WriteLine("is there Sofia in towns (without ToList): {0}", isThereSofiaInTownsSlowWay);
                stopwatch.Stop();
                Console.WriteLine("Time : {0}", stopwatch.Elapsed);
            }
        }
    }
}
