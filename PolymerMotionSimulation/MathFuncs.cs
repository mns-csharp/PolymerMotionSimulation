using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public static class MathFuncs
    {
        public static double GetNormalizeBetween(double val, double min, double max)
        {
            if (!(val >= 0 && val <= 1))
            {
                throw new Exception("[val] must between 0 and 1");
            }

            double valmin = 0;
            double valmax = 1;
            return (((val - valmin) / (valmax - valmin)) * (max - min)) + min;
        }

        public static double [] GetRandPointAtRadius(double currentX, double currentY, double radius)
        {
            double angle = Global.Random.NextDouble() * Math.PI * 2;
            double x = Math.Cos(angle) * radius;
            double y = Math.Sin(angle) * radius;

            return new double[] { currentX+x, currentY+y };
        }
    
        public static double LennardJonesPairPotential(double sigma, double epsilon, double rad)
        {
            double r_square = rad * rad;//16
            double r_power_6 = Math.Pow(r_square, 3);//4096
            double r_power_12 = r_power_6 * r_power_6;//16777216
            double sigma_6 = Math.Pow(sigma, 6);//1544.804416
            double sigma_12 = sigma_6 * sigma_6;//2386420.68369
            double term_12 = sigma_12 / r_power_12;//0.14224175713
            double term_6 = sigma_6 / r_power_6;//0.37714951562
            double term_diff = term_12 - term_6;//-0.23490775849
            double lj_potential = 4 * epsilon * term_diff;//-0.93681214085
            return lj_potential;
        }

        public static double SquareWellPairPotential(double r, double min_dist, double max_dist)
        {
            double d = r;

            double en = 0;
            if (d < min_dist)
                en += 10000000;
            else if (d < max_dist)
                en += -1;
            return en;
        }

        public static double HarmonicPotential(double k, double r, double r0)
        {
            //https://chem.libretexts.org/Courses/Pacific_Union_College/Quantum_Chemistry/05%3A_The_Harmonic_Oscillator_and_the_Rigid_Rotor/5.01%3A_A_Harmonic_Oscillator_Obeys_Hooke's_Law
            double diff = r - r0;
            double harmonic = 0.5 * k * diff * diff;

            return harmonic;
        }

        public static double Truncate(double value)
        {
            return Math.Ceiling(value * 100) / 100;
        }
    }
}
