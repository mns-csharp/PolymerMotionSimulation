using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public static class EnergyFunction
    {
        public static double LennardJonesPairPotential(Point2d one, Point2d two)
        {
            //double r_square = one.GetSquaredDistance(two);          
            //double r_power_6 = Math.Pow(r_square, 3);
            //double r_power_12 = r_power_6 * r_power_6;
            ////if (r_power_12 == 0) r_power_12 = 0.000001;
            ////if (r_power_6 == 0) r_power_6 = 0.000001;
            //double term_12 = GlobalConstants.SigmaPower12 / r_power_12;
            //double term_6 = GlobalConstants.SigmaPower6 / r_power_6;
            //double lj_potential = 4 * GlobalConstants.Epsilon * (term_12 - term_6);
            //return lj_potential;

            double dx = Math.Abs(one.X - two.X);
            double dy = Math.Abs(one.Y - two.Y);

            dx = (dx < periodicBoundaryInt32 / 2) ? dx : periodicBoundaryInt32 - dx;
            dy = (dy < periodicBoundaryInt32 / 2) ? dy : periodicBoundaryInt32 - dy;

            double d = Math.Sqrt(dx * dx + dy * dy);

            double en = 0;
            if (d < Global.MinimumAtomicDistance)
                en += 10000000;
            else if (d < Global.MaximumAtomicDistance)
                en += -1;
        }

        public static double HarmonicPotential(Point2d one, Point2d two)
        {
            double k = Global.K_k;
            double r = one.GetDistance(two);

            double harmonic = k * (r - Global.MaximumAtomicDistance) * (r - Global.MaximumAtomicDistance);

            return harmonic;
        }
    }
}
