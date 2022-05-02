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

        public int Count
        {
            get { return beadsList.Count; }
        }

        public PolymerChain()
        {
            beadsList = new List<Bead>();
            MaxCapacity = 4;
            BeadDistance = 3.8;

            beadsList.Add(new Bead("AA",1.67, 1.67));
            beadsList.Add(new Bead("BB",1.67, 3.33));//this index selected
            beadsList.Add(new Bead("CC",3.33, 1.67));
            beadsList.Add(new Bead("DD",3.33, 3.33));
        }

        #region PolymerChain(int maxBeads, double beadDistance)
        public PolymerChain(int maxBeads, double beadDistance)
        {
            if (beadsList != null)
            {
                beadsList.Clear();
            }
            else
            {
                beadsList = new List<Bead>();
            }

            MaxCapacity = maxBeads;
            BeadDistance = beadDistance;
        } 
        #endregion

        #region void Add(string name)
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

        public double GetPotential(Bead currentBead)
        {
            return GetPotential(currentBead.Location);
        }

        #region double GetPotential(Point2d currentLoc)
        public double GetPotential(Point2d currentLoc)
        {
            double beadPotential = 0;
            double harmonicPotential = 0;

            for (int i = 0; i < beadsList.Count; i++)
            {
                Point2d otherLoc = beadsList[i].Location;

                if (currentLoc != otherLoc)
                {
                    beadPotential += Bead.GetPairPotential(currentLoc, otherLoc);
                }
                else
                {
                    try
                    {
                        harmonicPotential += Bead.GetHarmonicPotential(currentLoc, beadsList[i - 1].Location);
                    }
                    catch { }

                    try
                    {
                        harmonicPotential += Bead.GetHarmonicPotential(currentLoc, beadsList[i + 1].Location);
                    }
                    catch { }
                }
            }

            double total = beadPotential + harmonicPotential;

            return total;
        } 
        #endregion

        #region double GetTotalPotential()
        public double GetTotalPotential()
        {
            double total = 0;

            double temp_total = 0;
            foreach (Bead item in beadsList)
            {
                temp_total=GetPotential(item);
                total += temp_total;
            }
            return total;
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

        #region List<Bead> GetList()
        public List<Bead> GetList()
        {
            return new List<Bead>(beadsList);
        } 
        #endregion

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


