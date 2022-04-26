using System;

namespace PolymerSimulation__from__python
{
    public class SimulationContrioller
    {
        public static void SimulateMotion(PolymerChain polymerChain)
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                // select a random bead from the chain.
                int index = random.Next(0, polymerChain.MaxCapacity-1);
                Bead bead = polymerChain[index];
                Bead leftBead = null;
                Bead rightBead = null;
                
                // calculate its harmonic potential
                double potentialBefore = 0;

                try
                { 
                    leftBead = polymerChain[index - 1];
                    potentialBefore += bead.GetHarmonicPotential(leftBead);
                }
                catch {}

                try
                {
                    rightBead = polymerChain[index + 1];
                    potentialBefore += bead.GetHarmonicPotential(rightBead);
                }
                catch {}
                
                // propose a new location for the chosed bead.
                Point2d newLocation = Point2d.GetRandomPoint(bead.Location, polymerChain.BeadDistance);
                
                // obtain old potential of the bead.
                double potentialAfter = bead.GetPairPotential(newLocation);

                if (potentialBefore > potentialAfter)
                {
                    //move to new location
                    bead.SetLocation(newLocation);
                }
                else
                {
                    //apply monte carlo condition
                    Random monteRandom = new Random();
                    double randDouble = monteRandom.NextDouble();

                    if (Math.Exp(-(potentialAfter - potentialBefore) / GlobalConstants.Temperature_T) > randDouble)
                    {
                        //move to new location
                        bead.SetLocation(newLocation);
                    }
                    else
                    {
                        //do nothing
                    }
                }
            }
        } 
    }
}

