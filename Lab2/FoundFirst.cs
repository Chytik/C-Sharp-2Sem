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
    public partial class FoundFirst : Form
    {
        public FoundFirst()
        {
            InitializeComponent();
        }

        private void Box_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (Box.Text == "") MessageBox.Show("Вы ничего не ввели!\r\nВведите хотя бы один символ.", "Ошибка");
            else { this.Close(); form1.Enabled = true; }
        }
    }
}
