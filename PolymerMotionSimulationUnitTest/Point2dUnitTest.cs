using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymerMotionSimulation;

namespace YendrekUnitTestProject
{
    [TestClass]
    public class Point2dUnitTest
    {
        [TestMethod]
        public void GetSquaredDistance_Test()
        {
            Point2d point1 = new Point2d(100, 200);
            Point2d point2 = new Point2d(10, -10);

            double d = Math.Round(point1.GetSquaredDistance(point2), 2);

            Assert.AreEqual(52200, d);
        }

        [TestMethod]
        public void GetDistance_Test()
        {
            Point2d point1 = new Point2d(100, 200);
            Point2d point2 = new Point2d(10, -10);

            double d = Math.Round(point1.GetDistance(point2), 2);

            Assert.AreEqual(228.47, d);
        }

        [TestMethod]
        public void GetTranslated_Test()
        {
            Point2d center = new Point2d(100, 200);
            Point2d point2 = new Point2d(10, -10);

            Point2d translated = point2.GetTranslated(center);

            Point2d compare = new Point2d(110, 190);

            Assert.AreEqual(translated, compare);
        }

        [TestMethod]
        public void RefEquality_Test()
        {
            Point2d point1 = new Point2d(1, 2);
            Point2d point2 = point1;

            Assert.AreSame(point1, point2);
        }

        [TestMethod]
        public void ValueEquality_Test()
        {
            Point2d point1 = new Point2d(1, 2);
            Point2d point2 = new Point2d(1, 2);

            Assert.AreEqual(point1, point2);
        }
    }
}
