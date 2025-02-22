using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_преисполнение
{
    public class Node
    {
        public string Data { get; set; }
        public Node Link { get; set; }

        public Node(string data) { Data = data; }
        public Node(string data, Node link) { Data = data; Link = link; }
    }
    public class SingleLinkedList
    {
        public Node first;

        public SingleLinkedList() { first = null; }

        public void CreateList(string[] words)
        {
            Node current = first;
            foreach (string word in words)
            {
                if (current == null)
                {
                    first = new Node(word);
                    current = first;
                }
                else
                {
                    current.Link = new Node(word);
                    current = current.Link;
                }
            }
        }

        public void DeleteList() { first = null; }

        public void AddToBeginning(string word)
        {
            Node newNode = new Node(word);
            newNode.Link = first;
            first = newNode;
        }
        public void AddToEnd(string word)
        {
            Node newNode = new Node(word);
            if (first == null) first = newNode;
            else
            {
                Node current = first;
                while (current.Link != null) current = current.Link;
                current.Link = newNode;
            }
        }

        public void AddToPosition(int position, string word)
        {
            Node newNode = new Node(word);
            if (position == 0)
            {
                newNode.Link = first;
                first = newNode;
            }
            else
            {
                Node current = first;
                int i = 0;
                while (current!=null && current.Link != null && i < position - 1)
                {
                    current = current.Link; i++;
                }
                newNode.Link = current.Link;
                current.Link = newNode;
            }
        }

        public void RemoveFromBeginning() { if (first != null) first = first.Link; }

        public void RemoveFromEnd()
        {
            if (first != null)
            {
                if (first.Link == null) first = null;
                else
                {
                    Node current = first;
                    while (current.Link!=null && current.Link.Link != null) current = current.Link;
                    current.Link = null;
                }
            }
        }

        public void RemoveFromPosition(int position)
        {
            if (first != null)
            {
                if (position == 0) first = first.Link;
                else
                {
                    Node current = first;
                    int i = 0;
                    while (current != null && current.Link != null && i < position - 1)
                    {
                        current = current.Link; i++;
                    }
                    if (current.Link != null) current.Link = current.Link.Link;
                }
            }
        }

        public void GetListsBasedOnKeyword(string keyword, SingleLinkedList newList1, SingleLinkedList newList2)
        {
            Node current = first;

            while (current != null)
            {
                if (current.Data.StartsWith(keyword)) newList1.AddToEnd(current.Data);
                if (current.Data.EndsWith(keyword)) newList2.AddToEnd(current.Data);
                current = current.Link;
            }
        }
    }
}
