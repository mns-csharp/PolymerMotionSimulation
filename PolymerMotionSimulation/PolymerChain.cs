using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PolymerMotionSimulation
{
    public class PolymerChain : IEnumerable<Bead>, IEnumerable
    {
        #region properties
        public int MaxCapacity { get; private set; }
        public double BeadDistance { get; private set; }
        private List<Bead> beadsList = null; 
        #endregion

        #region PolymerChain(int maxBeads, double beadDistance)
        public PolymerChain(int maxBeads, double beadDistance)
        {
            beadsList = new List<Bead>();
            MaxCapacity = maxBeads;
            BeadDistance = beadDistance;

        } 
        #endregion

        #region void AddBead(string name)
        public void Add(string name)
        {
            if (beadsList.Count >= MaxCapacity)
            {
                throw new Exception("Polymer's bead-capacity already full-filled!");
            }

            //Obtain the last bead of the chain.
            Bead lastBead = null;
            try
            {
                lastBead = beadsList[beadsList.Count - 1];
            }
            catch
            {

            }

            if (lastBead != null)
            {
                //obtain a random location at distance 3.8.
                Point2d newLocation;

                // generate new random point until it is inside the simulation-box.
                newLocation = lastBead.GetRandomPoint(BeadDistance);

                // create a new bead.
                Bead newBead = new Bead();
                newBead.Name = name;
                newBead.SetLocation(newLocation);

                //add the new bead to the polymer chain
                beadsList.Add(newBead);
            }
            else
            {
                // create a new bead.
                Bead newBead = new Bead();
                newBead.Name = name;
                newBead.SetLocation(new Point2d(0, 0));

                //add the new bead to the polymer chain
                beadsList.Add(newBead);
            }
        }
        #endregion

        #region Bead this[int index]
        public Bead this[int index]
        {
            get { return beadsList[index]; }
        } 
        #endregion

        #region double GetPotential(Bead bead)
        public double GetPotential(Bead bead)
        {
            double potential = GetPotential(bead.Location);

            return potential;
        } 
        #endregion

        #region double GetPotential(Point2d newPosition)
        public double GetPotential(Point2d newPosition)
        {
            double potential = 0;
            for (int i = 0; i < beadsList.Count; i++)
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
        #endregion

        #region double GetTotalPotential()
        public double GetTotalPotential()
        {
            double totalBeadPotential = 0.0;
            double totalSpringPotential = 0.0;

            // calculate total bead-energy
            for (int i = 0; i < beadsList.Count; i++)
            {
                Bead item_i = beadsList[i];
                Bead item_i_plus_1 = null;

                try
                {
                    item_i_plus_1 = beadsList[i + 1];

                    if (i != beadsList.Count - 1)
                    {
                        // calculate total spring energy.
                        totalSpringPotential += item_i.GetHarmonicPotential(item_i_plus_1);
                    }
                }
                catch { }

                for (int j = 0; j < beadsList.Count; j++)
                {
                    if (i != j)
                    {
                        Bead item_j = beadsList[j];
                        totalBeadPotential += item_i.GetPairPotential(item_j);
                        //Console.Write(totalBeadPotential + "\n");
                        //Thread.Sleep(100);
                    }
                }
            }

            return totalBeadPotential + totalSpringPotential;
        } 
        #endregion

        #region IEnumerator<Bead> implementation
        public IEnumerator<Bead> GetEnumerator()
        {
            foreach (var item in beadsList)
            {
                yield return item;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return beadsList.GetEnumerator();
        }
        #endregion

        public List<Bead> GetList()
        {
            return new List<Bead>(beadsList);
        }

        #region override string ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in beadsList)
            {
                sb.Append(item.ToString() + "\r\n");
            }

            return sb.ToString();
        } 
        #endregion
    }
}


