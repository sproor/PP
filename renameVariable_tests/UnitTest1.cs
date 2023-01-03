using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PP;

namespace renameVariable_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Refactor rfc = new Refactor();

            string text = "int x = 10;\n";

            Assert.AreEqual("int Count = 10;\n", rfc.rename(text, "Count", "x"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Refactor rfc = new Refactor();

            string text = "int x = 10;\n x ++;\n";

            Assert.AreEqual("int Count = 10;\n Count ++;\n", rfc.rename(text, "Count", "x"));

        }

        [TestMethod]
        public void TestMethod3()
        {
            Refactor rfc = new Refactor();

            string text = "int x = 10; //x-число\nx ++;//increment\ncout << x ;\n";

            Assert.AreEqual("int y = 10; //x-число\ny ++;//increment\ncout << y ;\n", rfc.rename(text, "y", "x"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Refactor rfc = new Refactor();

            string text = "int x = 10;\n" +
                "cout << \"x = \" << x ;\n";

            Assert.AreEqual("int y = 10;\n" +
                "cout << \"x = \" << y ;\n", rfc.rename(text, "y", "x"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Refactor rfc = new Refactor();

            string text = "int x = 10; cout << \"x = \" << x ;\n";

            Assert.AreEqual("int x = 10; cout << \"x = \" << x ;\n", rfc.rename(text, "Count", "i"));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Refactor rfc = new Refactor();

            string text = "int i = 10;";

            Assert.AreEqual("int Count = 10;", rfc.rename(text, "Count", "i"));
            // CollectionAssert.AreEqual();
        }

        [TestMethod]
        public void TestMethod7()
        {
            Refactor rfc = new Refactor();

            string text = "int xxx = 10;";

            Assert.AreEqual("int xxx = 10;", rfc.rename(text, "xxx", "xxx"));
        }

    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod8()
        {
            Refactor rfc = new Refactor();

            string text = "func(int a){if(){a++;return a;}return a;}";

            Assert.AreEqual("func(int a)\n{\n\tif(){\n\ta++;\n\treturn a;\n}return a;\n}", rfc.format(text));

        }
        [TestMethod]
        public void TestMethod9()
        {
            Refactor rfc = new Refactor();

            string text = "Func(int a){if(){a++;return a;}return a;}";

            Assert.AreEqual("Func(int a)\n{\n\tif()\n\t{\n\t\ta++;\n\t\treturn a;\n\t}\n\treturn a;\n}", rfc.format(text));
        }

        [TestMethod]
        public void TestMethod10()
        {
            Refactor rfc = new Refactor();

            string text = "switch(c){case Color.Red:Console.WriteLine(\"The color is red\");break;case Color.Blue:Console.WriteLine(\"The color is blue\");break;default:Console.WriteLine(\"The color is unknown.\");break;}";

            Assert.AreEqual("switch(c){\n\tcase Color.Red:\n\t\tConsole.WriteLine(\"The color is red\");\n\t\tbreak;\n\tcase Color.Blue:\n\t\tConsole.WriteLine(\"The color is blue\");\n\t\tbreak;\n\tdefault:\n\t\tConsole.WriteLine(\"The color is unknown.\");\n\t\tbreak;\n}", rfc.format(text));
        }

        [TestMethod]
        public void TestMethod11()
        {
            Refactor rfc = new Refactor();

            string text = "if(){}else{}";

            Assert.AreEqual("if(){\n\n}\nelse{\n\n}", rfc.format(text));
        }

        [TestMethod]
        public void TestMethod12()
        {
            Refactor rfc = new Refactor();

            string text = "try{}catch(Exception e){}finally{}";

            Assert.AreEqual("try{\n\n}\ncatch(Exception e){\n\n}\nfinally{\n\n}", rfc.format(text));
        }

        [TestMethod]
        public void TestMethod13()
        {
            Refactor rfc = new Refactor();

            string text = "public string Description{get{return _description;}set{var description = string.Empty;var substrings = value.Split( new[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries );for ( var i = 0; i < substrings.Length; i++ ){description += substrings[i] + \".\";if ( i % 5 == 0 && i != 0 ){description += Environment.NewLine + Environment.NewLine;}}_description = description;}}";

            Assert.AreEqual("public string Description\n{\n\tget\n\t{\n\t\treturn _description;\n\t}\n\tset\n\t{\n\t\tvar description = string.Empty;\n\t\tvar substrings = value.Split( new[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries );\n\t\tfor ( var i = 0; i < substrings.Length; i++ )\n\t\t{\n\t\t\tdescription += substrings[i] + \".\";\n\t\t\tif ( i % 5 == 0 && i != 0 )\n\t\t\t{\n\t\t\t\tdescription += Environment.NewLine + Environment.NewLine;\n\t\t\t}\n\t\t}\n\t\t_description = description;\n\t}\n}", rfc.format(text));
        }

        [TestMethod]
        public void TestMethod14()
        {
            Refactor rfc = new Refactor();

            string text = "int num = 6;if(){if(){if(){if(){if(){if(){num++;}}}}}return num;}";

            Assert.AreEqual("int num = 6;\nif()\n{\n\tif()\n\t{\n\t\tif()\n\t\t{\n\t\t\tif()\n\t\t\t{\n\t\t\t\tif()\n\t\t\t\t{\n\t\t\t\t\tif()\n\t\t\t\t\t{\n\t\t\t\t\t\tnum++;\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}\n\t\t}\n\t}\nreturn num;\n}", rfc.format(text));
        }
    }
}
