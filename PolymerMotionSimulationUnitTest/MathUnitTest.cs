using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymerMotionSimulation;

namespace PolymerMotionSimulationUnitTest
{
    [TestClass]
    public class MathUnitTest
    {
        public object MathFunc { get; private set; }

        [TestMethod]
        public void GetRandomPointAtRadius_Test()
        {
            double radius = 10;
            Point2d current = new Point2d(0, 0);
            double [] points = MathFuncs.GetRandPointAtRadius(current.X, current.Y, radius);
            Point2d point = new Point2d(points);

            double distance = current.GetDistance(point);

            Assert.AreEqual(distance, radius);
        }
    }
}
