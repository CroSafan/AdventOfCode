using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;

namespace AOCDay1UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Example1Test()
        {
            Mapper map = new Mapper();
            Assert.AreEqual(5, map.GetBlocks("R2,L3"));
        }

        [TestMethod]
        public void Example2Test()
        {
            Mapper map = new Mapper();
            Assert.AreEqual(2, map.GetBlocks("R2,R2,R2"));
        }

        [TestMethod]
        public void Example3Test()
        {
            Mapper map = new Mapper();
            Assert.AreEqual(12, map.GetBlocks("R5,L5,R5,R3"));
        }

        [TestMethod]
        public void Example4VisitedTwiceTest()
        {
            Mapper map = new Mapper();
            Assert.AreEqual(4, map.LocationVisitedTwice("R8, R4, R4, R8"));
        }
    }
}
