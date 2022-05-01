using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymerMotionSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymerMotionSimulationUnitTest
{
    [TestClass]
    public class BeadUnitTest
    {
        [TestMethod]
        public void RefEquality_Test()
        {
            Bead bead1 = new Bead("ABC", 1, 2);
            Bead bead2 = bead1;

            Assert.AreSame(bead1, bead2);
        }

        [TestMethod]
        public void ValueEquality_Test()
        {
            Bead bead1 = new Bead("ABC", 1, 2);
            Bead bead2 = new Bead("ABC", 1, 2);
            Bead bead3 = new Bead("XYZ", 1, 2);
            Bead bead4 = new Bead("XYZ", 2, 1);

            Assert.AreEqual(bead1, bead2);
            Assert.AreNotEqual(bead1, bead3);
            Assert.AreNotEqual(bead3, bead4);
        }
    }
}
