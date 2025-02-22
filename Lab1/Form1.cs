using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_1
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        private void Proga_Click(object sender, EventArgs e) { O_Proge o_Proge = new O_Proge(); o_Proge.Show(); this.Hide(); }

        private void vyhod_Click(object sender, EventArgs e) { Vyhod vyhod = new Vyhod(); vyhod.Show(); this.Hide(); }

        private void Zadanie_Click(object sender, EventArgs e) { Recursion recursion = new Recursion(); recursion.Show(); this.Hide(); }
    }
}
