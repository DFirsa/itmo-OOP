using System;
using NUnit.Framework;
using OOP_Test;

namespace Test_OOP
{
    [TestFixture]
    public class Tests
    {
        Circle circle = new Circle(new Vector(0 ,0), 7);
        
        [Test]
        public void OutputTest()
        {
            string expected = "Centre: (0; 0)\nRadius: 7";
            string result = circle.getInfo();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AreaTest()
        {
            double result = circle.getArea();
            Assert.AreEqual(49*Math.PI, result);
        }

        [Test]
        public void PerimetreTest()
        {
            double result = circle.getPer();
            Assert.AreEqual(14*Math.PI, result);
        }
        
        [Test]
        public void MoveTest()
        {
            Circle localCircle = new Circle(new Vector(0, 0), 7);
            localCircle.move(new Vector(12, 12));
            string expected = "Centre: (12; 12)\nRadius: 7";
            string result = localCircle.getInfo();
            Assert.AreEqual(expected, result);
        }
    }
}