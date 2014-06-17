using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        public int TicksToLay { get; protected set; }
        private int currentStoppedTick = 0;

        public ChickenParticle(MatrixCoords position, MatrixCoords maxSpeed, Random randomGenerator, int ticksToLay)
            : base(position, maxSpeed, randomGenerator)
        {
            this.TicksToLay = ticksToLay;
        }

        public override IEnumerable<Particle> Update()
        {
            IEnumerable<Particle> producedParticles = base.Update();

            var allParticles = new List<Particle>();

            if( currentStoppedTick > 0)
            {
                allParticles.Add(new ChickenParticle(this.Position + this.Speed, this.MaxSpeed, this.randomGenerator, this.TicksToLay));
                currentStoppedTick--;
            }
            else if (this.Speed.Col % 2 == 0 && this.Speed.Row % 2 == 0)
            {
                this.currentStoppedTick = this.TicksToLay;
            }

            allParticles.AddRange(producedParticles);

            return allParticles;
        }

        protected override void Move()
        {
            if (currentStoppedTick == 0)
            {
                base.Move();
            }
        }

        public override char[,] GetImage()
        {
            return new char[,]{ { '#' } };
        }
    }
}
