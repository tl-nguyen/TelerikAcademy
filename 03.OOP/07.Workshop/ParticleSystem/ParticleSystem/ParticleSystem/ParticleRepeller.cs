using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepeller : Particle
    {
        public int PushPower { get; protected set; }
        public double Radius;

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int pushPower, double radius) :
            base(position, speed)
        {
            this.PushPower = pushPower;
            this.Radius = radius;
        }
    }
}
