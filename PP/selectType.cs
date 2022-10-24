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
    public partial class selectType : Form
    {
        public string typeConst
        {
            get { return comboBox1.Text; }
        }
        public string name
        {
            get { return textBox1.Text; }
        }
        public selectType()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}
