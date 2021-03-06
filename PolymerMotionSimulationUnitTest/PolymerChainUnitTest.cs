using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymerMotionSimulation;

namespace PolymerMotionSimulationUnitTest
{
    [TestClass]
    public class PolymerChainUnitTest
    {
        [TestMethod]
        public void GetTotalPotential__Test()
        {
            PolymerChain chain = new PolymerChain(4, 3.8);
            chain.Add("AA", 1.67, 1.67);
            chain.Add("BB", 1.67, 3.33);
            chain.Add("CC", 3.33, 1.67);
            chain.Add("DD", 3.33, 3.33);

            double totalPot = Math.Round(chain.GetTotalPotential(), 2);

            Assert.AreEqual(203.35, totalPot);
        }

        [TestMethod]
        public void GetPotential__Test()
        {
            PolymerChain chain = new PolymerChain(4, 3.8);
            chain.Add("AA", 1.67, 1.67);
            chain.Add("BB", 1.67, 3.33);
            chain.Add("CC", 3.33, 1.67);
            chain.Add("DD", 3.33, 3.33);

            Bead bead0 = chain[0];
            double pot0 = Math.Round(chain.GetPotential(bead0), 2);
            Assert.AreEqual(101.15, pot0);

            Bead bead1 = chain[1];
            double pot1 = Math.Round(chain.GetPotential(bead1), 2);
            Assert.AreEqual(102.2, pot1);

            Bead bead2 = chain[2];
            double pot2 = Math.Round(chain.GetPotential(bead2), 2);
            Assert.AreEqual(102.2, pot2);

            Bead bead3 = chain[3];
            double pot3 = Math.Round(chain.GetPotential(bead3), 2);
            Assert.AreEqual(101.15, pot3);
        }

        [TestMethod]
        public void DefaultConstructor__Test()
        {
            PolymerChain chain = new PolymerChain(4, 3.8);
            chain.Add("AA", 1.67, 1.67);
            chain.Add("BB", 1.67, 3.33);
            chain.Add("CC", 3.33, 1.67);
            chain.Add("DD", 3.33, 3.33);

            Assert.AreEqual(chain.Capacity, 4);
            Assert.AreEqual(chain.BeadDistance, 3.8);
            Assert.AreEqual(chain.Count, 4);
            Assert.AreEqual(chain[0], new Bead("AA", 1.67, 1.67));
            Assert.AreEqual(chain[1], new Bead("BB", 1.67, 3.33));//this index selected
            Assert.AreEqual(chain[2], new Bead("CC", 3.33, 1.67));
            Assert.AreEqual(chain[3], new Bead("DD", 3.33, 3.33));
        }
    }
}
