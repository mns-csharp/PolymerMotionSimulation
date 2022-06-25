using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{
    public class Pair
    {
        public string First { get; set; }
        public string Second { get; set; }

        public Pair()
        { }

        public Pair(string first, string second)
        {
            First = first;
            Second = second;
        }
    }
}
