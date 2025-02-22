using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_2_преисполнение
{
    public partial class Avtor : Form
    {
        public Avtor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            form1.Show(); this.Close();
        }
    }
}
