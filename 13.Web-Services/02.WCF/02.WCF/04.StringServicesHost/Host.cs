namespace _04.StringServicesHost
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;
    using System.ServiceModel.Description;

    using _03.StringServices;

    class Host
    {
        static void Main(string[] args)
        {
            var url = "http://127.0.0.1:1234";

            var behavior = new ServiceMetadataBehavior();

            behavior.HttpGetEnabled = true;

            ServiceHost host = new ServiceHost(typeof(StringServices), new Uri(url));

            host.Description.Behaviors.Add(behavior);
            host.Open();

            Console.ReadKey();

            host.Close();
        }
    }
}
