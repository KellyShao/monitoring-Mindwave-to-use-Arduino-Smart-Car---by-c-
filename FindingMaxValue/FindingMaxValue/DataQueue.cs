using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingMaxValue
{
    class DataQueue //（定义关键字）
    {
        // 指示读数据的队列下标(读线程）
        private int m_readIndex;
        // 指示写数据的队列下标（写线程）
        private int m_writeIndex;

        // 两个队列，交互用来存储数据和传递数据，当写线程向A队列写数据时
        // ，读线程从B队列中读数据；反之，交换
        private Queue<int>[] m_queue;

        // 构造函数，初始化
        public DataQueue() //（创建队列？）
        {
            m_readIndex = 0;
            m_writeIndex = 0;
            m_queue = new Queue<int>[2];//两个队列
            m_queue[0] = new Queue<int>();
            m_queue[1] = new Queue<int>();
        }

        // 向队列中写数据
        // num指示写入的数据
        public void WriteData2Queue(int num) //（函数声明）
        {
            m_queue[m_writeIndex].Enqueue(num); //（将data2queue放入队列？）
        }

        // 从（m_queue)队列中读取数据
        // 返回值为读取的值
        public int ReadDataFromQueue()
        {
            if(m_queue.Count() > 0) //(容量判断）
            {
                return m_queue[m_readIndex].Dequeue(); //(dequeue：出队列）
            }

            return -10000;           
        } 

        // 设置读下标
        public void SetReadIndex()
        {
            if (m_readIndex == 0)
                m_readIndex = 1;
            else
                m_readIndex = 0;
        }

        // 设置写下标
        public void SetWriteIndex()
        {
            if (m_writeIndex == 0)
                m_writeIndex = 1;
            else
                m_writeIndex = 0;
        }

        // 判断读取列表是否为空
        public bool IsEmpty()
        {
            if (m_queue[m_readIndex].Count() > 0)
                return false;

            return true;
        }
    }
}
