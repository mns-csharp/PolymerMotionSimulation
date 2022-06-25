using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{
    public class Header
    {
        private string[] splittedLine;

        public Header(string[] splittedLine)
        {
            this.splittedLine = splittedLine;
        }

        public string Description { get; set; }
        public string Date { get; set; }
        public string ProteinName { get; set; }
    }
}
