﻿using System;
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
    public partial class DellPlace : Form
    {
        public DellPlace()
        {
            InitializeComponent();
        }

        private void Box_KeyPress(object sender, KeyPressEventArgs e) { if (((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar))) || (e.KeyChar == '.')) e.Handled = true; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            this.Owner = form1;
            if (int.Parse(Box.Text) > form1.list.Items.Count) MessageBox.Show("Элемента на такой позиции нет в списке", "Ошибка");
            else
            {
                form1.list.Items.RemoveAt(int.Parse(Box.Text));
                this.Close(); form1.Enabled = true;
            }
        }
    }
}
