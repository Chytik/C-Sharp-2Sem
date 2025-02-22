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
    public partial class Form1 : Form
    {
        SingleLinkedList sll = new SingleLinkedList();
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

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) { Avtor avtor = new Avtor(); avtor.Show(); this.Hide(); }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) { Application.Exit(); }

        private void созданиеСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count != 0) MessageBox.Show("Список уже создан, чтобы создать новый, ссначала разруште старый", "Ошибка");
            else
            {
                this.Enabled = false;
                Sozdanie sozdanie = new Sozdanie();
                sozdanie.ShowDialog();
                sll.CreateList(ReadWordsFromListBox());
                label1.Visible = true;
                list.Visible = true; 
            }
        }

        private void разрушениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Списка уже не существует", "Внимание");
            else
            {
                sll.DeleteList();
                list.Items.Clear();
                //label1.Visible = false; label2.Visible = false; label3.Visible = false;
                //list.Visible = false; list1.Visible = false; list2.Visible = false;
            }
        }

        private void вНачалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFirst af = new AddFirst();
            this.Enabled = false;
            af.ShowDialog();
            sll.AddToBeginning(af.textBox1.Text);
            sll.CreateList(ReadWordsFromListBox());
            label1.Visible = true;
            list.Visible = true; 
        }

        private void вКонецToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddEnd ae = new AddEnd();
            this.Enabled = false;
            ae.ShowDialog();
            sll.AddToEnd(ae.textBox1.Text);
            sll.CreateList(ReadWordsFromListBox());
            label1.Visible = true;
            list.Visible = true;
        }
        private void вПроизвольноеМестоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPlace ap = new AddPlace();
            this.Enabled = false;
            ap.ShowDialog();
            sll.AddToPosition(int.Parse(ap.Box2.Text), ap.Box1.Text);
            sll.CreateList(ReadWordsFromListBox());
            label1.Visible = true;
            list.Visible = true; 
        }

        private void изНачалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Список пуст, удалять нечего", "Внимание");
            else
            {
                list.Items.RemoveAt(0);
                sll.RemoveFromBeginning();
                sll.CreateList(ReadWordsFromListBox());
            }
        }

        private void изКонцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Список пуст, удалять нечего", "Внимание");
            else
            {
                list.Items.RemoveAt(list.Items.Count - 1);
                sll.RemoveFromEnd();
                sll.CreateList(ReadWordsFromListBox());
            }
        }

        private void изПроизвольногоМестаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Список пуст, удалять нечего", "Внимание");
            else
            {
                DellPlace dp = new DellPlace();
                this.Enabled = false;
                dp.ShowDialog();
                sll.RemoveFromEnd();
                sll.CreateList(ReadWordsFromListBox());
            }
        }

        private void обработкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (list.Items.Count == 0) MessageBox.Show("Список пуст, сначала его нужно заполнить", "Внимание");
            else
            {
                FoundFirst ff = new FoundFirst();
                this.Enabled = false;
                ff.ShowDialog();
                SingleLinkedList listStartingWith = new SingleLinkedList();
                SingleLinkedList listEndingWith = new SingleLinkedList();
                sll.GetListsBasedOnKeyword(ff.Box.Text, listStartingWith, listEndingWith);
                list1.Items.Clear();
                list2.Items.Clear();
                while (listStartingWith.first != null)
                {
                    list1.Items.Add(listStartingWith.first.Data);
                    listStartingWith.first = listStartingWith.first.Link;
                }
                while (listEndingWith.first != null)
                {
                    list2.Items.Add(listEndingWith.first.Data);
                    listEndingWith.first = listEndingWith.first.Link;
                }
                this.Enabled = true;
                label2.Visible = true; label3.Visible = true;
                list1.Visible = true; list2.Visible = true;
            }
        }
    }
}
