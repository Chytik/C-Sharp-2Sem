using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ДЗ1;

namespace Лаба_1
{
    public partial class Recursion : Form
    {
        Answer ans = new Answer();
        int[] arr;
        int x; 
        public Recursion()
        {
            InitializeComponent();
            dataGridView1.RowCount = 1;
            labelArr.Visible = false; dataGridView1.Visible = false; buttonArr.Visible = false;
            labelPoisk.Visible = false; BoxPoisk.Visible = false; buttonPoisk.Visible = false;
            labelOtvet.Visible = false; labelOtvetChislo.Visible = false;
            labelElem.Visible = false; labelIndex.Visible = false;
            Box.Visible = false; labelSort.Visible = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //dataGridView1.RowCount = 1;
            //dataGridView1.ColumnCount = (int)numericUpDown1.Value;
        }

        private void buttonVyhod_Click(object sender, EventArgs e) { Form1 form = new Form1(); form.Show(); this.Close(); }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (tb != null) tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e) { if (((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar))) || (e.KeyChar == '.')) e.Handled = true; }        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) { if (((!char.IsControl(e.KeyChar)) && (!char.IsDigit(e.KeyChar))) || (e.KeyChar == '.')) e.Handled = true; }

        private void buttonPoisk_Click(object sender, EventArgs e)
        {
            if (BoxPoisk.Text == "") MessageBox.Show("Введите число для поиска", "Ошибка");
            else
            {
                x = int.Parse(BoxPoisk.Text);
                arr = new int[dataGridView1.Columns.Count];
                for (int i = 0; i < dataGridView1.Columns.Count; i++) arr[i] = Convert.ToInt32(dataGridView1[i, 0].Value);
                Array.Sort(arr);
                labelSort.Visible = true; Box.Visible = true;
                Box.Text = String.Join(", ", arr);
                labelOtvetChislo.Text = ans.BS(arr, arr[0], arr[arr.Length - 1], x).ToString();
                labelOtvet.Visible = true; labelOtvetChislo.Visible = true; labelElem.Visible = true; labelIndex.Visible = true; 
            }
        }

        private void buttonDlina_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = (int)numericUpDown1.Value;
            if (dataGridView1.Columns.Count < 2)
            {
                labelArr.Visible = false; dataGridView1.Visible = false; buttonArr.Visible = false;
                labelPoisk.Visible = false; BoxPoisk.Visible = false; buttonPoisk.Visible = false;
                labelOtvet.Visible = false; labelOtvetChislo.Visible = false;
                labelElem.Visible = false; labelIndex.Visible = false;
                Box.Visible = false; labelSort.Visible = false;
                MessageBox.Show("Массив должен состоять минимум из 2 элементов", "Ошибка");
            }
            else 
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++) dataGridView1[i, 0].Value = "";
                Box.Clear(); BoxPoisk.Clear(); labelOtvetChislo.Text = ""; 
                labelArr.Visible = true; dataGridView1.Visible = true; buttonArr.Visible = true; 
            }
        }

        private void buttonArr_Click(object sender, EventArgs e)
        {
            int a = 0;
            for (int j = 0; j < dataGridView1.Columns.Count; j++) if (dataGridView1[j, 0].Value.ToString() != "") a++;
            if (a != dataGridView1.Columns.Count)
            {
                Box.Clear(); BoxPoisk.Clear(); labelOtvetChislo.Text = "";
                labelPoisk.Enabled = false; BoxPoisk.Enabled = false; buttonPoisk.Enabled = false;
                MessageBox.Show("Все элементы массива должны иметь значение", "Ошибка");
            } 
            else 
            {
                Box.Clear(); BoxPoisk.Clear(); labelOtvetChislo.Text = "";
                labelPoisk.Enabled = true; BoxPoisk.Enabled = true; buttonPoisk.Enabled = true;
                labelPoisk.Visible = true; BoxPoisk.Visible = true; buttonPoisk.Visible = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelArr.Visible = false; dataGridView1.Visible = false; buttonArr.Visible = false;
            labelPoisk.Visible = false; BoxPoisk.Visible = false; buttonPoisk.Visible = false;
            labelOtvet.Visible = false; labelOtvetChislo.Visible = false;
            labelElem.Visible = false; labelIndex.Visible = false; 
            Box.Visible = false; labelSort.Visible = false;
            Box.Clear(); BoxPoisk.Clear(); labelOtvetChislo.Text = ""; 
            numericUpDown1.Value = 0;
        }
    }
}
