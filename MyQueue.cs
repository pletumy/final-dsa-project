using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an_dsa
{
    public class MyQueue
    {
        private class Node
        {
            public object File { get; set; }
            public Node Next { get; set; }

            public Node(object file, Node next)
            {
                File = file;
                Next = next;
            }
        }

        private Node head;
        private Node tail;

        public void Enqueue(object file)
        {
            Node newNode = new Node(file, null);

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
        }

        public object Dequeue()
        {
            if (head == null)
                throw new InvalidOperationException("Hàng đợi rỗng.");

            object file = head.File;
            head = head.Next;

            if (head == null)
                tail = null;

            return file;
        }

        public int Count
        {
            get
            {
                int count = 0;
                Node current = head;

                while (current != null)
                {
                    count++;
                    current = current.Next;
                }

                return count;
            }
        }
        public object LayFileTuChiSo(int chiSo)
        {
            if (chiSo < 0 || chiSo >= Count)
                throw new IndexOutOfRangeException("Chỉ số không hợp lệ.");

            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (index == chiSo)
                    return current.File;

                index++;
                current = current.Next;
            }

            return null; 
        }

        public object Peek()
        {
            if (Count == 0)
            {
                throw new System.InvalidOperationException("Queue is empty");
            }

            return head.File;
        }
    }
}
