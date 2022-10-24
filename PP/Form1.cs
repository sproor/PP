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
            newSrc =  newSrc.Insert(src.IndexOf("int main"), "const "+ typeConst + " "+ nameConst+" = "+ value+";" + Environment.NewLine);                 
            return newSrc;
        }



        public static string RemoveMethod(string InSrc, string InFuncName, string InCode)
        {
            return InSrc;
        }

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "int main() {" + Environment.NewLine + "int maxStudents = numClassrooms * 30;" + Environment.NewLine +"}";

           ToolStripMenuItem magic = new ToolStripMenuItem("Вынести константу");
            contextMenuStrip1.Items.Add(magic);
            textBox1.ContextMenuStrip = contextMenuStrip1;
            magic.Click += magic_Click;

            string src = "int main() {" + Environment.NewLine + "int a = 10;\nformula = f*9,8;" + Environment.NewLine + "}";
            string name = "g";
            string namber = "9,8";
            string typeConst = "float";

            textBox1.Text = magicNumber(src, namber, name, typeConst);
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
