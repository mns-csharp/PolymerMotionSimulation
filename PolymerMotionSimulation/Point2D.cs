using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerSimulation__from__python
{
    public struct Point2d : IEquatable<Point2d>
    {
        public readonly double X;
        public readonly double Y; 
        
        #region constructor
        public Point2d(double x, double y)
        {
            X = x;
            Y = y;
        }
        #endregion

        public static double Distance(Point2d left, Point2d right)
        {
            return Math.Sqrt(((right.X - left.X)*(right.X - left.X)) 
                + ((right.Y - left.Y)*(right.Y - left.Y)));
        }

        public static double DistanceSquare(Point2d left, Point2d right)
        {
            return ((right.X - left.X) * (right.X - left.X))
                + ((right.Y - left.Y) * (right.Y - left.Y));
        }

        #region public static Point2d GetRandomPoint(Point2d currentLocation, double radius)
        public static Point2d GetRandomPoint(Point2d currentLocation, double radius)
        {
            Random random = new Random();
            double r = radius * Math.Sqrt(random.NextDouble());
            double theta = random.NextDouble() * 2 * Math.PI;

            double x = currentLocation.X + r * Math.Cos(theta);
            double y = currentLocation.Y + r * Math.Sin(theta);

            return new Point2d(x, y);
        } 
        #endregion

        #region equality comparison implementations
        public override bool Equals(object other)
        {
            if (!(other is Point2d)) return false;
            return Equals((Point2d)other); // Calls method below
        }
        public bool Equals(Point2d other) // Implements IEquatable<Point2d>
        {
            return X == other.X && Y == other.Y;
        }
        public override int GetHashCode()
        {
            return (int)Math.Round(Y * 31.0 + X, 0); // 31 = some prime number
        }
        public static bool operator ==(Point2d a1, Point2d a2)
        {
            return a1.Equals(a2);
        }
        public static bool operator !=(Point2d a1, Point2d a2)
        {
            return !a1.Equals(a2);
        } 
        #endregion
    }
}
