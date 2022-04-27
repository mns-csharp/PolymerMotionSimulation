using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class GlobalConstants
    {
        public const int Width = 100;
        public const int Height = 100;
        public static readonly Point2d BottomLeft = new Point2d(0, 0);
        public static readonly Point2d TopLeft;
        public static readonly Point2d TopRight;
        public static readonly Point2d BottomRight;
        public static readonly Point2d Center;
        public const int MaxLengthOfPolymer_N = 30;
        public const int BoltzmanConstant_Kb = 100;
        public const int Temperature_T = 100;
        public const double Epsilon = 0.25;
        public const double Sigma = 0.80;
        public static readonly double SigmaPower6;
        public static readonly double SigmaPower12;

        public const double K_k = 1;

        public const double Radius = 3.8;

        static GlobalConstants()
        {
            Center = new Point2d(Width / 2, Height / 2);
            TopLeft = new Point2d(BottomLeft.X, BottomLeft.Y + Height);
            TopLeft = new Point2d(BottomLeft.X + Width, BottomLeft.Y + Height);
            BottomRight = new Point2d(BottomLeft.X + Width, BottomLeft.Y);
            SigmaPower6 = Math.Pow(Sigma, 6);
            SigmaPower12 = Math.Pow(Sigma, 12);
        }
    }
}
