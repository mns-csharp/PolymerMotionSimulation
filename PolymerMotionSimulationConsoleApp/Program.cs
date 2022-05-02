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
            PolymerChain chain = new PolymerChain(Global.PolymerSize_N, Global.MaxAtomDist);
            chain.LoadBeadsToPolymer();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 100; i++)
            {
                int index = Global.Random.Next(0, chain.Count);// obtain a random index
                Bead bead = chain[index];//obtain a random bead from the index

                Point2d previousLoc = new Point2d(bead.Location.X, bead.Location.Y);//copy the point
                double previousPot = chain.GetPotential(bead);//get the existing bead potential

                Point2d newLocation = bead.GetRandomPoint(chain.BeadDistance);//get a new point at a distance
                chain.MoveBead(index, newLocation);//move the bead to the new position
                double afterPot = chain.GetPotential(newLocation);//get the potential of the new position

                double energyDiff = afterPot - previousPot;//difference

                string sectionExecuted = "";
                if (energyDiff < 0)
                {
                    sectionExecuted = "Y";
                }
                else
                {
                    double randomDouble = Global.Random.NextDouble();

                    double monteCarlo = Math.Exp((-1) * (energyDiff) / (Global.Temperature_T));

                    if (monteCarlo > randomDouble)
                    {
                        sectionExecuted = "Y";
                    }
                    else
                    {
                        ///////////////////////////////////////////////////////
                        chain.MoveBead(index, previousLoc);
                        sectionExecuted = "N";
                        ////////////////////////////////////////////////////////
                    }
                }

                sb.AppendFormat("{0,3}\t{1,3}\t{2,20}\t{3,30}\t{4,30}\t{5}\t{6,20}\t{7}\n", i, index, bead.ToString(), previousPot, afterPot, sectionExecuted, chain.GetTotalPotential(), chain.ToString());
                Console.WriteLine(sb.ToString());
                TextWriter.Write("polymer_data.txt", sb.ToString());
                sb.Clear();
            }

            //PolymerChain chain = new PolymerChain();
            //chain.Capacity = 4;
            //chain.BeadDistance = 3.8;
            //
            //for (int i = 0; i < 100; i++)
            //{
            //    chain.InitializeBeads();
            //    chain.Print();
            //}            

            Console.ReadKey();
        }
    }
}
