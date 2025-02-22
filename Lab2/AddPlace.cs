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
    public partial class AddPlace : Form
    {
        public AddPlace()
        {
            InitializeComponent();
        }

        private void Box1_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true; }

        private void Box2_KeyPress(object sender, KeyPressEventArgs e) { if (((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar))) || (e.KeyChar == '.')) e.Handled = true; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (Box1.Text == "") MessageBox.Show("Вы не ввели слово!\r\nВведите хотя бы один символ.", "Ошибка");
            else if (Box2.Text == "") MessageBox.Show("Вы не ввели позицию!", "Ошибка");
            else if (int.Parse(Box2.Text) > form1.list.Items.Count) MessageBox.Show("Элемента на такой позиции нет в списке", "Ошибка");
            else
            {
                form1.list.Items.Insert(int.Parse(Box2.Text), Box1.Text);
                this.Close(); form1.Enabled = true;
            }
        }
    }
}
