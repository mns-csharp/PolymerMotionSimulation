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
                int selectedIndx = random.Next(0, polymerChain.Count-1);
                Bead randomBead = polymerChain[selectedIndx];

                Point2d previousLoc = new Point2d(randomBead.Location.X, randomBead.Location.Y);
                double previousPot = polymerChain.GetPotential(randomBead);
                
                Point2d newLocation = randomBead.GetRandomPoint(polymerChain.BeadDistance);
                randomBead.SetLocation(newLocation);
                double afterPot = polymerChain.GetPotential(newLocation);

                double energyDiff = afterPot - previousPot;

                if (energyDiff < 0)  // e_before > e_after
                {
                    //pass
                    //stringList.Add("A");
                }
                else
                {
                    double randomDouble = Global.Random.Next();

                    double monteCarlo = Math.Exp((-1) * (energyDiff) / (Global.Temperature_T));

                    if (monteCarlo > randomDouble)
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

