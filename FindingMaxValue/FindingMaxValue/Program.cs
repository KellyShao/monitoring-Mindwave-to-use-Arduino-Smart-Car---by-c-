using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindingMaxValue
{
    class Program
    {
        static void Main(string[] args)
        {
            DataQueue dq = new DataQueue();
            ReadWork rw = new ReadWork(dq);
            WriteWorker ww = new WriteWorker(dq, rw);
            Thread wthread = new Thread(ww.DoWork);
            wthread.Start();
        }
    }
}
