using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindingMaxValue
{
    class ReadWork
    {
        // 这一块需要你们定义，可能不止这几个值
        public const int FORWORD = 50;
        public const int BACKWORD = 100;

        private DataQueue m_data;

        // 记录上一次小车的动作，值为0表示stop， 1表示前进
        // 2表示后退，3表示左转， 4表示右转 等等，这一块你们做主
        private int m_lastAction;

        // 构造函数
        public ReadWork(DataQueue dq)
        {
            m_data = dq;
            m_lastAction = 0;
        }

        // 从读列表中读取所有的数据，进行判断，判断逻辑你们自己写
        public void DoWork()
        {
            while (true)
            {
                while (!m_data.IsEmpty())
                {
                    int iData = m_data.ReadDataFromQueue();
                    // 从这里开始，童鞋们写自己的逻辑，下面的语句仅仅用于测试，后续注释掉
                    Console.WriteLine("iData: {0}", iData);
                }

                // 读取结束之后，要读下一个时段的数据。因此，这里设置读列表下标
                // 后面这两个语句其实可以合并
                m_data.SetReadIndex();
                m_data.SetWriteIndex();

                // 为避免冲突，特意睡眠1毫秒
                Thread.Sleep(1000);
            }
        }            
    }
}
