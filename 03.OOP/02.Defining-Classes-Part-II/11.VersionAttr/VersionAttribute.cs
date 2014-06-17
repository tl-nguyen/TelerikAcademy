using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
class VersionAttribute : System.Attribute
{
    public int Major { get; private set; }
    public int Minor { get; private set; }

    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }

    public override string ToString()
    {
        return this.Major + "." + this.Minor;
    }
}

