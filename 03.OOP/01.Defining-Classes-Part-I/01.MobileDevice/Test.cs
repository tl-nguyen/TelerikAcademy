using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobileDevice
{

    class Test
    {
        public static void Main()
        {
            Console.WriteLine(">>>>>>>>>> GSMTest Class <<<<<<<<<<<");
            GSMTest.TestMobileDevices();
            Console.WriteLine("\n\n>>>>>>>>>> GSMCallHistoryTest Class <<<<<<<<<<<\n");
            GSMCallHistoryTest.TestCallHistory();
        }
    }


    class GSMTest
    {
        public static void TestMobileDevices()
        {
            Mobile[] testPhones = new Mobile[] {
                                                new Mobile("z1", "sony"),
                                                new Mobile("S4", "samsung"),
                                                new Mobile("OneX", "HTC", "800$", "me", new Battery(), new Display())
                                                };

            foreach (var phone in testPhones)
            {
                Console.WriteLine(phone);
            }

            Console.WriteLine(Mobile.Iphone4S);
        }
    }

    class GSMCallHistoryTest
    {
        public static void TestCallHistory()
        {
            Mobile testPhone = new Mobile("OneX", "HTC", "800$", "me", new Battery(), new Display());

            //populate call history
            testPhone.AddCall(new Call("012312389", 200));
            testPhone.AddCall(new Call("032112321"));
            testPhone.AddCall(new Call("044448555", 500));
            testPhone.AddCall(new Call("013332200", 20));
            testPhone.AddCall(new Call("022299222", 60));
            testPhone.AddCall(new Call("000000000"));

            Console.WriteLine("Initial values: ");
            testPhone.DisplayCallsInfo();

            Console.WriteLine("Total Calls Price = {0:0.00} $", testPhone.totalCallsPrice(0.37));

            testPhone.DeleteCall(testPhone.GetLongestCallDuration());

            Console.WriteLine("\n\nAfter removing longest call: ");
            testPhone.DisplayCallsInfo();

            Console.WriteLine("Total Calls Price = {0:0.00} $", testPhone.totalCallsPrice(0.37));

            testPhone.ClearCallHistory();
            Console.WriteLine("\n\nAfter clearing History: ");
            testPhone.DisplayCallsInfo();
        }
    }
}
