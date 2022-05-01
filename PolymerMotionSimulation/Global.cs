using System;
using System.Collections.Generic;
using System.Text;

namespace PolymerMotionSimulation
{
    public class Global
    {
        public const int Width = 100;
        public const int WidthHalf = Width / 2;
        public const int Height = Width;
        public const int HeightHalf = Height/2;
        public static readonly Point2d BottomLeft = new Point2d(0, 0);
        public static readonly Point2d TopLeft;
        public static readonly Point2d TopRight;
        public static readonly Point2d BottomRight;
        public static readonly Point2d Center;
        public const int MaxLengthOfPolymer_N = 30;
        public const int BoltzmanConstant_Kb = 1;
        public const int Temperature_T = 1;
        public const double Epsilon = 2;
        public const double Sigma = 2;
        public static readonly double SigmaPower6;
        public static readonly double SigmaPower12;

        public const double K_k = 1;

        public const double MinimumAtomicDistance = 1;
        public const double MaximumAtomicDistance = 3.8;

        public static Random Random = new Random(); 

        static Global()
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
