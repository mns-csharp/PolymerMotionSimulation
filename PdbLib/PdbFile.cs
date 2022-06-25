using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{
    public class PdbFile
    {
        public Header HEADER { get; set; }
        public Title TITLE { get; set; }
        public Compound CMPND { get; set; }
        public Source SOURCE { get; set; }
        public SequenceOfResidue SEQRES { get; set; }
        private List<PdbAtom> ATOMs;

        public PdbFile()
        {
            ATOMs = new List<PdbLib.PdbAtom>();
        }

        public static PdbFile FromFile(string fileName)
        {
            PdbFile pdbFile = new PdbFile();

            string[] lines = File.ReadAllLines(fileName);
            string linesString = string.Empty;
            try
            {
                List<PdbAtom> atoms = new List<PdbAtom>();

                foreach (string line in lines)
                {
                    linesString = line;

                    string[] splittedLine = line.Split(new char[] {' ' }, StringSplitOptions.RemoveEmptyEntries);

                    switch(splittedLine[0])
                    {
                        case "HEADER":
                            Header header = new Header(splittedLine);
                            pdbFile.HEADER = header;
                            break;
                        case "TITLE":
                            Title title = new Title(splittedLine);
                            pdbFile.TITLE = title;
                            break;
                        case "COMPND":
                            break;
                        case "SOURCE":
                            break;
                        case "SEQRES":
                            break;
                        case "ATOM":
                            atoms.Add(new PdbAtom(line));
                            break;
                    }
                }

                pdbFile.ATOMs = atoms;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pdbFile;
        }
    }
}