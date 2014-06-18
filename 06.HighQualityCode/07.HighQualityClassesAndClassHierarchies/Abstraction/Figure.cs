using System;

namespace Abstraction
{
    public abstract class Figure
    {
        public IFigureCalculate Calculator { get; set; }
        public Type Type { get; set; }

        public override string ToString()
        {
            return String.Format("I am a " + this.Type +
                ". My perimeter is {0:f2}. My surface is {1:f2}.",
                this.Calculator.CalcPerimeter(), this.Calculator.CalcSurface());
        }
    }
}
