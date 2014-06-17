using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobileDevice
{
    class Mobile
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Price { get; set; }
        public string Owner { get; set; }
        public Battery Battery { get; set; }
        public Display Display { get; set; }

        public List<Call> CallHistory { get; set; }

        public static Mobile Iphone4S = new Mobile("Iphone 4S", "Apple", "400$", "unknown", new Battery("43342fdsa", 200, 10, BatteryType.LiIon), new Display("4x1x2", 1024));

        public Mobile(string model, string manufacturer) : this(model, manufacturer, "700$", "unknown", new Battery(), new Display())
        {
        }

        public Mobile(string model, string manufacturer, string price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new List<Call>();
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void DeleteCall(int callIndex)
        {
            this.CallHistory.RemoveAt(callIndex);
        }

        public void ClearCallHistory()
        {
            while (CallHistory.Count > 0)
            { 
                CallHistory.Remove(CallHistory[0]);
            }
            
        }

        public double totalCallsPrice(double pricePerMinute)
        {
            double totalPrice = 0;

            foreach (var call in this.CallHistory)
            {
                totalPrice += call.getCallPrice(pricePerMinute);
            }

            return totalPrice;
        }

        public void DisplayCallsInfo()
        {
            if (this.CallHistory.Count == 0)
            {
                Console.WriteLine(" --- No Call Records Founded ---");
            }
            else
            {
                foreach (var call in this.CallHistory)
                {
                    Console.WriteLine(call);
                }
            }
        }

        public int GetLongestCallDuration()
        {
            int max = 0;
            int maxInd = 0;

            for (int i = 0; i < this.CallHistory.Count; i++)
            {
                if (max < this.CallHistory[i].CallDuration)
                {
                    max = this.CallHistory[i].CallDuration;
                    maxInd = i;
                }
            }

            return maxInd;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("Model : " + this.Model);
            output.AppendLine("Manufacturer : " + this.Manufacturer);
            output.AppendLine("Price : " + this.Price);
            output.AppendLine("Owner : " + this.Owner);
            output.AppendLine("Battery : " + this.Battery);
            output.AppendLine("Display : " + this.Display);
            
            return output.ToString();
        }
    }
}
