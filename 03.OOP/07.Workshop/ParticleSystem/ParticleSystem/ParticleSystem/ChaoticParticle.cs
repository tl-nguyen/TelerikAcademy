using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        protected Random randomGenerator;
        public MatrixCoords MaxSpeed { get; protected set; }

        public ChaoticParticle(MatrixCoords position, MatrixCoords maxSpeed, Random randomGenerator)
            : base(position, new MatrixCoords(randomGenerator.Next(0, maxSpeed.Row), randomGenerator.Next(0, maxSpeed.Col)))
        {
            this.randomGenerator = randomGenerator;
            this.MaxSpeed = maxSpeed;
        }

        protected override void Move()
        {
            this.Speed = new MatrixCoords(randomGenerator.Next(-this.MaxSpeed.Row, this.MaxSpeed.Row), randomGenerator.Next(-this.MaxSpeed.Col, this.MaxSpeed.Col));
            this.Position += this.Speed;
        }

        public override char[,] GetImage()
        {
            return new char[,]{ { '@' } };
        }
    }
}
