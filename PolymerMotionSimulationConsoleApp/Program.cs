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
            chain.InitializeBeads();

            StringBuilder sb = new StringBuilder();

            int index = 0;
            Bead bead = null;
            double previousPot = 0;
            double afterPot = 0;
            string IsMoved = string.Empty;

            sb.AppendFormat("{0,10}\t{1,10}\t{2,25}\t{3,25}\t{4,25}\t{5,10}\t{6,25}\t{7,25}\n", 
                "SN", "Index", "BeadLoc", "PreviousPot", "AfterPot", "IsMoved", "Total Pot", "chain");
            TextWriter.Write("polymer_data.txt", sb.ToString());

            Console.WriteLine("START");

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    index = Global.Random.Next(0, chain.Count);// obtain a random index
                    bead = chain[index];//obtain a random bead from the index

                    Point2d previousLoc = new Point2d(bead.Location.X, bead.Location.Y);//copy the point
                    previousPot = chain.GetPotential(bead);//get the existing bead potential

                    Point2d newLocation = bead.GetRandomPoint(chain.BeadDistance);//get a new point at a distance
                    chain.MoveBead(index, newLocation);//move the bead to the new position
                    afterPot = chain.GetPotential(newLocation);//get the potential of the new position

                    double energyDiff = afterPot - previousPot;//difference

                    
                    if (energyDiff < 0)
                    {
                        IsMoved = "Y";
                    }
                    else
                    {
                        double randomDouble = Global.Random.NextDouble();

                        double monteCarlo = Math.Exp((-1) * (energyDiff) / (Global.Temperature_T));

                        if (monteCarlo > randomDouble)
                        {
                            IsMoved = "Y";
                        }
                        else
                        {
                            ///////////////////////////////////////////////////////
                            chain.MoveBead(index, previousLoc);
                            IsMoved = "N";
                            ////////////////////////////////////////////////////////
                        }
                    }                    
                }

                sb.Clear();

                string prevPotStr = string.Format("{0:0.00}", previousPot);
                string aftrPotStr = string.Format("{0:0.00}", afterPot);
                string totlPotStr = string.Format("{0:0.00}", chain.GetTotalPotential());

                sb.AppendFormat("{0,10}\t{1,10}\t{2,25}\t{3,25}\t{4,25}\t{5,10}\t{6,25}\t{7,25}\n", 
                    i, index, bead.ToString(), prevPotStr, aftrPotStr, IsMoved,
                    totlPotStr, chain.ToString());
                
                TextWriter.Write("polymer_data.txt", sb.ToString());

                //Console.WriteLine("{0}, ", i);             
            }

            Console.WriteLine("END");

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
