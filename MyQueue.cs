using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace do_an_dsa
{
    public class Node {
        public Node prev, next;
        public object data;
    }
    public class MyQueue
    {
        Node rear, front;
        public bool isEmpty() { 
            return rear == null || front == null;   
        }
        public void Enqueue(object ele) {
            Node n = new Node();
            n.data = ele;
            if (rear == null)
            {
                rear = n;
                front = n;
            }
            else { 
                rear.prev = n;  
                n.next = rear;
                rear = n;
            }
        }
        public Node Dequeue() { 
            if (front == null) return null;
            Node d = front;
            front = front.prev;
            if (front == null)
            {
                rear = null;
            }
            else front.next = null;
            return d;
        }
    }
}
