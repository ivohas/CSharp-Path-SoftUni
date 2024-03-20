namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void InvalidCapacityBelowZero() {
            Robot robot = new Robot("sttcs", 323);
            Assert.Throws<ArgumentException>(() =>
            {
              

            }, "Invalid capacity!");
        }
    }
}
