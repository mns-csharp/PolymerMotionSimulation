using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class Bead: IEquatable<Bead>
    {
        public string Name { get; set; }
        public Point2d Location { get; private set; }

        #region constructors
        public Bead()
        {
        }

        public Bead(string name, Point2d location)
        {
            Name = name;
            Location = location;
        }

        public Bead(string name, double x, double y)
        {
            Name = name;
            Location = new Point2d(x, y);
        } 
        #endregion

        public void SetLocation(Point2d newLocation)
        {
            Location = newLocation;
        }

        #region double GetHarmonicPotential()
        public static double GetHarmonicPotential(Point2d thisLocation, Point2d otherLocation)
        {
            double r = thisLocation.GetDistance(otherLocation);
            return MathFuncs.HarmonicPotential(Global.Harmonic_K, r, Global.MaxAtomDist);
            //return 0;
        }

        public double GetHarmonicPotential(Bead otherBead)
        {
            return Bead.GetHarmonicPotential(this.Location, otherBead.Location);
        } 
        #endregion

        #region double GetPairPotential()
        public double GetPairPotential(Bead otherBead)
        {
            return Bead.GetPairPotential(this.Location, otherBead.Location);
        }
        public static double GetPairPotential(Point2d thisLocation, Point2d otherLocation)
        {
            double r = thisLocation.GetDistance(otherLocation);
            return MathFuncs.LennardJonesPairPotential(Global.Sigma, Global.Epsilon, r);
            //return 0;
        }
        #endregion

        #region public static Point2d GetRandomPoint(double radius)
        public Point2d GetRandomPoint(double radius)
        {
            Point2d newPoint = new Point2d(MathFuncs.GetRandPointAtRadius(Location.X, Location.Y, radius));

            double newX = newPoint.X;
            double newY = newPoint.Y;

            double x = 0, y = 0;

            // Apply periodic boundary conditions.
            if (newX < 0)
                x = Global.PeriodicDistance + newX;
            else if (newX > Global.PeriodicDistance)
                x =  newX - Global.PeriodicDistance;

            // boundary condition check for new Y
            if (newY < 0)
                y = Global.PeriodicDistance + newY;
            else if (newY > Global.PeriodicDistance)
                y = newY - Global.PeriodicDistance;

            return new Point2d(x, y);
        }
        #endregion

        #region override string ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Name + " ");
            sb.Append(Location.ToString());

            return sb.ToString();
        } 
        #endregion

        #region equality comparison
        /// <summary>
        /// Equality comparisons
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public override bool Equals(object other)
        {
            if (!(other is Bead)) return false;
            return Equals((Bead)other); // Calls method below
        }
        public bool Equals(Bead other) // Implements IEquatable<Point2d>
        {
            return Location == other.Location && Name == other.Name;
        }
        public override int GetHashCode()
        {
            return this.Location.GetHashCode() * 67 + Name.GetHashCode(); // 67 = some prime number
        }
        public static bool operator ==(Bead a1, Bead a2)
        {
            if (ReferenceEquals(a1, null) && ReferenceEquals(a2, null)) return true;
            if (ReferenceEquals(a1, null) || ReferenceEquals(a2, null)) return false;
            return a1.Equals(a2);
        }
        public static bool operator !=(Bead a1, Bead a2)
        {
            return !(a1==a2);
        } 
        #endregion
    }
}
