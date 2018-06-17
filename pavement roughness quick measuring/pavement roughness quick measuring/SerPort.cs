using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace pavement_roughness_quick_measuring
{
    class SerPort
    {
        private Queue<Byte> buffer;
        private SerialPort sp;
        private byte[] newline;
        private int newlineCount;

        public SerPort(SerialPort serport, byte[] newLine)
        {
            buffer = new Queue<Byte>();
            sp = serport;
            newline = newLine;
            newlineCount = 0;
        }

        public byte[] NewLine
        {
            get { return newline; }
            set { newline = value; }
        }

        //
        // 摘要:
        //     清空缓存。
        //  
        public void DiscardBuffer()
        {
            buffer.Clear();
        }

        //
        // 摘要:
        //     获取缓存大小。
        // 返回:
        //      返回此类中缓冲区剩余字节数
        public int GetBufferLength()
        {
            return buffer.Count;
        }

        //
        // 摘要:
        //     读取一行，以SerPort.NewLine为结束符。
        // 返回:
        //      到SerPort.NewLine之前一个字节的所有字节。
        // 异常:
        //      若读取失败，则返回null。
        public Byte[] SerialPort_ReadLine()
        {
            byte temp;
            while (sp.BytesToRead >= 1)
            {
                temp = (byte)sp.ReadByte();
                buffer.Enqueue(temp);
                if (temp == newline[newlineCount]) newlineCount++;
                else newlineCount = 0;
                if (newlineCount == 2)
                {
                    byte[] buf = buffer.ToArray();
                    buffer.Clear();
                    newlineCount = 0;
                    return buf;
                }
            }
            return null;
        }

        //
        // 摘要:
        //     读取缓存中所有行，以SerPort.NewLine为结束符。
        // 返回:
        //      以SerPort.NewLine为行结尾的所有行。
        // 注意:
        //      如果读不到任何行，则返回的List大小为0，而不是返回null。
        public List<Byte[]> SerialPort_ReadAllLines()
        {
            List<Byte[]> list = new List<Byte[]>();
            byte[] buf;
            while (sp.BytesToRead >= 1)
            {
                buf = SerialPort_ReadLine();
                if (buf != null) list.Add(buf);
                else break;
            }
            return list;
        }
    }
}
