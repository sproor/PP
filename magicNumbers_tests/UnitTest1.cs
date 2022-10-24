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
            string src = "int main() {" + Environment.NewLine + "int maxStudents = numClassrooms * 30;" + Environment.NewLine + "}";
            string name = "student";
            string namber = "30";
            string typeConst = "int";

            Assert.AreEqual(
                "const int student = 30;\r\nint main() {\r\nint maxStudents = numClassrooms * student;\r\n}",
                PP.Form1.magicNumber(src, namber,name , typeConst));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string src = "int main() {" + Environment.NewLine + "int formula = cr * 3.14;" + Environment.NewLine + "}";
            string name = "pi";
            string namber = "3.14";
            string typeConst = "double";

            Assert.AreEqual(
    "const double pi = 3.14;\r\nint main() {\r\nint formula = cr * pi;\r\n}",
           PP.Form1.magicNumber(src, namber, name, typeConst));
        }
        [TestMethod]
        public void TestMethod3()
        {
            string src = "int main() {" + Environment.NewLine + "if (num < 100){}" + Environment.NewLine + "}";
            string name = "maxNumber";
            string namber = "100";
            string typeConst = "int";

            Assert.AreEqual(
     "const int maxNumber = 100;\r\nint main() {\r\nif (num < maxNumber){}\r\n}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }
        [TestMethod]
        public void TestMethod4()
        {

            string src = "int main() {" + Environment.NewLine + "if(country == \"Germany\")   bruttoPrice = nettoPrice * 1.19;" + Environment.NewLine + "}";
            string name = "vatRate";
            string namber = "1.19";
            string typeConst = "double";

            Assert.AreEqual(
                      "const double vatRate = 1.19;\r\nint main() {\r\nif(country == \"Germany\")   bruttoPrice = nettoPrice * vatRate;\r\n}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }
        [TestMethod]
        public void TestMethod5()
        {

            string src = "int main() {" + Environment.NewLine + "formula = f*9.8;\nnumber = 23*9.8;" + Environment.NewLine + "}";
            string name = "g";
            string namber = "9.8";
            string typeConst = "float";

            Assert.AreEqual(
                    "const float g = 9.8;\r\nint main() {\r\nformula = f*g;\nnumber = 23*g;\r\n}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }
        [TestMethod]
        public void TestMethod6()
        {

            string src = "int main() {" + Environment.NewLine + "if(country == \"1.19\") bruttoPrice = nettoPrice * 1.19;" + Environment.NewLine + "}";
            string name = "vatRate";
            string namber = "1.19";
            string typeConst = "double";

            Assert.AreEqual(
                    "const double vatRate = 1.19;\r\nint main() {\r\nif(country == \"vatRate\") bruttoPrice = nettoPrice * vatRate;\r\n}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }
        [TestMethod]
        public void TestMethod7()
        {
            string src = "int main() {" + Environment.NewLine + "const float g=10;\nformula = f*9,8;\nnumber = 23*9,8;" + Environment.NewLine + "}";
            string name = "g";
            string namber = "9,8";
            string typeConst = "float";

            Assert.AreEqual(
                   "const float g = 9,8;\r\nint main() {\r\nconst float g=10;\nformula = f*g;\nnumber = 23*g;\r\n}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }

        [TestMethod]
        public void TestMethod8()
        {
            string src = "int main() {" + Environment.NewLine + "formula = f*9,8;//9,8 - g\nnumber = 23*9,8;" + Environment.NewLine + "}";

            string name = "g";
            string namber = "9,8";
            string typeConst = "float";

            Assert.AreEqual(
                   "const float g = 9,8;\r\nint main() {\r\nformula = f*g;//g - g\nnumber = 23*g;\r\n}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }
        [TestMethod]
        public void TestMethod9()
        {
            string src = "#include <iostream>" 
                 +Environment.NewLine +
                "formula = f*9,8;" 
                 + Environment.NewLine +
                "int main() {" 
                + Environment.NewLine + 
                "}";
            string name = "g";
            string namber = "9,8";
            string typeConst = "float";

            Assert.AreEqual(
                    "#include <iostream>\r\n" +
                    "const float g=9,8;\r\n" +
                    "formula = f*g;\r\n" +
                    "int main() {\r\n" +
                    "}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }
        [TestMethod]
        public void TestMethod10()
        {
            string src = "int main() {" + Environment.NewLine + "int a = 10;\nformula = f*9,8;" + Environment.NewLine + "}";
            string name = "g";
            string namber = "9,8";
            string typeConst = "float";

            Assert.AreEqual(
                   "const float g = 9,8;\r\nint main() {\r\nint a = 10;\nformula = f*g;\r\n}",
                       PP.Form1.magicNumber(src, namber, name, typeConst));
        }

    }
}
