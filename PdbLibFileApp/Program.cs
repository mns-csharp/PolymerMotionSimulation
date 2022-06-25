using PdbLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLibFileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PdbFile pdbFile = PdbFile.FromFile("3nir.pdb");
        }
    }
}
