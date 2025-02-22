using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Лаба_2._1
{
    public partial class Form1 : Form
    {
        CycleDoubleLinkedList cdll = new CycleDoubleLinkedList();
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false; label2.Visible = false; label3.Visible = false;
            list.Visible = false; list1.Visible = false; list2.Visible = false;
        }

        private string[] ReadWordsFromListBox()
        {
            string[] words = new string[list.Items.Count];
            for (int i = 0; i < list.Items.Count; i++) words[i] = list.Items[i].ToString();
            return words;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) { Info info = new Info(); info.ShowDialog(); this.Hide(); }

        private void созданиеСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count != 0) MessageBox.Show("Список уже создан, чтобы создать новый, ссначала разруште старый", "Ошибка");
            else
            {
                this.Enabled = false;
                Sozdanie sozdanie = new Sozdanie();
                sozdanie.ShowDialog();
                cdll.CreateList(ReadWordsFromListBox());
                label1.Visible = true;
                list.Visible = true;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) { Application.Exit(); }

        private void разрушениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Списка уже не существует", "Внимание");
            else
            {
                cdll.DeleteList();
                list.Items.Clear();
                //label1.Visible = false; label2.Visible = false; label3.Visible = false;
                //list.Visible = false; list1.Visible = false; list2.Visible = false;
            }
        }

        private void вНачалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStart aS = new AddStart();
            this.Enabled = false;
            aS.ShowDialog();
            cdll.AddToBeginning(aS.textBox1.Text);
            //cdll.CreateList(ReadWordsFromListBox());
            label1.Visible = true;
            list.Visible = true;
        }

        private void вКонецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLast al = new AddLast();
            this.Enabled = false;
            al.ShowDialog();
            cdll.AddToEnd(al.textBox1.Text);
            //cdll.CreateList(ReadWordsFromListBox());
            label1.Visible = true;
            list.Visible = true;
        }

        private void вПроизвольнуюПозициюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPosition ap = new AddPosition();
            this.Enabled = false;
            ap.ShowDialog();
            cdll.AddToPosition(int.Parse(ap.textBox2.Text), ap.textBox1.Text);
            //cdll.CreateList(ReadWordsFromListBox());
            label1.Visible = true;
            list.Visible = true;
        }

        private void изНачалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Список пуст, удалять нечего", "Внимание");
            else
            {
                list.Items.RemoveAt(0);
                cdll.RemoveFromBeginning();
                //cdll.CreateList(ReadWordsFromListBox());
            }
        }

        private void изКонцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Список пуст, удалять нечего", "Внимание");
            else
            {
                list.Items.RemoveAt(list.Items.Count - 1);
                cdll.RemoveFromEnd();
                //cdll.CreateList(ReadWordsFromListBox());
            }
        }

        private void изПроизвольнойПозицииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Список пуст, удалять нечего", "Внимание");
            else
            {
                DellPosition dp = new DellPosition();
                this.Enabled = false;
                dp.ShowDialog();
                cdll.RemoveFromEnd();
                //cdll.CreateList(ReadWordsFromListBox());
            }
        }

        private void обработкаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Poisk p = new Poisk();
            this.Enabled = false;
            p.ShowDialog();
            string keyword = p.textBox1.Text;
            if (p.textBox1.Text != "")
            {
                CycleDoubleLinkedList newList1 = new CycleDoubleLinkedList();
                CycleDoubleLinkedList newList2 = new CycleDoubleLinkedList();
                cdll.GetListsBasedOnKeyword(keyword, newList1, newList2);
                list1.Items.Clear();
                list2.Items.Clear();
                DoubleNode current = newList1.head;
                do
                {
                    current = current.Prev;
                    if (current.Data != null) list1.Items.Insert(0,current.Data);
                } while (current != newList1.head);
                current = newList2.head;
                do
                {
                    current = current.Prev;
                    if (current.Data != null) list2.Items.Insert(0,current.Data);
                } while (current != newList2.head);
                label2.Visible = true;
                list1.Visible = true;
                label3.Visible = true;
                list2.Visible = true;
            }
            else MessageBox.Show("Вы ничего не ввели!\r\nВведите хотя бы один символ.", "Ошибка");
            this.Enabled = true;
        }
    }
}
