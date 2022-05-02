using System;

namespace PolymerMotionSimulation
{
    public class Simulation
    {
        public static void SimulateMotion(PolymerChain polymerChain, int iterations)
        {
            Random random = Global.Random;
            for (int i = 0; i < iterations; i++)
            {
                int randomIndex = random.Next(0, polymerChain.MaxCapacity-1);
                Bead randomBead = polymerChain[randomIndex];

                Point2d previousLoc = new Point2d(randomBead.Location.X, randomBead.Location.Y);
                double previousPot = polymerChain.GetPotential(randomBead);
                
                Point2d newLocation = randomBead.GetRandomPoint(polymerChain.BeadDistance);
                randomBead.SetLocation(newLocation);
                double potentialAfter = polymerChain.GetPotential(newLocation);

                double energyDifferenceDouble = potentialAfter - previousPot;

                if (energyDifferenceDouble < 0)  // e_before > e_after
                {
                    //pass
                    //stringList.Add("A");
                }
                else
                {
                    double randomDouble = Global.Random.Next();

                    double montecarlo = Math.Exp((-1) * (energyDifferenceDouble) / (Global.Temperature_T));

                    if (montecarlo > randomDouble)
                    {
                        //pass
                        //stringList.Add("B");
                    }
                    else
                    {
                        ///////////////////////////////////////////////////////
                        randomBead.SetLocation(previousLoc);
                        ////////////////////////////////////////////////////////
                    }
                }
            }
        } 
    }
}

