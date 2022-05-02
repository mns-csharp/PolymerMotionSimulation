using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymerMotionSimulation;

namespace PolymerMotionSimulationUnitTest
{
    [TestClass]
    public class MathUnitTest
    {

        [TestMethod]
        public void GetRandomPointAtRadius_Test()
        {
            double radius = 10;
            Point2d current = new Point2d(0, 0);

            for (int i = 0; i < 100; i++)
            {
                double[] points = MathFuncs.GetRandPointAtRadius(current.X, current.Y, radius);
                Point2d point = new Point2d(points);

                TextWriter.WriteLine("unite_test.txt", point.ToString());

                double distance = Math.Round(current.GetDistance(point),2);

                Assert.AreEqual(10, distance);
            }            
        }
    }
}
