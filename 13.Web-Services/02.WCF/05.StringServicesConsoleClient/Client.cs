using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.StringServicesConsoleClient
{
    class Client
    {
        static void Main(string[] args)
        {
            var client = new StringServiceRef.StringServicesClient();
            var count = client.OccurencesCount("bla", "bla");

            Console.WriteLine(count);
        }
    }
}
