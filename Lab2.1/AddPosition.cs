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
    public partial class AddPosition : Form
    {
        public AddPosition()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) { if (((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar))) || (e.KeyChar == '.')) e.Handled = true; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (textBox1.Text == "") MessageBox.Show("Вы не ввели слово!\r\nВведите хотя бы один символ.", "Ошибка");
            else if (textBox2.Text == "") MessageBox.Show("Вы не ввели позицию!", "Ошибка");
            else if (int.Parse(textBox2.Text) > form1.list.Items.Count) MessageBox.Show("Элемента на такой позиции нет в списке", "Ошибка");
            else
            {
                form1.list.Items.Insert(int.Parse(textBox2.Text), textBox1.Text);
                this.Close(); form1.Enabled = true;
            }
        }
    }
}
