using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{
    public class PdbAtom
    {
        //ATOM     10  CB BTHR A   1       4.850 -11.840  18.069  0.25  9.70           C  
        
        public int AtomNo { get; set; }
        public string AtomType { get; set; }
        public string ResidueType { get; set; }
        public string ChainName { get; set; }
        public int ResidueNo { get; set; }
        public Point3d Coordinate { get; set; }
        public double Occupancy { get; set; }
        public double BetaFactor { get; set; }
        public string Element { get; set; }

        private string[] Parse(string AtomAndResidueType)
        {
            
            //extract last three characters from the parameter string
            string atomType = AtomAndResidueType.Substring(0, AtomAndResidueType.Length - 3);
            string residueType = AtomAndResidueType.Substring(AtomAndResidueType.Length - 3, 3);

            return new string[] { atomType, residueType};
        }

        public PdbAtom(string atomLine)
        {
            try
            {
                string temp = string.Empty;
                //012345678901234567890123456789012345678901234567890123456789012345678901234567
                //ATOM    541 HG21 THR A  28       7.623 -17.866   3.213  1.00  4.45           H  
                //ATOM    877  HB3 ALA A  45      16.747  -6.544  14.904  1.00  5.47           H  
                //ATOM    490 HD23ALEU A  25       0.875 -15.956  -0.171  0.60  3.25           H  
                temp = atomLine.Substring(4, 7);
                AtomNo = Convert.ToInt32(temp);
                temp = atomLine.Substring(11, 6).Trim();
                AtomType = temp;
                temp = atomLine.Substring(16, 3).Trim();
                ResidueType = temp;
                temp = atomLine.Substring(20, 1).Trim();
                ChainName = temp;
                temp = atomLine.Substring(22, 4).Trim();
                ResidueNo = Convert.ToInt32(temp);
                temp = atomLine.Substring(26, 28).Trim();
                Coordinate = new Point3d(temp);
                temp = atomLine.Substring(54, 6).Trim();
                Occupancy = Convert.ToDouble(temp);
                temp = atomLine.Substring(60, 6).Trim();
                BetaFactor = Convert.ToDouble(temp);
                temp = atomLine.Substring(66, 12).Trim();
                Element = temp;
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
