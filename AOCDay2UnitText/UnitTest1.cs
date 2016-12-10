using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCodeDay2;
using System.IO;

namespace AOCDay2UnitText
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Example1()
        {
            string path = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay2\testinput.txt";
            Assert.AreEqual("1985", Helper.ReturnCode(path));
        }

        [TestMethod]
        public void Example2()
        {
            string path = @"C:\Users\Antun\Documents\Visual Studio 2015\Projects\AdventOfCode\AdventOfCodeDay2\testinput.txt";
            Assert.AreEqual("5DB3", Helper.ReturnCode2(path));
        }
    }
}
