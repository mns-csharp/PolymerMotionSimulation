using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class Bead: IEquatable<Bead>
    {
        public string Name { get; set; }
        public Point2d Location { get; private set; }

        public void SetLocation(Point2d newLocation)
        {
            Location = newLocation;
        }

        public double GetPairPotential(Bead otherBead)
        {
            return EnergyFunction.LennardJonesPairPotential(this.Location, otherBead.Location);
        }

        public double GetHarmonicPotential(Bead otherBead)
        {
            return EnergyFunction.HarmonicPotential(this.Location, otherBead.Location);
        }

        public double GetPairPotential(Point2d otherLocation)
        {
            return EnergyFunction.LennardJonesPairPotential(this.Location, otherLocation);
        }

        public double GetHarmonicPotential(Point2d otherLocation)
        {
            return EnergyFunction.HarmonicPotential(this.Location, otherLocation);
        }

        #region public static Point2d GetRandomPoint(double radius)
        public Point2d GetRandomPoint(double radius)
        {
            Random random = new Random();
            double r = radius * Math.Sqrt(random.NextDouble());
            double theta = random.NextDouble() * 2 * Math.PI;

            double x = Location.X + r * Math.Cos(theta);
            double y = Location.Y + r * Math.Sin(theta);

            return new Point2d(x, y);
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
            return a1.Equals(a2);
        }
        public static bool operator !=(Bead a1, Bead a2)
        {
            return !a1.Equals(a2);
        } 
        #endregion
    }
}
