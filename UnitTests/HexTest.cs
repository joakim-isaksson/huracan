using Huracan.Hexagon;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class HexTest
    {
        [TestMethod]
        public void Add()
        {
            Assert.AreEqual(Hex.Zero, Hex.Zero.Add(Hex.Zero));
        }

        [TestMethod]
        public void Subtract()
        {
            Assert.AreEqual(Hex.Zero, Hex.O2.Subtract(Hex.O2));
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(Hex.Zero.Add(Hex.O0).Add(Hex.O0).Add(Hex.O0), Hex.O0.Multiply(3));
        }

        [TestMethod]
        public void Lenght()
        {
            Assert.AreEqual(3, Hex.O0.Multiply(3).Length());
        }

        [TestMethod]
        public void Distance()
        {
            Assert.AreEqual(3, Hex.Zero.Distance(Hex.O0.Multiply(3)));
        }

        // TODO
    }
}
