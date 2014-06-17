using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobileDevice
{
    class Call
    {
        public DateTime CallDateTime { get; set; }
        public string DialedNumber { get; set; }
        public int CallDuration { get; set; }

        public Call(string dialedNumber) : this(DateTime.Now, dialedNumber, 0 )
        {
        }

        public Call(string dialedNumber, int callDuration) : this(DateTime.Now, dialedNumber, callDuration)
        {
        }

        public Call(DateTime callDateTime, string dialedNumber, int callDuration)
        {
            this.CallDateTime = callDateTime;
            this.DialedNumber = dialedNumber;
            this.CallDuration = callDuration;
        }

        public double getCallPrice(double pricePerMinute)
        {
            return ((double)this.CallDuration / 60) * pricePerMinute;
        }

        public override string ToString()
        {
            return String.Format("Call Date Time = {0} | Dialed Number = {1} | Call Duration = {2}", 
                                    this.CallDateTime, 
                                    this.DialedNumber, 
                                    this.CallDuration);
        }
    }
}
