using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymerMotionSimulation
{
    public static class TextWriter
    {
        public static void Write(string file, string text)
        {
            using (StreamWriter w = File.AppendText(file))
            {
                w.Write(text);
            }
        }

        public static void WriteLine(string file, string text)
        {
            using (StreamWriter w = File.AppendText(file))
            {
                w.WriteLine(text);
            }
        }
    }
}
