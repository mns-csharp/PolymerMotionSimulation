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
        private string lastKey;
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

            Bead bead = new Bead("AA", 1.67, 1.67);
            beadsList.Add(bead);
            bead = new Bead("BB", 1.67, 3.33);
            beadsList.Add(bead);//this index selected
            bead = new Bead("CC", 3.33, 1.67);
            beadsList.Add(bead);
            bead = new Bead("DD", 3.33, 3.33);
            beadsList.Add(bead);
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

            while(beadsList.Count < MaxCapacity)
            {
                Add("");
            }
        } 
        #endregion

        #region void Add(string name)
        public void Add(string name)
        {
            if (beadsList.Count >= MaxCapacity)
            {
                throw new Exception("Polymer's bead-capacity already full-filled!");
            }

            //add a new bead in the dictionary.
            Bead newBead = new Bead();
            newBead.Name = name;

            if (beadsList.Count <= 0)
            {
                newBead.SetLocation(new Point2d(0, 0));
            }
            else
            {
                Bead lastBead = null;
                do
                {
                    lastBead = beadsList[beadsList.Count - 1];

                    Point2d newLocation = lastBead.GetRandomPoint(BeadDistance);
                    
                    newBead.SetLocation(newLocation);
                }
                while (beadsList.Contains(newBead));
            }

            beadsList.Add(newBead);
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
            double totalPotential = 0;
            double totalHarmonic = 0;

            double tempTotal = 0;
            double tempHarmonic = 0;
            for (int i = 0; i < beadsList.Count-1; i++)
            {
                Bead bead_i = beadsList[i];

                try
                {
                    Bead bead_i_plus_1 = beadsList[i + 1];

                    tempHarmonic = bead_i.GetHarmonicPotential(bead_i_plus_1);

                    totalHarmonic += tempHarmonic;

                }
                catch{}
                /*
                * Page-133. Molecular simulation by Sadus. 
                */
                for (int j = i+1; j < beadsList.Count; j++)
                {                    
                    Bead bead_j = beadsList[j];

                    tempTotal = bead_i.GetPairPotential(bead_j);

                    totalPotential += tempTotal;
                }
            }

            double total = totalPotential + totalHarmonic;

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
                sb.Append(item.ToString() + "; ");
            }

            return sb.ToString();
        } 
        #endregion
    }
}


