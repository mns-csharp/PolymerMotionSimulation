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
        public int Capacity { get; set; }
        public double BeadDistance { get; set; }
        private List<Bead> listOfBeads = null;
        private List<Point2d> listOfPoints = null;
        public int Count
        {
            get { return listOfBeads.Count; }
        }
        #endregion

        #region public PolymerChain()
        public PolymerChain()
        {
            listOfBeads = new List<Bead>();
            listOfPoints = new List<Point2d>();
        } 

        public PolymerChain(int maxBeads, double beadDistance)
        {
            listOfBeads = new List<Bead>();
            listOfPoints = new List<Point2d>();
            Capacity = maxBeads;
            BeadDistance = beadDistance;
        }
        #endregion

        #region void Add(string name, double x, double y)
        public void Add(string name, double x, double y)
        {
            if (listOfBeads.Count >= Capacity)
            {
                throw new Exception("Polymer's capacity full-filled!");
            }

            Bead newBead = new Bead(name, x, y);

            if (!listOfBeads.Contains(newBead) && !listOfPoints.Contains(newBead.Location))
            {
                listOfBeads.Add(newBead);
                listOfPoints.Add(newBead.Location);
            }
            else
            {
                throw new Exception("Bead already exists.");
            }
        } 
        #endregion

        #region void InitRandomBeads()
        public void LoadBeadsToPolymer()
        {
            listOfBeads.Clear();

            for (int i = 0; i < Capacity; i++)
            {
                Bead newBead = new Bead();
                newBead.Name = RandomStringGen.GetRandomString();

                if (listOfBeads.Count <= 0)
                {
                    newBead.SetLocation(new Point2d(0, 0));
                    Point2d newLocation = newBead.GetRandomPoint(BeadDistance);
                    newBead.SetLocation(newLocation);
                }
                else
                {
                    Bead lastBead = null;
                    do
                    {
                        lastBead = listOfBeads[listOfBeads.Count - 1];

                        Point2d newLocation = lastBead.GetRandomPoint(BeadDistance);
                        newBead.SetLocation(newLocation);
                    }
                    while (listOfBeads.Contains(newBead) || listOfPoints.Contains(newBead.Location));
                }

                listOfBeads.Add(newBead);
                listOfPoints.Add(newBead.Location);
            }
        }
        #endregion

        #region Bead this[int index]
        public Bead this[int index]
        {
            get
            {
                Bead bead = listOfBeads[index];

                return new Bead(bead.Name, bead.Location.X, bead.Location.Y);
            }
        }
        #endregion

        #region double GetPotential(Point2d currentLoc)
        public double GetPotential(Bead currentBead)
        {
            return GetPotential(currentBead.Location);
        }

        public double GetPotential(Point2d currentLoc)
        {
            double beadPotential = 0;
            double harmonicPotential = 0;

            for (int i = 0; i < listOfBeads.Count; i++)
            {
                Point2d otherLoc = listOfBeads[i].Location;

                if (currentLoc != otherLoc)
                {
                    beadPotential += Bead.GetPairPotential(currentLoc, otherLoc);
                }
                else
                {
                    try
                    {
                        harmonicPotential += Bead.GetHarmonicPotential(currentLoc, listOfBeads[i - 1].Location);
                    }
                    catch { }

                    try
                    {
                        harmonicPotential += Bead.GetHarmonicPotential(currentLoc, listOfBeads[i + 1].Location);
                    }
                    catch { }
                }
            }

            double total = beadPotential + harmonicPotential;

            return total;
        }
        #endregion

        #region void MoveBead(int index, Point2d newLocation)
        public void MoveBead(int index, Point2d newLocation)
        {
            if (!listOfPoints.Contains(newLocation))
            {
                listOfBeads[index].SetLocation(newLocation);
                listOfPoints[index] = newLocation;
            }
        } 
        #endregion

        #region double GetTotalPotential()
        public double GetTotalPotential()
        {            
            double totalPotential = 0;
            double totalHarmonic = 0;

            double tempTotal = 0;
            double tempHarmonic = 0;
            for (int i = 0; i < listOfBeads.Count-1; i++)
            {
                Bead bead_i = listOfBeads[i];

                try
                {
                    Bead bead_i_plus_1 = listOfBeads[i + 1];

                    tempHarmonic = bead_i.GetHarmonicPotential(bead_i_plus_1);

                    totalHarmonic += tempHarmonic;

                }
                catch{}
                /*
                * Page-133. Molecular simulation by Sadus. 
                */
                for (int j = i+1; j < listOfBeads.Count; j++)
                {                    
                    Bead bead_j = listOfBeads[j];

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
            foreach (var item in listOfBeads)
            {
                yield return item;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listOfBeads.GetEnumerator();
        }
        #endregion

        #region List<Bead> GetList()
        public List<Bead> GetList()
        {
            return new List<Bead>(listOfBeads);
        } 
        #endregion

        #region override string ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in listOfBeads)
            {
                sb.Append(item.ToString() + "; ");
            }

            return sb.ToString();
        }
        #endregion

        #region void Print()
        public void Print()
        {
            Console.WriteLine(this.ToString());
        } 
        #endregion
    }
}


