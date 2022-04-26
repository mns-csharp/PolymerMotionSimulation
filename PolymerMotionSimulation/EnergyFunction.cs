using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerSimulation__from__python
{
    public static class EnergyFunction
    {
        public static double LennardJonesPairPotential(Point2d one, Point2d two)
        {
            double r_square = Point2d.DistanceSquare(one, two);


            return 0;
        }

        public static double HarmonicPotential(Point2d one, Point2d two)
        {
            return 0;
        }
    }
}
