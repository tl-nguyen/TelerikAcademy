using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStringServices" in both code and config file together.
    [ServiceContract]
    public interface IStringServices
    {
        [OperationContract]
        int OccurencesCount(string first, string second);
    }
}
