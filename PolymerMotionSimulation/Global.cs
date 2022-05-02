using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class Global
    {
        public const int PeriodicDistance = 100;
        public const int Width = PeriodicDistance;
        public const int Height = Width;
        public static readonly Point2d Center;
        public const int PolymerSize_N = 16;
        public const double BoltzmanConstant_Kb = 1.0;
        public const double Temperature_T = 10.0;
        public const double Epsilon = 2;
        public const double Sigma = 2;
        public static readonly double SigmaPower6;
        public static readonly double SigmaPower12;

        public const double Harmonic_K = 1;

        public const double MinAtomDist = 1;
        public const double MaxAtomDist = 3.8;

        public const int SimulationSteps = 1000000;
        public const int WriteToFileSteps = 100;

        public static Random Random = new Random(); 

        static Global()
        {
            Center = new Point2d(Width / 2, Height / 2);
            SigmaPower6 = Math.Pow(Sigma, 6);
            SigmaPower12 = Math.Pow(Sigma, 12);
        }
    }
}
