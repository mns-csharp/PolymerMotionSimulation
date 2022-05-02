using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymerMotionSimulation;

namespace PolymerMotionSimulationUnitTest
{
    [TestClass]
    public class EnergyFunctionUnitTest
    {
        [TestMethod]
        public void LennardJonesTest()
        {
            // https://chem.libretexts.org/Bookshelves/Physical_and_Theoretical_Chemistry_Textbook_Maps/Supplemental_Modules_(Physical_and_Theoretical_Chemistry)/Physical_Properties_of_Matter/Atomic_and_Molecular_Properties/Intermolecular_Forces/Specific_Interactions/Lennard-Jones_Potential
            double lj = Math.Round(MathFuncs.LennardJonesPairPotential(3.40, 0.997, 4.0), 2);

            Assert.AreEqual(-0.94, lj);
        }

        [TestMethod]
        public void HarmonicPotentialTest()
        {
            double harmonic = Math.Round(MathFuncs.HarmonicPotential(1, 2.5, 3.8), 2);

            Assert.AreEqual(0.84, harmonic);
        }

        [TestMethod]
        public void SquarewellPotentialTest()
        {
            double pot = MathFuncs.SquareWellPairPotential(4.0, 1, 3.8);
            Assert.AreEqual(pot, 0);

            pot = MathFuncs.SquareWellPairPotential(2.0, 1, 3.8);
            Assert.AreEqual(pot, -1);

            pot = MathFuncs.SquareWellPairPotential(0, 1, 3.8);
            Assert.AreEqual(pot, 10000000);
        }
    }
}
