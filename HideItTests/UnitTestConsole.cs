using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HideIt.Model;

namespace HideItTests
{
    [TestClass]
    public class UnitTestConsole
    {
        [TestMethod]
        public void TestMethod_CeasarWithKey_Add5()
        {
            EncryptDecrypt c = new Caesar(5);
            Assert.AreEqual(c.EncryptAlgorithm("AAA"), "FFF");
        }

        [TestMethod]
        public void TestMethod_CeasarWithKey_Sub5()
        {
            EncryptDecrypt c = new Caesar(-5);
            Assert.AreEqual(c.EncryptAlgorithm("???"), ":::");
        }
    }
}
