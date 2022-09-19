using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace magicNumbers_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string src = "int maxStudents = numClassrooms * 30;";
            string name = "student";
            string namber = "30";
            string type = "int";

            Assert.AreEqual(
                    "const int student = 30;\nint maxStudents = numClassrooms * student;",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string src = "int formula = cr * 3.14;";
            string name = "pi";
            string namber = "3.14";
            string type = "double";

            Assert.AreEqual(
                    "const double pi = 3.14;\nint formula = cr * pi;",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod3()
        {
            string src = "if (num < 100)";
            string name = "maxNumber";
            string namber = "100";
            string type = "int";

            Assert.AreEqual(
                    "const int maxNumber = 100;\nif (num < maxNumber)",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod4()
        {
            string src = "if(country == 'Germany')   bruttoPrice = nettoPrice * 1.19;";
            string name = "vatRate";
            string namber = "1.19";
            string type = "double";

            Assert.AreEqual(
                    "const double vatRate = 1.19;\nif(country == 'Germany') bruttoPrice = nettoPrice * vatRate;",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod5()
        {
            string src = "formula = f*9,8;\nnumber = 23*9,8";
            string name = "g";
            string namber = "9,8";
            string type = "float";

            Assert.AreEqual(
                    "const float g = 9,8;\nformula = f*g;\nnumber = 23*g",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod6()
        {
            string src = "if(country == \"1.19\") bruttoPrice = nettoPrice * 1.19;";
            string name = "vatRate";
            string namber = "1.19";
            string type = "double";

            Assert.AreEqual(
                    "const double vatRate = 1.19;\nif(country == \"1.19\") bruttoPrice = nettoPrice * vatRate;",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod7()
        {
            string src = "const float g=10;\nformula = f*9,8;\nnumber = 23*9,8";
            string name = "g";
            string namber = "9,8";
            string type = "float";

            Assert.AreEqual(
                    "const float g=10;\nformula = f*9,8;\nnumber = 23*9,8",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod8()
        {
            string src = "formula = f*9,8;//9,8 - g\nnumber = 23*9,8";
            string name = "g";
            string namber = "9,8";
            string type = "float";

            Assert.AreEqual(
                    "const float g=9,8;\nformula = f*g;//9,8 - g\nnumber = 23*g",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod9()
        {
            string src = "#include <iostream>\nformula = f*9,8;";
            string name = "g";
            string namber = "9,8";
            string type = "float";

            Assert.AreEqual(
                    "#include <iostream>\nconst float g=9,8;\nformula = f*g;",
                    PP.Form1.magicNumber(src, name, namber, type));
        }
        [TestMethod]
        public void TestMethod10()
        {
            string src = "int a = 10;\nformula = f*9,8;";
            string name = "g";
            string namber = "9,8";
            string type = "float";

            Assert.AreEqual(
                    "int a = 10;\nconst float g = 9,8;\nformula = f*9,8;",
                    PP.Form1.magicNumber(src, name, namber, type));
        }

    }
}
