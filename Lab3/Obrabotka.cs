using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба_Окончательная
{
    public partial class Obrabotka : Form
    {
        public Obrabotka()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { if (((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar))) || (e.KeyChar == '.')) e.Handled = true; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (textBox1.Text == "") MessageBox.Show("Вы не ввели число!\r\nВведите хотя бы один символ.", "Ошибка");
            else
            {
                form1.sll = form1.sll.CreateList(form1.bst, int.Parse(textBox1.Text));
                NodeQ current = form1.sll.first;
                while (current != null)
                {
                    form1.listBox1.Items.Add(current.Data.ToString());
                    current = current.Link;
                }
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (form1.listBox1.Items.Count == 0) MessageBox.Show("Вы не ввели ни одного элемента, введите какое-нибудь число", "Внимание");
            else 
            {
                //form1.arr = new int[form1.listBox2.Items.Count];
                //for (int i = 0; i < form1.listBox2.Items.Count; i++) form1.arr[i] = int.Parse(form1.listBox2.Items[i].ToString());
                this.Close(); form1.Enabled = true;
            }
        }
    }
}
