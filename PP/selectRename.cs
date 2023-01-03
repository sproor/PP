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
    public partial class selectRename : Form
    {
        public string var1
        {
            get { return textBox1.Text; }
        }
        public string var2
        {
            get { return textBox2.Text; }
        }

        public selectRename()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
