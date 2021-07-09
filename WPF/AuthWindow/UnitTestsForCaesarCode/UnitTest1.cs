using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using СaesarСode.Model;

namespace UnitTestsForCaesarCode
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEncrypt()
        {
            CaesarModel caesarModel = new CaesarModel();
            string actual = caesarModel.Encrypt("привет", 1);
            string expected = "рсйгёу";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestEncryptAnotherIndex()
        {
            CaesarModel caesarModel = new CaesarModel();
            string actual = caesarModel.Encrypt("привет как дела", 5);
            string expected = "фхнжйч пеп ийре";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDecrypt()
        {
            CaesarModel caesarModel = new CaesarModel();
            string actual = caesarModel.Decrypt("рсйгёу", 1);
            string expected = "привет";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestDecryptAnotherIndex()
        {
            CaesarModel caesarModel = new CaesarModel();
            string actual = caesarModel.Decrypt("фхнжйч пеп ийре", 5);
            string expected = "привет как дела";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFalseDecrypt()
        {
            CaesarModel caesarModel = new CaesarModel();
            string actual = caesarModel.Decrypt("рсйгёу", 1);
            string expected = "рсйгёу";
            Assert.AreNotEqual(expected, actual);
        }
    }
}
