using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using do_an_dsa.Objects;

namespace do_an_dsa
{
    public class DSFileHTML
    {
        public MyQueue dsFile = new MyQueue();
        public MyQueue DSFile { get => dsFile; set => dsFile = value; }
        public DSFileHTML() { }

        public void enqueueDS(FileHTML file) {
            DSFile.Enqueue(file);
        }
        public FileHTML dequeueDS()
        {
            return (FileHTML)DSFile.Dequeue().data;
        }
        public int demDS() {
            return DSFile.Count();
        }
        public Node layNode(int index)
        {
            return DSFile.GetNode(index);
        }



    }
}
