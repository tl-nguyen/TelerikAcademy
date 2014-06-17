using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.MobileDevice
{
    enum BatteryType
    {
        LiIon,
        NiMH,
        NiCd
    }

    class Battery
    {
        public string Model { get; set; }
        public double HoursIdle { get; set; }
        public double HoursTalk { get; set; }
        public BatteryType BatteryType { get; set; }

        public Battery() : this("zkd4b0000", 200.0, 5.0, BatteryType.NiMH) 
        { 
        }

        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public override string ToString()
        {
            return String.Format(" Model = {0} | Hours Idle = {1} | Hours Talk = {2} | Battery Type = {3}", 
                                        this.Model, 
                                        this.HoursIdle, 
                                        this.HoursTalk, 
                                        this.BatteryType);
        }
    }
}
