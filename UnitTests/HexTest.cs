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

        // TODO
    }
}
