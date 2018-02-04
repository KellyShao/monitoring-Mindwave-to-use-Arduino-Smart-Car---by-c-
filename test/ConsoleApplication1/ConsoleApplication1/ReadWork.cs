using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testprogram
{
    class ReadWork
    {
        // 这一块需要你们定义，可能不止这几个值
        //public const int FORWORD = 50;
        //public const int BACKWORD = 100;
        public const int CON_MAX_FORWARD = 1000 ;
        public const int CON_MAX_LEFT = 2000;
        //public const int CON_MAX_RIGHT = 1600;
        public const int CON_MAX_PAUSE = 500;

        public const int CON_FORWARD = 1;
        public const int CON_STOP = 0;
        public const int CON_LEFT = 3;
        public const int CON_RIGHT = 4;

        private DataQueue m_data;

        // 记录上一次小车的动作，值为0表示stop， 1表示前进
        // 2表示后退，3表示左转， 4表示右转 等等，这一块你们做主
        private int m_lastAction = CON_STOP;

        // 定义端口句柄
        private SerialPort m_sp;

        // 构造函数
        public ReadWork(DataQueue dq, string strPortName = "COM11")
        {
            m_data = dq;
            m_lastAction = 0;

            m_sp = new SerialPort();
            m_sp.PortName = strPortName;
        }

        // 打开串口
        private void openSerialPort()
        {
            m_sp.Open();
            m_sp.BaudRate = 9600;
            m_sp.ReadTimeout = 1000;
            //m_sp.ReadTimeout = 100000;
        }

        // 关闭串口
        private void closeSerialPort()
        {
            m_sp.Close();
        }

        // 从读列表中读取所有的数据，进行判断，判断逻辑你们自己写

        public void DoWork()
        {
            int iNum = 0;
            openSerialPort();

            int iMax = 0;
            //m_sp.Write("F");
            while (true)
            {
                while (!m_data.IsEmpty())
                {
                    int iData = m_data.ReadDataFromQueue();
                    // 从这里开始，童鞋们写自己的逻辑，下面的语句仅仅用于测试，后续注释掉
                    Console.WriteLine("{0} : iData  {1}", iNum, iData);
                    iNum++;

                    /*if (Math.Abs(iData) > iMax)
                    {
                        iMax = Math.Abs(iData);
                    }*/
                    iMax = Math.Abs(iData);

                    //SerialPort sp = new SerialPort();
                    //sp.PortName = "COM10";
                    //sp.BaudRate = 9600;
                    //sp.ReadTimeout = 1000;
                    if (iMax < CON_MAX_PAUSE)
                    {
                        if (m_lastAction != CON_STOP)
                        m_sp.Write("P");

                        m_lastAction = CON_STOP;
                    }
                    else if (iMax < CON_MAX_FORWARD && iMax >= CON_MAX_PAUSE)
                    //sp.Open();
                    {
                        if (m_lastAction != CON_FORWARD)
                        m_sp.Write("F");
                        //m_lastAction = CON_;
                        //m_sp.Close(); }//静默直走
                        m_lastAction = CON_FORWARD;
                    }
                    else if (iMax >= CON_MAX_FORWARD && iMax < CON_MAX_LEFT)
                    {
                        if (m_lastAction != CON_LEFT)
                        m_sp.Write("B");
                        // m_sp.Close();//眨眼左转
                        m_lastAction = CON_LEFT;
                    }
                    /*else//(iMax >= CON_MAX_LEFT)
                    {
                        if (m_lastAction != CON_RIGHT)
                        m_sp.Write("R");
                        //m_sp.Close();//挥拳右转
                        m_lastAction = CON_RIGHT;
                    }*/


                }
                
                //m_sp.Write("F");
                m_data.SetReadIndex();

                if (m_data.m_bStop)
                    break;
            }

                // 读取结束之后，要读下一个时段的数据。因此，这里设置读列表下标
                // 后面这两个语句其实可以合并
                
                //m_data.SetWriteIndex();

                // 为避免冲突，特意睡眠1毫秒
               //Thread.Sleep(1000);
            

            closeSerialPort();
        }
    }

}
