using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PP
{
    public partial class Form1 : Form
    {

        public static string magicNumber(string src, string value, string nameConst, string typeConst)
        {
            string newSrc = src;
            //MessageBox.Show(src.IndexOf("int main").ToString());
            newSrc = newSrc.Replace(value, nameConst);
            newSrc = newSrc.Insert(src.IndexOf("int main"), "const " + typeConst + " " + nameConst + " = " + value + ";" + Environment.NewLine);
            return newSrc;
        }



        public static string RemoveMethod(string InUseCode, string InFuncName, string InFuncCode)
        {
            int IndexReturn = InFuncCode.IndexOf("return ");
            if (IndexReturn >= 0)
            {
                InFuncCode = InFuncCode.Remove(IndexReturn, 7);       // 6 is size of word 'return '
                int IndexSemicolon = InFuncCode.LastIndexOf(';');
                if (IndexSemicolon >= 0)
                {
                    InFuncCode = InFuncCode.Remove(IndexSemicolon, 1);
                }
            }

            string FunctionSemantic = InFuncName + "();";
            if (InUseCode.Contains(FunctionSemantic))
            {
                string CodeFormat = "";
                int Index = InUseCode.IndexOf(FunctionSemantic);
                if (Index >= 0)
                {
                    string[] Parts = InUseCode.Split(new[] { FunctionSemantic }, StringSplitOptions.RemoveEmptyEntries);
                    if (Parts.Length > 0 && Parts[0].StartsWith(" "))
                    {
                        Parts[0] = Parts[0].Remove(0, 1);
                    }

                    if (Parts.Length > 0 && Index > InUseCode.IndexOf(Parts[0]))
                    {
                        CodeFormat = Parts[0] + "{0};";
                    }
                    else if (Parts.Length > 0)
                    {
                        CodeFormat = "{0}; " + Parts[0];
                    }
                    else
                    {
                        CodeFormat = "{0};";
                    }

                    for (int Idx = 1; Idx < Parts.Length; ++Idx)
                    {
                        CodeFormat += Parts[Idx];
                    }

                }

                return string.Format(CodeFormat, InFuncCode);
            }
            else
            {
                return InUseCode;
            }
        }


        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "int main() {" + Environment.NewLine + "int maxStudents = numClassrooms * 30;" + Environment.NewLine + "}";

            ToolStripMenuItem magic = new ToolStripMenuItem("Вынести константу");
            contextMenuStrip1.Items.Add(magic);
            textBox1.ContextMenuStrip = contextMenuStrip1;
            magic.Click += magic_Click;

        }
        private void magic_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText.Length > 0)
            {
                selectType f2 = new selectType();
                f2.ShowDialog();
                string typeConst = f2.typeConst;
                string name = f2.name;
                if (name.Length <= 0) { name = "temp"; }
                textBox1.Text = magicNumber(textBox1.Text, textBox1.SelectedText, name, typeConst);
            }
            else
            {
                MessageBox.Show("select number");
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
