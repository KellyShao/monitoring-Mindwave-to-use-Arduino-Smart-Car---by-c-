using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace testprogram
{
    class SerialWriter
    {
        // 这个端口名称表示连接小车的usb端口名称，如"COM1", "COM2"...，我们暂时做demo，明确之后手动设置
        // 后续可做GUI，让用户选择
        private string portName;
        private SerialPort serialPort;

        public SerialWriter(string strName)
        {
            serialPort = new SerialPort(strName, 9600, Parity.None, 8, StopBits.One);
        }

        public void OpenPort()
        {
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
        }

        // 向蓝牙端口发送字节
        public void WriteBytes(byte[] bytes)
        {
            serialPort.Write(bytes, 0, 8);
        }
    }
}
