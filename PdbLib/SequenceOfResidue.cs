using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{
    public class SequenceOfResidue
    {
        public string ChainID { get; set; }
        public List<string> Sequence { get; set; }
    }
}
