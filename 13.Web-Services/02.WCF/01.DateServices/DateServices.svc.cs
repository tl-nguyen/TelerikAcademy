namespace _01.DateServices
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.Threading;

    public class DateServices : IDateServices
    {
        public string GetDayOfWeek(DateTime date)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

            var result = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(date.DayOfWeek);
            return result;
        }
    }
}
