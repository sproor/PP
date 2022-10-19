using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace removeMethod_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string Src = "Foo(); int we = 12 * 2;";
            string Name = "Foo";
            string Code = "return int a = 0; a = a + 1;";

            Assert.AreEqual(
                    "int a = 0; a = a + 1; int we = 12 * 2;",
                    PP.Form1.RemoveMethod( Src, Name, Code ));
        }
        [TestMethod]
        public void TestMethod2()
        {
            string Src = "int formula = cr * Foo();";
            string Name = "Foo";
            string Code = "return 3.14;";

            Assert.AreEqual(
                    "int formula = cr * 3.14;",
                    PP.Form1.RemoveMethod( Src, Name, Code ));
        }
        [TestMethod]
        public void TestMethod3()
        {
            string Src = "int a = Foo(); a = a + 100;";
            string Name = "Foo";
            string Code = "return num;";

            Assert.AreEqual(
                    "int a = num; a = a + 100;",
                    PP.Form1.RemoveMethod( Src, Name, Code ));
        }
        [TestMethod]
        public void TestMethod4()
        {
            string Src = "if(country === 'Germany')   bruttoPrice = Foo();";
            string Name = "Foo";
            string Code = "return nettoPrice * 1.19;";

            Assert.AreEqual(
                    "if(country === 'Germany')   bruttoPrice = nettoPrice * 1.19;",
                    PP.Form1.RemoveMethod(Src, Name, Code));
        }
        [TestMethod]
        public void TestMethod5()
        {
            string Src = "Foo();";
            string Name = "Foo";
            string Code = "return f*9.8;";

            Assert.AreEqual(
                    "f*9.8;",
                    PP.Form1.RemoveMethod(Src, Name, Code));
        }
        [TestMethod]
        public void TestMethod6()
        {
            string Src = "if(name == \"Foo\") bruttoPrice = nettoPrice * 1.19 / Foo();";
            string Name = "Foo";
            string Code = "return 2;";

            Assert.AreEqual(
                    "if(name == \"Foo\") bruttoPrice = nettoPrice * 1.19 / 2;",
                    PP.Form1.RemoveMethod(Src, Name, Code));
        }
        [TestMethod]
        public void TestMethod7()
        {
            string Src = "int a = 0;";
            string Name = "Foo";
            string Code = "return pi/360;";

            Assert.AreEqual(
                    "int a = 0;",
                    PP.Form1.RemoveMethod(Src, Name, Code));
        }
        [TestMethod]
        public void TestMethod8()
        {
            string Src = "formula = f*Foo(); // Foo :: This is test for remove function";
            string Name = "Foo";
            string Code = "return 9.8;";

            Assert.AreEqual(
                    "formula = f*9.8; // Foo :: This is test for remove function",
                    PP.Form1.RemoveMethod(Src, Name, Code));
        }
        [TestMethod]
        public void TestMethod9()
        {
            string Src = "#include <iostream>\nformula = f*Foo();";
            string Name = "Foo";
            string Code = "return 9.8*a;";

            Assert.AreEqual(
                    "#include <iostream>\nformula = f*9.8*a;",
                    PP.Form1.RemoveMethod(Src, Name, Code));
        }
        [TestMethod]
        public void TestMethod10()
        {
            string Src = "int a = 10;\nformula = Foo();";
            string Name = "Foo";
            string Code = "return f*9.8;";

            Assert.AreEqual(
                    "int a = 10;\nformula = f*9.8;",
                    PP.Form1.RemoveMethod(Src, Name, Code));
        }
    }
}
