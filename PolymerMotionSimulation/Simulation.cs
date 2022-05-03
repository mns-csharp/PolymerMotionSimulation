using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymerMotionSimulation
{
    public class Simulation
    {
        public PolymerChain PolymerChain { get; set; }
        public int WritetoFileSteps { get; set; }
        List<int> lisIndex = new List<int>();
        public int Index { get { return lisIndex[lisIndex.Count - 1]; } }
        List<string> listBead = new List<string>();
        public string Bead { get { return listBead[listBead.Count - 1]; } }
        List<bool> listIsMoved = new List<bool>();
        public bool IsMoved { get { return listIsMoved[listIsMoved.Count - 1]; } }
        List<double> listPrevPotential = new List<double>();
        public double PrevPotential { get { return listPrevPotential[listPrevPotential.Count - 1]; } }
        List<double> listAfterPotential = new List<double>();
        public double AfterPotential { get { return listAfterPotential[listAfterPotential.Count - 1]; } }

        public double TotalPotential { get; private set; }

        public void SimulateMotion()
        {
            lisIndex.Clear();
            listBead.Clear();
            listIsMoved.Clear();
            listPrevPotential.Clear();
            listAfterPotential.Clear();

            for (int i = 0; i < WritetoFileSteps; i++)
            {
                int index = Global.Random.Next(0, PolymerChain.Count);// obtain a random index
                lisIndex.Add(index);
                Bead bead = PolymerChain[index];//obtain a random bead from the index
                listBead.Add(bead.ToString());

                Point2d previousLoc = new Point2d(bead.Location.X, bead.Location.Y);//copy the point
                double previousPot = PolymerChain.GetPotential(bead);//get the existing bead potential
                listPrevPotential.Add(previousPot);

                Point2d newLocation = bead.GetRandomPoint(PolymerChain.BeadDistance);//get a new point at a distance
                PolymerChain.MoveBead(index, newLocation);//move the bead to the new position
                double afterPot = PolymerChain.GetPotential(newLocation);//get the potential of the new position
                listAfterPotential.Add(afterPot);

                double energyDiff = afterPot - previousPot;//difference

                string sectionExecuted = string.Empty;
                if (energyDiff < 0)
                {
                    listIsMoved.Add(true);
                }
                else
                {
                    double randomDouble = Global.Random.NextDouble();

                    double monteCarlo = Math.Exp((-1) * (energyDiff) / (Global.Temperature_T));

                    if (monteCarlo > randomDouble)
                    {
                        listIsMoved.Add(true);
                    }
                    else
                    {
                        ///////////////////////////////////////////////////////
                        PolymerChain.MoveBead(index, previousLoc);
                        listIsMoved.Add(false);
                        ////////////////////////////////////////////////////////
                    }
                }
            }

            TotalPotential = PolymerChain.GetTotalPotential();
        }
    }
}
