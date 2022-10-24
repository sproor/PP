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
    public partial class selectCode : Form
    {
        public string funcName
        {
            get { return textBox1.Text; }
        }
        public string funcCode
        {
            get { return textBox2.Text; }
        }

        public selectCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
