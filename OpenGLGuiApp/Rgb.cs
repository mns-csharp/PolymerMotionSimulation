using System;

namespace GettingStartedWithSharpGL
{
    internal class Rgb
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public Rgb()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        public Rgb(double x, double y, double z)
        {
            Red = x;
            Green = y;
            Blue = z;
        }

        public Rgb(string x, string y, string z)
        {
            Red = Convert.ToDouble(x);
            Green = Convert.ToDouble(y);
            Blue = Convert.ToDouble(z);
        }

        public Rgb(string xyz)
        {
            string[] vals = xyz.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Red = Convert.ToDouble(vals[0].Trim());
            Green = Convert.ToDouble(vals[1].Trim());
            Blue = Convert.ToDouble(vals[2].Trim());
        }
    }
}