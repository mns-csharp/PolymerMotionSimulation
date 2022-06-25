using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{
    public class Title
    {
        private string[] splittedLine;

        public Title(string[] splittedLine)
        {
            this.splittedLine = splittedLine;
        }

        public string Text { get; set; }
    }
}
