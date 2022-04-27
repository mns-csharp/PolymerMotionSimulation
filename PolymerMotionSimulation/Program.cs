using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class Program
    {
        public const int polymerLength = 30;
        public const double beadDistance = GlobalConstants.Radius;
        public static PolymerChain polymerChain;
        public const int totalIterations = 1000000;
        public const int writeToFileIterations = 100;
        
        public static void Main()
        {
            polymerChain = new PolymerChain(polymerLength, beadDistance);
            Random random = new Random();
            for (int i = 0; i < polymerLength; i++)
            {
                string randomString = RandomStringGen.GetRandomString();
                polymerChain.Add(randomString);
            }

            for (int i = 0; i < (totalIterations / writeToFileIterations); i++)
            {
                Simulation.SimulateMotion(polymerChain, writeToFileIterations);
                double totalPotential = polymerChain.GetTotalPotential();
                Console.WriteLine(i + "\n");
            }
        }
    }
}
