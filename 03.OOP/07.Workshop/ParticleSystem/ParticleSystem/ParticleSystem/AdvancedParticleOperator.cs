using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        private List<Particle> currentTickParticles = new List<Particle>();
        private List<ParticleAttractor> currentTickAttractors = new List<ParticleAttractor>();
        private List<ParticleRepeller> currentTickRepellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialAttractor = p as ParticleAttractor;
            var potentialRepeller = p as ParticleRepeller;

            if (potentialAttractor != null && potentialAttractor is ParticleAttractor)
            {
                currentTickAttractors.Add(potentialAttractor);
            }
            else if (potentialRepeller != null && potentialRepeller is ParticleRepeller)
            {
                currentTickRepellers.Add(potentialRepeller);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }
            
            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.currentTickAttractors)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    var currParticleToAttractorVector = attractor.Position - particle.Position;

                    int pToAttrRow = currParticleToAttractorVector.Row;
                    pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

                    int pToAttrCol = currParticleToAttractorVector.Col;
                    pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

                    var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);

                    particle.Accelerate(currAcceleration);
                }
            }

            foreach (var repeller in this.currentTickRepellers)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    if (CalculateDistance(repeller.Position, particle.Position) > repeller.Radius) continue;

                    var currParticleToRepellerVector = repeller.Position + particle.Position;

                    int pToAttrRow = currParticleToRepellerVector.Row;
                    pToAttrRow = DecreaseVectorCoordToPushPower(repeller, pToAttrRow);

                    int pToAttrCol = currParticleToRepellerVector.Col;
                    pToAttrCol = DecreaseVectorCoordToPushPower(repeller, pToAttrCol);

                    var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);

                    particle.Accelerate(currAcceleration);
                }
            }

            this.currentTickParticles.Clear();
            this.currentTickAttractors.Clear();
            this.currentTickRepellers.Clear();

            base.TickEnded();
        }

        private static double CalculateDistance(MatrixCoords pos1, MatrixCoords pos2)
        {
            return Math.Sqrt(((pos1.Row - pos2.Row) * (pos1.Row - pos2.Row)) + ((pos1.Col - pos2.Col) * (pos1.Col - pos2.Col)));
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.AttractionPower)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.AttractionPower;
            }
            return pToAttrCoord;
        }

        private static int DecreaseVectorCoordToPushPower(ParticleRepeller attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.PushPower)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.PushPower;
            }
            return pToAttrCoord;
        }
    }
}
