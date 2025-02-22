using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_2._1
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) { Form1 form1 = new Form1();  form1.Show(); this.Close(); }
    }
}
