using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Лаба_2._1
{
    public class DoubleNode
    {
        public string Data { get; set; }
        public DoubleNode Next { get; set; }
        public DoubleNode Prev { get; set; }
        public DoubleNode() { Next = null; Prev = null; }
        public DoubleNode(string data) { Data = data; }
        public DoubleNode(string data, DoubleNode next, DoubleNode prev) { Data = data; Next = next; Prev = prev; }
    }
    public class CycleDoubleLinkedList
    {
        public DoubleNode head;

        public CycleDoubleLinkedList() { head = new DoubleNode(); head.Next = head; head.Prev = head; }

        public void CreateList(string[] words)
        {
            DoubleNode p;
            for (int i = 0; i < words.Length; i++)
            {
                p = new DoubleNode(words[i]); // создание узла списка}
                p.Next = head;
                p.Prev = head.Prev;
                head.Prev.Next = p;
                head.Prev = p;
            }
        }

        public void DeleteList() { head = new DoubleNode(); head.Next = head; head.Prev = head; }

        public void AddToBeginning(string word)
        {
            DoubleNode newNode = new DoubleNode(word);
            newNode.Next = head.Next;
            newNode.Prev = head;
            head.Prev = newNode;
            head.Next = newNode;
        }

        public void AddToEnd(string word)
        {
            DoubleNode newNode = new DoubleNode(word);
            newNode.Next = head;
            newNode.Prev = head.Prev;
            head.Next = newNode;
            head.Prev = newNode;
        }

        public void AddToPosition(int position, string word)
        {
            if (position == 0) AddToBeginning(word);
            else
            {
                DoubleNode current = head; int i = 0;
                while (current.Next != head && i < position - 1)
                {
                    current = current.Next; i++;
                }
                if (current.Next == head) AddToEnd(word);
                else
                {
                    DoubleNode newNode = new DoubleNode(word);
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    current.Next.Prev = newNode;
                    current.Next = newNode;
                }
            }
        }

        public void RemoveFromBeginning()
        {
            if (head != null)
            {
                DoubleNode secondNode = head.Next;
                head.Next = secondNode.Next;
                secondNode.Next.Prev = head;
                head = secondNode.Prev;
            }
        }

        public void RemoveFromEnd()
        {
            if (head != null)
            {
                DoubleNode lastNode = head.Prev;
                head.Prev = lastNode.Prev;
                lastNode.Prev.Next = head;
            }
        }

        public void RemoveFromPosition(int position)
        {
            if (head != null)
            {
                if (position == 0) RemoveFromBeginning();
                else
                {
                    DoubleNode current = head; int i = 0;
                    while (current.Next != head && i < position - 1)
                    {
                        current = current.Next; i++;
                    }
                    current.Next = current.Next.Next;
                    current.Next.Prev = current;
                }
            }
        }

        public void GetListsBasedOnKeyword(string keyword, CycleDoubleLinkedList newList1, CycleDoubleLinkedList newList2)
        {
            DoubleNode current = head.Next;
            while (current != head) 
            {
                if(current.Data != null)
                {
                    if (current.Data.StartsWith(keyword)) newList1.AddToEnd(current.Data);
                    if (current.Data.EndsWith(keyword)) newList2.AddToEnd(current.Data);
                }
                current = current.Next;
            } 
        }
    }
}
