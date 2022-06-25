using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbLib
{

    public class AtomClass
    {
        public string Name { get; set; }
        public int Radius { get; set; }
        public Color ColorRgb { get; set; }

        public AtomClass()
        {
        }

        public AtomClass(string name, int radius, Color rgb)
        {
            Name = name;
            Radius = radius;
            ColorRgb = rgb;
        }
    }
    public class AtomEnum
    {
        public const string C = "C";
        public const string O = "O";
        public const string H = "H";
        public const string N = "N";
        public const string CL = "CL";
        public const string B = "B";
        public const string P = "P";
        public const string FE = "FE";
        public const string BA = "BA";
        public const string NA = "NA";
        public const string MG = "MG";
        public const string ZN = "ZN";
        public const string CU = "CU";
        public const string NI = "NI";
        public const string BR = "BR";
        public const string CA = "CA";
        public const string MN = "MN";
        public const string AL = "AL";
        public const string TI = "TI";
        public const string CR = "CR";
        public const string AG = "AG";
        public const string F = "F";
        public const string SI = "SI";
        public const string AU = "AU";
        public const string I = "I";
        public const string LI = "LI";
        public const string HE = "HE";
        public const string RA = "RA";
        public const string SR = "SR";
        public const string BE = "BE";
        public const string FR = "FR";
        public const string CS = "CS";
        public const string K = "K";
        public const string RB = "RB";
        public const string XE = "XE";
        public const string KR = "KR";
        public const string AR = "AR";
        public const string NE = "NE";
    }

    public class AtomDictionary
    {
        static Dictionary<string, AtomClass> dictionary;

        static AtomDictionary()
        {
            dictionary = new Dictionary<string, AtomClass>();

            AtomClass C = new AtomClass("Carbon", 70, Color.FromArgb(1, 200, 200, 200));
            dictionary.Add("C", C);
            AtomClass O = new AtomClass("Oxygen", 60, Color.FromArgb(1, 240, 0, 0));
            dictionary.Add("O", O);
            AtomClass H = new AtomClass("Hydrogen", 25, Color.FromArgb(1, 255, 255, 255));
            dictionary.Add("H", H);
            AtomClass N = new AtomClass("Nitrogen", 65, Color.FromArgb(1, 143, 143, 255));
            dictionary.Add("N", N);
            AtomClass S = new AtomClass("Sulfur", 100, Color.FromArgb(1, 255, 200, 50));
            dictionary.Add("S", S);
            AtomClass CL = new AtomClass("Chlorine", 100, Color.FromArgb(1, 0, 255, 0));
            dictionary.Add("CL", CL);
            AtomClass B = new AtomClass("Boron", 85, Color.FromArgb(1, 0, 255, 0));
            dictionary.Add("B", B);
            AtomClass P = new AtomClass("Phosphorus", 100, Color.FromArgb(1, 255, 165, 0));
            dictionary.Add("P", P);
            AtomClass FE = new AtomClass("Iron", 140, Color.FromArgb(1, 255, 165, 0));
            dictionary.Add("FE", FE);
            AtomClass BA = new AtomClass("Barium", 215, Color.FromArgb(1, 255, 165, 0));
            dictionary.Add("BA", BA);
            AtomClass NA = new AtomClass("Sodium", 180, Color.FromArgb(1, 0, 0, 255));
            dictionary.Add("NA", NA);
            AtomClass MG = new AtomClass("Magnesium", 150, Color.FromArgb(1, 34, 139, 34));
            dictionary.Add("MG", MG);
            AtomClass ZN = new AtomClass("Zinc", 134, Color.FromArgb(1, 165, 42, 42));
            dictionary.Add("ZN", ZN);
            AtomClass CU = new AtomClass("Copper", 128, Color.FromArgb(1, 165, 42, 42));
            dictionary.Add("CU", CU);
            AtomClass NI = new AtomClass("Nickel", 124, Color.FromArgb(1, 165, 42, 42));
            dictionary.Add("NI", NI);
            AtomClass BR = new AtomClass("Bromine", 115, Color.FromArgb(1, 165, 42, 42));
            dictionary.Add("BR", BR);
            AtomClass CA = new AtomClass("Calcium", 180, Color.FromArgb(1, 128, 128, 144));
            dictionary.Add("CA", CA);
            AtomClass MN = new AtomClass("Manganese", 127, Color.FromArgb(1, 128, 128, 144));
            dictionary.Add("MN", MN);
            AtomClass AL = new AtomClass("Aluminium", 143, Color.FromArgb(1, 128, 128, 144));
            dictionary.Add("AL", AL);
            AtomClass TI = new AtomClass("Titanium", 140, Color.FromArgb(1, 128, 128, 144));
            dictionary.Add("TI", TI);
            AtomClass CR = new AtomClass("Chromium", 128, Color.FromArgb(1, 128, 128, 144));
            dictionary.Add("CR", CR);
            AtomClass AG = new AtomClass("Silver", 144, Color.FromArgb(1, 128, 128, 144));
            dictionary.Add("AG", AG);
            AtomClass F = new AtomClass("Fluorine", 50, Color.FromArgb(1, 218, 165, 32));
            dictionary.Add("F", F);
            AtomClass SI = new AtomClass("Silicon", 111, Color.FromArgb(1, 218, 165, 32));
            dictionary.Add("SI", SI);
            AtomClass AU = new AtomClass("Gold", 144, Color.FromArgb(1, 218, 165, 32));
            dictionary.Add("AU", AU);
            AtomClass I = new AtomClass("Iodine", 140, Color.FromArgb(1, 160, 32, 240));
            dictionary.Add("I", I);
            AtomClass LI = new AtomClass("Lithium", 145, Color.FromArgb(1, 178, 34, 34));
            dictionary.Add("LI", LI);
            AtomClass HE = new AtomClass("Helium", 31, Color.FromArgb(1, 255, 192, 203));
            dictionary.Add("HE", HE);
            AtomClass RA = new AtomClass("Radium", 215, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("RA", RA);
            AtomClass SR = new AtomClass("Strontium", 200, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("SR", SR);
            AtomClass BE = new AtomClass("Beryllium", 105, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("BE", BE);
            AtomClass FR = new AtomClass("Francium", 260, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("FR", FR);
            AtomClass CS = new AtomClass("Caesium", 260, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("CS", CS);
            AtomClass K = new AtomClass("Potassium", 220, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("K", K);
            AtomClass RB = new AtomClass("Rubidium", 235, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("RB", RB);
            AtomClass XE = new AtomClass("Xenon", 108, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("XE", XE);
            AtomClass KR = new AtomClass("Krypton", 88, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("KR", KR);
            AtomClass AR = new AtomClass("Argon", 71, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("AR", AR);
            AtomClass NE = new AtomClass("Neon", 38, Color.FromArgb(1, 255, 20, 147));
            dictionary.Add("NE", NE);
        }
    }
    public class AminoAcidClass
    {
        public string Code { get; set; }
        public string Full { get; set; }
        public Color ColorRGB { get; set; }

        private List<Pair> bonds;

        public AminoAcidClass()
        {
            bonds = new List<Pair>();
        }

        public AminoAcidClass(string code, string full, Color colorRgb)
        {
            bonds = new List<Pair>();

            Code = code;
            Full = full;
            ColorRGB = colorRgb;
        }

        public void AddBond(Pair bond)
        {
            bonds.Add(bond);
        }
    }
    public class AminoAcidEnum
    {
        public const string ALA = "ALA";
        public const string CYS = "CYS";
        public const string ASP = "ASP";
        public const string GLU = "GLU";
        public const string PHE = "PHE";
        public const string GLY = "GLY";
        public const string HIS = "HIS";
        public const string ILE = "ILE";
        public const string LYS = "LYS";
        public const string LEU = "LEU";
        public const string MET = "MET";
        public const string ASN = "ASN";
        public const string PRO = "PRO";
        public const string GLN = "GLN";
        public const string ARG = "ARG";
        public const string SER = "SER";
        public const string THR = "THR";
        public const string VAL = "VAL";
        public const string TRP = "TRP";
        public const string TYR = "TYR";
        public const string UNK = "UNK";
    }
    public static class AminoAcidDictionary
    {
        static Dictionary<string, AminoAcidClass> dictionary;

        static AminoAcidDictionary()
        {
            dictionary = new Dictionary<string, AminoAcidClass>();

            AminoAcidClass ALA = new AminoAcidClass("A", "Alanine", Color.FromArgb(1, 140, 255, 140));
            ALA.AddBond(new Pair("CA", "CB"));
            ALA.AddBond(new Pair("C", "OXT"));
            dictionary.Add("ALA", ALA);

            AminoAcidClass CYS = new AminoAcidClass("C", "Cysteine", Color.FromArgb(255, 255, 112));
            CYS.AddBond(new Pair("CA", "CB"));
            CYS.AddBond(new Pair("CB", "SG"));
            dictionary.Add("CYS", CYS);

            AminoAcidClass ASP = new AminoAcidClass("D", "Aspartic acid", Color.FromArgb(160, 0, 66));
            ASP.AddBond(new Pair("CA", "CB"));
            ASP.AddBond(new Pair("CB", "CG"));
            ASP.AddBond(new Pair("CG", "OD1"));
            ASP.AddBond(new Pair("CG", "OD2"));
            dictionary.Add("ASP", ASP);

            AminoAcidClass GLU = new AminoAcidClass("E", "Glutamic acid", Color.FromArgb(102, 0, 0));
            GLU.AddBond(new Pair("CA", "CB"));
            GLU.AddBond(new Pair("CB", "CG"));
            GLU.AddBond(new Pair("CG", "CD"));
            GLU.AddBond(new Pair("CD", "OE1"));
            GLU.AddBond(new Pair("CD", "OE2"));
            dictionary.Add("GLU", GLU);

            AminoAcidClass PHE = new AminoAcidClass("F", "Phenylalanine", Color.FromArgb(83, 76, 66));
            PHE.AddBond(new Pair("CA", "CB"));
            PHE.AddBond(new Pair("CB", "CG"));
            PHE.AddBond(new Pair("CG", "CD1"));
            PHE.AddBond(new Pair("CG", "CD2"));
            PHE.AddBond(new Pair("CD1", "CE1"));
            PHE.AddBond(new Pair("CD2", "CE2"));
            PHE.AddBond(new Pair("CE1", "CZ"));
            PHE.AddBond(new Pair("CE2", "CZ"));
            dictionary.Add("PHE", PHE);

            AminoAcidClass GLY = new AminoAcidClass("G", "Glycine", Color.FromArgb(255, 255, 255));
            GLY.AddBond(new Pair("C", "OXT"));
            dictionary.Add("GLY", GLY);

            AminoAcidClass HIS = new AminoAcidClass("H", "Histidine", Color.FromArgb(112, 112, 255));
            HIS.AddBond(new Pair("CA", "CB"));
            HIS.AddBond(new Pair("CB", "CG"));
            HIS.AddBond(new Pair("CG", "ND1"));
            HIS.AddBond(new Pair("CG", "CD2"));
            HIS.AddBond(new Pair("CD2", "NE2"));
            HIS.AddBond(new Pair("NE2", "CE1"));
            HIS.AddBond(new Pair("CE1", "ND1"));
            dictionary.Add("HIS", HIS);

            AminoAcidClass ILE = new AminoAcidClass("I", "Isoleucine", Color.FromArgb(0, 76, 0));
            ILE.AddBond(new Pair("CA", "CB"));
            ILE.AddBond(new Pair("CB", "CG1"));
            ILE.AddBond(new Pair("CB", "CG2"));
            ILE.AddBond(new Pair("CG1", "CD1"));
            dictionary.Add("ILE", ILE);

            AminoAcidClass LYS = new AminoAcidClass("K", "Lysine", Color.FromArgb(71, 71, 184));
            LYS.AddBond(new Pair("CA", "CB"));
            LYS.AddBond(new Pair("CB", "CG"));
            LYS.AddBond(new Pair("CG", "CD"));
            LYS.AddBond(new Pair("CD", "CE"));
            LYS.AddBond(new Pair("CE", "NZ"));
            dictionary.Add("LYS", LYS);

            AminoAcidClass LEU = new AminoAcidClass("L", "Leucine", Color.FromArgb(69, 94, 69));
            LEU.AddBond(new Pair("CA", "CB"));
            LEU.AddBond(new Pair("CB", "CG"));
            LEU.AddBond(new Pair("CG", "CD1"));
            LEU.AddBond(new Pair("CG", "CD2"));
            dictionary.Add("LEU", LEU);

            AminoAcidClass MET = new AminoAcidClass("M", "Methionine", Color.FromArgb(184, 160, 66));
            MET.AddBond(new Pair("CA", "CB"));
            MET.AddBond(new Pair("CB", "CG"));
            MET.AddBond(new Pair("CG", "SD"));
            MET.AddBond(new Pair("SD", "CE"));
            dictionary.Add("MET", MET);

            AminoAcidClass ASN = new AminoAcidClass("N", "Asparagine", Color.FromArgb(255, 124, 112));
            ASN.AddBond(new Pair("CA", "CB"));
            ASN.AddBond(new Pair("CB", "CG"));
            ASN.AddBond(new Pair("CG", "OD1"));
            ASN.AddBond(new Pair("CG", "ND2"));
            dictionary.Add("ASN", ASN);

            AminoAcidClass PRO = new AminoAcidClass("P", "Proline", Color.FromArgb(82, 82, 82));
            PRO.AddBond(new Pair("CA", "CB"));
            PRO.AddBond(new Pair("CB", "CG"));
            PRO.AddBond(new Pair("CG", "CD"));
            PRO.AddBond(new Pair("CD", "N"));
            dictionary.Add("PRO", PRO);

            AminoAcidClass GLN = new AminoAcidClass("Q", "Glutamine", Color.FromArgb(255, 76, 76));
            GLN.AddBond(new Pair("CA", "CB"));
            GLN.AddBond(new Pair("CB", "CG"));
            GLN.AddBond(new Pair("CG", "CD"));
            GLN.AddBond(new Pair("CD", "OE1"));
            GLN.AddBond(new Pair("CD", "NE2"));
            dictionary.Add("GLN", GLN);

            AminoAcidClass ARG = new AminoAcidClass("R", "Arginine", Color.FromArgb(0, 0, 124));
            ARG.AddBond(new Pair("CA", "CB"));
            ARG.AddBond(new Pair("CB", "CG"));
            ARG.AddBond(new Pair("CG", "CD"));
            ARG.AddBond(new Pair("CD", "NE"));
            ARG.AddBond(new Pair("NE", "CZ"));
            ARG.AddBond(new Pair("CZ", "NH1"));
            ARG.AddBond(new Pair("CZ", "NH2"));
            dictionary.Add("ARG", ARG);

            AminoAcidClass SER = new AminoAcidClass("S", "Serine", Color.FromArgb(255, 112, 66));
            SER.AddBond(new Pair("CA", "CB"));
            SER.AddBond(new Pair("CB", "OG"));
            dictionary.Add("SER", SER);

            AminoAcidClass THR = new AminoAcidClass("T", "Threonine", Color.FromArgb(184, 76, 0));
            THR.AddBond(new Pair("CA", "CB"));
            THR.AddBond(new Pair("CB", "OG1"));
            THR.AddBond(new Pair("CB", "CG2"));
            dictionary.Add("THR", THR);

            AminoAcidClass VAL = new AminoAcidClass("V", "Valine", Color.FromArgb(255, 140, 255));
            VAL.AddBond(new Pair("CA", "CB"));
            VAL.AddBond(new Pair("CB", "CG1"));
            VAL.AddBond(new Pair("CB", "CG2"));
            dictionary.Add("VAL", VAL);

            AminoAcidClass TRP = new AminoAcidClass("W", "Tryptophan", Color.FromArgb(79, 70, 0));
            TRP.AddBond(new Pair("CA", "CB"));
            TRP.AddBond(new Pair("CB", "CG"));
            TRP.AddBond(new Pair("CG", "CD1"));
            TRP.AddBond(new Pair("CG", "CD2"));
            TRP.AddBond(new Pair("CD1", "NE1"));
            TRP.AddBond(new Pair("NE1", "CE2"));
            TRP.AddBond(new Pair("CE2", "CD2"));
            TRP.AddBond(new Pair("CD2", "CE3"));
            TRP.AddBond(new Pair("CE3", "CZ3"));
            TRP.AddBond(new Pair("CE2", "CZ2"));
            TRP.AddBond(new Pair("CZ2", "CH2"));
            TRP.AddBond(new Pair("CH2", "CZ3"));
            dictionary.Add("TRP", TRP);


            AminoAcidClass TYR = new AminoAcidClass("Y", "Tyrosine", Color.FromArgb(140, 112, 76));
            TYR.AddBond(new Pair("CA", "CB"));
            TYR.AddBond(new Pair("CB", "CG"));
            TYR.AddBond(new Pair("CG", "CD1"));
            TYR.AddBond(new Pair("CG", "CD2"));
            TYR.AddBond(new Pair("CD1", "CE1"));
            TYR.AddBond(new Pair("CD2", "CE2"));
            TYR.AddBond(new Pair("CE1", "CZ"));
            TYR.AddBond(new Pair("CE2", "CZ"));
            TYR.AddBond(new Pair("CZ", "OH"));
            dictionary.Add("TYR", TYR);

            AminoAcidClass UNK = new AminoAcidClass("U", "Unknown", Color.FromArgb(124, 233, 255));
            UNK.AddBond(new Pair("C", "OXT"));
            dictionary.Add("UNK", UNK);
        }
    }
}

