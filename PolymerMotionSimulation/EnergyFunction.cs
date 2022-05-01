using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public static class EnergyFunction
    {
        public static double LennardJonesPairPotential(Point2d one, Point2d two)
        {
            double r_square = one.GetSquaredDistance(two);
            double r_power_6 = Math.Pow(r_square, 3);
            double r_power_12 = r_power_6 * r_power_6;
            //if (r_power_12 == 0) r_power_12 = 0.000001;
            //if (r_power_6 == 0) r_power_6 = 0.000001;
            double term_12 = Global.SigmaPower12 / r_power_12;
            double term_6 = Global.SigmaPower6 / r_power_6;
            double lj_potential = 4 * Global.Epsilon * (term_12 - term_6);
            return lj_potential;
        }

        public static double SquareWellPairPotential(Point2d one, Point2d two)
        {
            double dx = Math.Abs(one.X - two.X);
            double dy = Math.Abs(one.Y - two.Y);

            dx = (dx < Global.WidthHalf) ? dx : Global.Width - dx;
            dy = (dy < Global.HeightHalf) ? dy : Global.Height - dy;

            double d = Math.Sqrt(dx * dx + dy * dy);

            double en = 0;
            if (d < Global.MinimumAtomicDistance)
                en += 10000000;
            else if (d < Global.MaximumAtomicDistance)
                en += -1;
            return en;
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
