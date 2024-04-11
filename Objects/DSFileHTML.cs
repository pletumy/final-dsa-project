using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void dequeueDS()
        {
            DSFile.Dequeue();
        }
        public int demDS() {
            return DSFile.Count;
        }
        public object layChiSo(int index)
        {
            return DSFile.LayFileTuChiSo(index);
        }



    }
}
