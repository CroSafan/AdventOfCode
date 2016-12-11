using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCodeDay4;

namespace AOCDay4UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckingIfRoomIsCorrect1()
        {
            Assert.AreEqual("abxyz", Solver.ReturnCode("aaaaa-bbb-z-y-x"));
        }
        [TestMethod]
        public void CheckingIfRoomIsCorrect2()
        {
            Assert.AreEqual("abcde", Solver.ReturnCode("a-b-c-d-e-f-g-h"));
        }
        [TestMethod]
        public void CheckingIfRoomIsCorrect3()
        {
            Assert.AreEqual("oarel", Solver.ReturnCode("not-a-real-room"));
        }
        [TestMethod]
        public void CheckingIfRoomIsFalse1()
        {
            Assert.AreNotEqual("decoy", Solver.ReturnCode("totally-real-room"));
        }
        [TestMethod]
        public void CheckingIfCheckSumIsCorrect1()
        {
            Assert.AreEqual("abxyz", Solver.GetCheckSum("aaaaa-bbb-z-y-x-123[abxyz]"));
        }
        [TestMethod]
        public void CheckingIfCheckSumIsCorrect2()
        {
            Assert.AreEqual("abcde", Solver.GetCheckSum("a-b-c-d-e-f-g-h-987[abcde]"));
        }
        [TestMethod]
        public void CheckingIfRoomIdIsCorrect1()
        {
            Assert.AreEqual("987", Solver.GetRoomId("a-b-c-d-e-f-g-h-987[abcde]"));
        }
        [TestMethod]
        public void CheckingIfRoomIdIsCorrect2()
        {
            Assert.AreEqual("123", Solver.GetRoomId("aaaaa-bbb-z-y-x-123[abxyz]"));
        }
        [TestMethod]
        public void CheckingIfDecryptIsCorrect1()
        {
            Assert.AreEqual("very encrypted name", Solver.DecryptCode(Solver.GetRoomName("qzmt-zixmtkozy-ivhz-343"),Solver.GetRoomId("qzmt-zixmtkozy-ivhz-343")));
        }
    }
}
