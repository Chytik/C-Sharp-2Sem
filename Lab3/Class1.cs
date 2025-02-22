using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Лаба_Окончательная
{
    public class NodeTree
    {
        public int Key { get; set; }
        public NodeTree Left { get; set; }
        public NodeTree Right { get; set; }
        public NodeTree(int key) { Key = key; }
    }

    public class BinarySearchTree
    {
        public NodeTree Root { get; set; }

        public void Insert(int key)
        {
            NodeTree newNode = new NodeTree(key);
            if (Root == null) Root = newNode;
            else InsertRecursive(Root, newNode);
        }

        private void InsertRecursive(NodeTree current, NodeTree newNode)
        {
            if (newNode.Key < current.Key)
            {
                if (current.Left == null) current.Left = newNode;
                else InsertRecursive(current.Left, newNode);
            }
            else
            {
                if (current.Right == null) current.Right = newNode;
                else InsertRecursive(current.Right, newNode);
            }
        }
        public void Destroy()
        {
            DestroyRecursive(Root);
            Root = null;
        }

        private void DestroyRecursive(NodeTree node)
        {
            if (node != null)
            {
                DestroyRecursive(node.Left);
                DestroyRecursive(node.Right);
                node = null;
            }
        }
    }
    public class NodeQ
    {
        public int Data { get; set; }
        public NodeQ Link { get; set; }

        public NodeQ(int data) { Data = data; }
        public NodeQ(int data, NodeQ link) { Data = data; Link = link; }
    }
    public class SingleLinkedList
    {
        public NodeQ first;

        public SingleLinkedList() { first = null; }

        public SingleLinkedList CreateList(BinarySearchTree tree, int key)
        {
            SingleLinkedList list = new SingleLinkedList();
            CreateListRecursive(tree.Root, key, list);
            return list;
        }

        private void CreateListRecursive(NodeTree node, int key, SingleLinkedList list)
        {
            if (node != null && node.Key == key)
            {
                NodeQ newNode = new NodeQ(node.Key);
                newNode.Link = list.first;
                list.first = newNode;
            }
            if (node != null)
            {
                CreateListRecursive(node.Left, key, list);
                CreateListRecursive(node.Right, key, list);
            }
        }
    }
}