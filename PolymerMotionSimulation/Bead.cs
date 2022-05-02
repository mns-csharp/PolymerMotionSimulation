using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class Bead: IEquatable<Bead>
    {
        public string Name { get; set; }
        public Point2d Location { get; private set; }

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

        public void SetLocation(Point2d newLocation)
        {
            Location = newLocation;
        }

        public double GetPairPotential(Bead otherBead)
        {
            return GetPairPotential(otherBead.Location);
        }

        public double GetHarmonicPotential(Bead otherBead)
        {
            return GetHarmonicPotential(otherBead.Location);
        }

        public double GetPairPotential(Point2d otherLocation)
        {
            double r = this.Location.GetDistance(otherLocation);
            return MathFuncs.LennardJonesPairPotential(Global.Sigma, Global.Epsilon, r);
            //return 0;
        }

        public double GetHarmonicPotential(Point2d otherLocation)
        {
            double r = this.Location.GetDistance(otherLocation);
            return MathFuncs.HarmonicPotential(Global.Harmonic_K, r, Global.MaxAtomDist);
            //return 0;
        }

        #region public static Point2d GetRandomPoint(double radius)
        public Point2d GetRandomPoint(double radius)
        {
            Point2d point = MathFuncs.GetRandPointAtRadius(this.Location, radius);

            double temp_x = point.X;
            double temp_y = point.Y;

            double x = 0, y = 0;

            // Apply periodic boundary conditions.
            if (temp_x < 0)
                x = Global.PeriodicDistance - temp_x;
            else
                x = (temp_x < Global.PeriodicDistance) ? temp_x : temp_x - Global.PeriodicDistance;

            // boundary condition check for new Y
            if (temp_y < 0)
                y = Global.PeriodicDistance - temp_y;
            else
                y = (temp_y < Global.PeriodicDistance) ? temp_y : temp_y - Global.PeriodicDistance;
            
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
