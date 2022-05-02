using PolymerMotionSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymerMotionSimulationConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            PolymerChain polymerChain = new PolymerChain(Global.PolymerSize_N, Global.MaxAtomDist);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                int selectedIndx = Global.Random.Next(0, polymerChain.Count);

                Bead randomBead = polymerChain[selectedIndx];
                
                Point2d previousLoc = new Point2d(randomBead.Location.X, randomBead.Location.Y);
                double previousPot = polymerChain.GetPotential(randomBead);

                Point2d newLocation = randomBead.GetRandomPoint(polymerChain.BeadDistance);
                randomBead.SetLocation(newLocation);
                double afterPot = polymerChain.GetPotential(newLocation);

                double energyDiff = afterPot - previousPot;

                string sectionExecuted = "";
                if (energyDiff < 0)
                {
                    sectionExecuted = "A";
                }
                else
                {
                    double randomDouble = Global.Random.NextDouble();

                    double monteCarlo = Math.Exp((-1) * (energyDiff) / (Global.Temperature_T));

                    if (monteCarlo > randomDouble)
                    {
                        sectionExecuted = "B";
                    }
                    else
                    {
                        ///////////////////////////////////////////////////////
                        randomBead.SetLocation(previousLoc);
                        sectionExecuted = "C";
                        ////////////////////////////////////////////////////////
                    }
                }

                sb.AppendFormat("{0,3}\t{1,3}\t{2,20}\t{3,30}\t{4,30}\t{5}\t{6,20}\t{7}\n", i, selectedIndx, randomBead.ToString(), previousPot, afterPot, sectionExecuted, polymerChain.GetTotalPotential(), polymerChain.ToString());
                Console.WriteLine(sb.ToString());
                TextWriter.Write("polymer_data.txt", sb.ToString());
                sb.Clear();
            }

            Console.ReadKey();
        }
    }
}
