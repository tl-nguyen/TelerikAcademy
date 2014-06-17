using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Version(2, 5)]
class TestClass
{
    public static void Main()
    {
        Type type = typeof(TestClass);
        object[] allAttributes = type.GetCustomAttributes(false);

        foreach (VersionAttribute version in allAttributes)
        {
            Console.WriteLine(
              "This class's version is {0}. ", version);
        }
    }
}

