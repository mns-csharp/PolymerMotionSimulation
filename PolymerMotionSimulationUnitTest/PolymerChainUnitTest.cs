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
            PolymerChain chain = new PolymerChain();

            double totalPot = chain.GetTotalPotential();

            Assert.AreEqual(totalPot, 407.10);
        }

        [TestMethod]
        public void GetPotential__Test()
        {
            PolymerChain chain = new PolymerChain();

            Bead bead0 = chain[0];
            double pot0 = chain.GetPotential(bead0);
            Assert.AreEqual(pot0, 101.25);

            Bead bead1 = chain[1];
            double pot1 = chain.GetPotential(bead1);
            Assert.AreEqual(pot1, 102.3);

            Bead bead2 = chain[2];
            double pot2 = chain.GetPotential(bead2);
            Assert.AreEqual(pot2, 102.3);

            Bead bead3 = chain[3];
            double pot3 = chain.GetPotential(bead3);
            Assert.AreEqual(pot3, 101.25);
        }

        [TestMethod]
        public void DefaultConstructor__Test()
        {
            PolymerChain chain = new PolymerChain();
            Assert.AreEqual(chain.MaxCapacity, 4);
            Assert.AreEqual(chain.BeadDistance, 3.8);
            Assert.AreEqual(chain.Count, 4);
            Assert.AreEqual(chain[0], new Bead("AA", 1.67, 1.67));
            Assert.AreEqual(chain[1], new Bead("BB", 1.67, 3.33));//this index selected
            Assert.AreEqual(chain[2], new Bead("CC", 3.33, 1.67));
            Assert.AreEqual(chain[3], new Bead("DD", 3.33, 3.33));
        }
    }
}
