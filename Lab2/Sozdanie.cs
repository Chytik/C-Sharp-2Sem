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
    public partial class Sozdanie : Form
    {
        //Form1 form1 = new Form1();
        public Sozdanie()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void button2_Click(object sender, EventArgs e) 
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (form1.list.Items.Count == 0) MessageBox.Show("Вы не ввели ни одного элемента, введите какое-нибудь слово", "Внимание");
            else { this.Close(); form1.Enabled = true; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (Box.Text == "") MessageBox.Show("Вы не ввели слово!\r\nВведите хотя бы один символ.", "Ошибка");
            else
            {
                form1.list.Items.Add(Box.Text);
                Box.Clear();
            }
        }
    }
}
