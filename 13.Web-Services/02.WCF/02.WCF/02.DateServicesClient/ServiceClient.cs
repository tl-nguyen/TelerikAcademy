using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DateServicesClient
{
    class ServiceClient
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference.DateServicesClient();

            Console.WriteLine(client.GetDayOfWeek(DateTime.Now));
        }
    }
}
