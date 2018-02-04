using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindingMaxValue
{
    class WriteWorker
    {
        private DataQueue m_data;
        private ReadWork m_read;

        public WriteWorker(DataQueue dq, ReadWork rw)
        {
            m_data = dq;
            m_read = rw;
        }

        // 这里面是向队列中写数据，模拟从耳机中获取到的数据
        public void DoWork()
        {
            int i = 0;
            while(i < 1000)
            {
                m_data.WriteData2Queue(i);
                i++;
            }
            m_data.SetWriteIndex();
            Thread readThread = new Thread(m_read.DoWork);
            readThread.Start();

            while (i < 100000000)
            {
                m_data.WriteData2Queue(i);
                i++;
            }
        }
    }
}
