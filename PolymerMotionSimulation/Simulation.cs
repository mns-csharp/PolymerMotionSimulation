using System;

namespace PolymerMotionSimulation
{
    public class Simulation
    {
        public static void SimulateMotion(PolymerChain polymerChain, int iterations)
        {
            Random random = new Random();
            for (int i = 0; i < iterations; i++)
            {
                // select a random bead from the chain.
                int index = random.Next(0, polymerChain.MaxCapacity-1);
                Bead bead = polymerChain[index];
                
                // calculate its potential
                double potentialBefore = polymerChain.GetPotential(bead);                
                
                // propose a new location for the chosed bead.
                Point2d newLocation = bead.GetRandomPoint(polymerChain.BeadDistance);
                
                // obtain new potential of the bead.
                double potentialAfter = polymerChain.GetPotential(newLocation);

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

