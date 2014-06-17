using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.MobileDevice
{
    class Display
    {
        public string Size { get; set; }
        public int NumberOfColors { get; set; }

        public Display() : this("2x2x2", 256)
        {
        }

        public Display(string size, int numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public override string ToString()
        {
            return String.Format("Size = {0} | Colors = {1}", this.Size, this.NumberOfColors);
        }
    }
}
