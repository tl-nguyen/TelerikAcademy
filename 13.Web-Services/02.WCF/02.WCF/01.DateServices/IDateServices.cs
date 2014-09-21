namespace _01.DateServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    [ServiceContract]
    public interface IDateServices
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}