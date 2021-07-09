using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Third_Homework.Model.Validation;
using System.Globalization;
using System.Windows.Controls;

namespace UnitTestsForAuthWindow
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLoginType()
        {
            LoginValidationRule loginVR = new LoginValidationRule();
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Assert.IsInstanceOfType(loginVR.Validate("root", cultureInfo), typeof(ValidationResult));
        }

        [TestMethod]
        public void TestGoodLogin()
        {
            LoginValidationRule loginVR = new LoginValidationRule();
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            var actual = loginVR.Validate("root", cultureInfo);
            var expected = new ValidationResult(true, null);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestBadLogin()
        {
            LoginValidationRule loginVR = new LoginValidationRule();
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            var actual = loginVR.Validate("r", cultureInfo);
            var expected = new ValidationResult(true, null);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestPasswordType()
        {
            PasswordValidationRule passVR = new PasswordValidationRule();
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Assert.IsInstanceOfType(passVR.Validate("Root123", cultureInfo), typeof(ValidationResult));
        }

        [TestMethod]
        public void TestGoodPassword()
        {
            PasswordValidationRule passVR = new PasswordValidationRule();
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            var actual = passVR.Validate("Root123", cultureInfo);
            var expected = new ValidationResult(false, null);
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void TestBadPassword()
        {
            PasswordValidationRule passVR = new PasswordValidationRule();
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            var actual = passVR.Validate("rot", cultureInfo);
            var expected = new ValidationResult(false, "Пароль должен содержать:\nХотя бы одно число\nХотя бы одну латинскую букву в верхнем и нижнем регистре\nСтрока не менее 6 символов");
            Assert.AreEqual(expected, actual);
        }
    }
}
