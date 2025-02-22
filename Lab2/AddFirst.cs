using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Лаба_2_преисполнение
{
    public partial class AddFirst : Form
    {
        public AddFirst()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (textBox1.Text == "") MessageBox.Show("Вы не ввели слово!\r\nВведите хотя бы один символ.", "Ошибка");
            else
            {
                form1.list.Items.Insert(0,textBox1.Text);
                this.Close(); form1.Enabled = true;
            }
        }
    }
}
