using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{
    public class Point3d
    {      

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3d(string x, string y, string z)
        {
            X = Convert.ToDouble(x);
            Y = Convert.ToDouble(y);
            Z = Convert.ToDouble(z);
        }

        public Point3d(string xyz)
        {
            string[] vals = xyz.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); 

            X = Convert.ToDouble(vals[0].Trim());
            Y = Convert.ToDouble(vals[1].Trim());
            Z = Convert.ToDouble(vals[2].Trim());
        }
    }
}
