using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class PolymerChain
    {
        public int MaxCapacity { get; private set; }
        public double BeadDistance { get; private set; }
        private List<Bead> beadsList = null;

        public PolymerChain(int maxBeads, double beadDistance)
        {
            beadsList = new List<Bead>();
            MaxCapacity = maxBeads;
            BeadDistance = beadDistance;
            
        }

        public void AddBead(string name)
        {
            if (beadsList.Count >= MaxCapacity)
            {
                throw new Exception("Polymer's bead-capacity already full-filled!");
            }

            //Obtain the last bead of the chain.
            Bead lastBead = beadsList[beadsList.Count];
            //obtain a random location at distance 3.8.
            Point2d newLocation;

            // generate new random point until it is inside the simulation-box.
            do
            {
                newLocation = Point2d.GetRandomPoint(lastBead.Location, BeadDistance);
            }
            while (!(GlobalConstants.BottomLeft.X <= newLocation.X && GlobalConstants.BottomRight.X >= newLocation.X) 
                || !(GlobalConstants.BottomLeft.Y <= newLocation.Y && GlobalConstants.TopLeft.Y >= newLocation.Y));
            
            // create a new bead.
            Bead newBead = new Bead();
            newBead.Name = name;
            newBead.SetLocation(newLocation);

            //add the new bead to the polymer chain
            beadsList.Add(newBead);
        }

        public Bead this[int index]
        {
            get { return beadsList[index]; }
        }

        public double GetPotential(Bead bead)
        {
            double potential = 0;
            for (int i = 0; i < beadsList.Count - 1; i++)
            {
                Bead item = beadsList[i];
                if (bead != item)
                {
                    potential += bead.GetPairPotential(item);
                }
                else
                {
                    try
                    {
                        potential += bead.GetHarmonicPotential(beadsList[i - 1]);
                    }
                    catch { }

                    try
                    {
                        potential += bead.GetHarmonicPotential(beadsList[i + 1]);
                    }
                    catch { }
                }
            }

            return potential;
        }

        public double GetPotential(Point2d newPosition)
        {
            double potential = 0;
            for (int i = 0; i < beadsList.Count - 1; i++)
            {
                Bead item = beadsList[i];
                if (item.Location != newPosition)
                {
                    potential += item.GetPairPotential(newPosition);
                }
                else
                {
                    try
                    {
                        potential += item.GetHarmonicPotential(newPosition);
                    }
                    catch { }

                    try
                    {
                        potential += item.GetHarmonicPotential(beadsList[i + 1]);
                    }
                    catch { }
                }
            }

            return potential;
        }

        public double GetTotalPotential()
        {
            double totalBeadPotential = 0.0;
            double totalSpringPotential = 0.0;
            
            // calculate total bead-energy
            for (int i=0; i<beadsList.Count; i++)
            {
                Bead item_i = beadsList[i];
                Bead item_i_plus_1 = beadsList[i + 1];

                if (i != beadsList.Count-1)
                {
                    // calculate total spring energy.
                    totalSpringPotential += item_i.GetHarmonicPotential(item_i_plus_1);
                }

                for (int j= 0; j < beadsList.Count; j++)
                {
                    if (i != j)
                    {                        
                        Bead item_j = beadsList[j];
                        totalBeadPotential += item_i.GetPairPotential(item_j);
                    }
                }
            }
            
            return totalBeadPotential + totalSpringPotential;
        }
    }
}


