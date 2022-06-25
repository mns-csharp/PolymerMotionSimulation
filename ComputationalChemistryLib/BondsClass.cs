using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputationalChemistryLib
{
    public class BondsClass
    {
        ////// CONSTANTS ////

        //// threshold beyond average of covalent radiii to determine bond cutoff
        double bond_thresh = 1.2;

        //// covalent (or ionic) radii by atomic element (Angstroms) from
        //// "Inorganic Chemistry" 3rd ed, Housecroft, Appendix 6, pgs 1013-1014
        Dictionary<string, double> cov_rads
            = new Dictionary<string, double> {
              {"H", 0.37}, {"C", 0.77}, {"O", 0.73}, {"N", 0.75}, {"F", 0.71},
  {"P", 1.10}, {"S", 1.03}, {"Cl", 0.99}, {"Br", 1.14}, {"I", 1.33}, {"He", 0.30},
  {"Ne", 0.84}, {"Ar", 1.00}, {"Li", 1.02}, {"Be", 0.27}, {"B", 0.88}, {"Na", 1.02},
  {"Mg", 0.72}, {"Al", 1.30}, {"Si", 1.18}, {"K", 1.38}, {"Ca", 1.00}, {"Sc", 0.75},
  {"Ti", 0.86}, {"V", 0.79}, {"Cr", 0.73}, {"Mn", 0.67}, {"Fe", 0.61}, {"Co", 0.64},
  {"Ni", 0.55}, {"Cu", 0.46}, {"Zn", 0.60}, {"Ga", 1.22}, {"Ge", 1.22}, {"As", 1.22},
  {"Se", 1.17}, {"Kr", 1.03}, {"X", 0.00}
            };

        //// IO FUNCTIONS ////

        // read file data into a 2-d array
        public List<string[]> get_file_string_array(string file_name)
        {
            string[] lines = null;
            try
            {
                //file = open(file_name, "r")
                lines = File.ReadAllLines(file_name);

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: file (%s) not found!\n" % (file_name))
                //sys.exit()
            }
            //lines = file.readlines()
            //file.close()
            //array = []

            List<string[]> array = new List<string[]>();

            //for line in lines:
            //array.append(line.split())
            //return array

            foreach (var item in lines)
            {
                array.Add(item.Split());
            }

            return array;
        }

        // read in geometry from xyz file
        List<object> get_geom(string xyz_file_name)
        {
            List<string[]> xyz_array = get_file_string_array(xyz_file_name);
            int n_atoms = Convert.ToInt32(xyz_array[0][0]);
            //at_types = ["" for i in range(n_atoms)]
            string[] at_types = new string[n_atoms];
            for (int i = 0; i < n_atoms; i++)
            {
                at_types[i] = "";
            }

            //coords = [[0.0 for j in range(3)] for i in range(n_atoms)]
            double[,] coords = new double[n_atoms, 3];
            for (int i = 0; i < n_atoms; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    coords[i, j] = 0.0;
                }
            }

            /*for i in range(n_atoms):
                at_types[i] = xyz_array[i + 2][0]
                for j in range(3):
                    coords[i][j] = float(xyz_array[i + 2][j + 1])
            */
            for (int i = 0; i < n_atoms; i++)
            {
                at_types[i] = xyz_array[i + 2][0];
                for (int j = 0; j < 3; j++)
                {
                    coords[i, j] = Convert.ToDouble(xyz_array[i + 2][j + 1]);
                }
            }


            //geom = [at_types, coords]
            List<object> geom = new List<object>();
            geom.Add(at_types);
            geom.Add(coords);
            return geom;
        }

        // input syntax and usage warnings
        string get_inputs()
        {
            if (!len(sys.argv) == 2)
                {
                Console.WriteLine("Usage: %s XYZ_FILE\n" + (sys.argv[0]));
                Console.WriteLine("  XYZ_FILE: coordinates of target molecule\n");
                sys.exit();
                    }
            else{
                xyz_file_name = sys.argv[1];
                    }
            return xyz_file_name;
                        }
// print geometry to screen
def print_geom(geom, comment):
    at_types, coords = geom[0:2]
    n_atoms = len(at_types)
    Console.WriteLine("%i\n%s\n" % (n_atoms, comment), end="")
    for i in range(n_atoms):
        Console.WriteLine("%-2s" % (at_types[i]), end="")
        for j in range(3):
            Console.WriteLine(" %12.6f" % (coords[i][j]), end="")
        Console.Write("\n")
    Console.Write("\n")

// Console.WriteLine bond graph to screen
def print_bond_graph(geom, bond_graph, comment):
    at_types = geom[0]
    n_atoms = len(at_types)
    Console.WriteLine("%s\n" % (comment), end="")
    for i in range(n_atoms):
        Console.WriteLine(" %4i %-2s -" % (i+1, at_types[i]), end="")
        for j in range(len(bond_graph[i])):
            Console.WriteLine(" %i" % (bond_graph[i][j] + 1), end="")
        Console.WriteLine("\n", end= "")
    Console.WriteLine("\n", end= "")

// Console.WriteLine list of bond lengths to screen
        def print_bonds(geom, bonds):
    at_types = geom[0]
    n_bonds = len(bonds)
    Console.WriteLine("%i bond(s) found (Angstrom)" % (n_bonds))
    for q in range(n_bonds):
        n1, n2  = bonds[q][0:2]
        r12 = bonds[q][2]
        nstr = "%i-%i" % (n1+1, n2+1)
        tstr = "(%s-%s) " % (at_types[n1], at_types[n2])
        Console.WriteLine(" %-15s  %-13s    %6.4f\n" % (nstr, tstr, r12), end="")
    Console.WriteLine("\n", end= "")

//// MATH FUNCTIONS ////

// calculate distance between two 3-d cartesian coordinates
def get_r12(coords1, coords2):
    r2 = 0.0
    for p in range(3):
        r2 += (coords2[p] - coords1[p])**2
    r = math.sqrt(r2)
    return r

//// TOPOLOGY FUNCTIONS ////

// build graph of which atoms are covalently bonded
def get_bond_graph(geom):
    at_types, coords = geom[0:2]
    n_atoms = len(at_types)
    bond_graph = [[] for i in range(n_atoms)]
    for i in range(n_atoms):
        covrad1 = cov_rads[at_types[i]]
        for j in range(i+1, n_atoms):
            covrad2 = cov_rads[at_types[j]]
            thresh = bond_thresh * (covrad1 + covrad2)
            r12 = get_r12(coords[i], coords[j])
            if (r12<thresh):
                bond_graph[i].append(j)
                bond_graph[j].append(i)
    return bond_graph

// determine atoms which are covalently bonded from bond graph
def get_bonds(geom, bond_graph):
    at_types, coords = geom[0:2]
    n_atoms = len(at_types)
    bonds = []
    for i in range(n_atoms):      
        for a in range(len(bond_graph[i])):
            j = bond_graph[i][a]
            if (i<j):
                r12 = get_r12(coords[i], coords[j])
                bonds.append([i, j, r12])
    return bonds
    }
}
