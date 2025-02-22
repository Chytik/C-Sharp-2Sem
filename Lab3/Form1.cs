using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Лаба_Окончательная
{
    public partial class Form1 : Form
    {
        public BinarySearchTree bst = new BinarySearchTree();
        public SingleLinkedList sll = new SingleLinkedList();
        //public int[] arr;
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false; treeView1.Visible = false;
            label2.Visible = false; listBox1.Visible = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) { Application.Exit(); }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) { O_Proge o_Proge = new O_Proge(); o_Proge.Show(); this.Hide(); }

        private void созданиеДереваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count != 0) MessageBox.Show("дерево уже создано, чтобы создать новое, сначала разруште старое", "Ошибка");
            else
            {
                this.Enabled = false;
                Derevo derevo = new Derevo();
                derevo.ShowDialog();
                //string text = derevo.textBox1.Text;
                //string[] numbersStrings = text.Split(' ');
                string[] numbers = listBox1.Items.Cast<string>().ToArray();
                foreach (string number in numbers) bst.Insert(int.Parse(number));
                treeView1.Nodes.Clear();
                TreeNode rootNode = new TreeNode("Корень");
                treeView1.Nodes.Add(rootNode);
                FillTreeView(bst.Root, rootNode);
                treeView1.ExpandAll();
                label1.Visible = true; treeView1.Visible = true;
            }
        }
        private void FillTreeView(NodeTree node, TreeNode treeNode)
        {
            if (node != null)
            {
                TreeNode newNode = new TreeNode(node.Key.ToString());
                treeNode.Nodes.Add(newNode);
                FillTreeView(node.Left, newNode);
                FillTreeView(node.Right, newNode);
            }
        }

        private void обработкаДереваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count == 0) MessageBox.Show("Дерево еще не создано, сначала создайте дерево, а потом обрабатывайте его", "Ошибка");
            else
            {
                this.Enabled = false;
                listBox1.Items.Clear();
                Obrabotka ob = new Obrabotka();
                ob.ShowDialog();
                label2.Visible = true; listBox1.Visible = true;
            }
        }

        private void разрушениеДереваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count == 0) MessageBox.Show("Дерево еще не создано, сначала создайте дерево, а потом разрушайте его", "Ошибка");
            else
            {
                bst.Destroy();
                label2.Visible = false; listBox1.Visible = false;
                treeView1.Nodes.Clear();
            }
        }
    }
}
