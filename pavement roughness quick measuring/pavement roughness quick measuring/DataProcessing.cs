using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pavement_roughness_quick_measuring
{
    public partial class Form1 : Form
    {

        //Crc计算：
        UInt16 CRC16(byte[] tmp, byte num)
        {
            UInt16 crc = 0xFFFF;   /*预设值*/
            byte i = 0, j = 0;
            byte tmpcrc = 0;
            for (i = 0; i < num; i++)
            {
                tmpcrc = (byte)(crc & 0xff);
                tmpcrc ^= tmp[i];
                crc &= 0xff00;
                crc |= (UInt16)(tmpcrc | 0x0);     /*低8位异或*/

                for (j = 0; j < 8; j++)
                {
                    if (0x1 == (crc & 0x1))   /*最低位为1*/
                    {
                        crc >>= 1;  /*右移一位*/
                        crc &= (0x7FFF); /*最高位补0*/
                        crc ^= 0xA001;   /*与A001H异或*/
                    }
                    else            /*为0*/
                    {
                        crc >>= 1;      /*右移1位*/
                    }
                }
            }
            return crc;
        }

        //acc buffer data analysis
        private void bufferAna(byte[] buf1, int index)
        {
            if (buf1.Length != 160)
                return;
            else
            {
                int buflen = 150;
                for (int i = 0; i < buflen; i += 6)
                {
                    double[] tmpacc = new double[3];
                    tmpacc[0] = (double)(buf1[i + 1] + buf1[i + 2] * 256);
                    tmpacc[1] = (double)(buf1[i + 3] + buf1[i + 4] * 256);
                    tmpacc[2] = (double)(buf1[i + 5] + buf1[i + 6] * 256);
                    for (int j = 0; j < 3; j++)
                    {
                        if (tmpacc[j] > 10000)
                            tmpacc[j] -= 65536;
                    }
                    if (index == 0)
                        accdata1.Add(tmpacc);
                    else if (index == 1) 
                        accdata2.Add(tmpacc);
                }
            }

        }
        //time info processing
        private DateTime GetTime(string str,string str2)
        {
            double time = double.Parse(str);
            int hour = (int)(time / 10000 );
            int minute = (int)((time - 10000 * (hour )) / 100);
            int second = (int)(time - 10000 * (hour ) - minute * 100);
            int millisecond = (int)(time * 1000) - hour * 10000000 - minute * 100000 - second * 1000;
            double date = double.Parse(str2);
            int day = (int)(date / 10000);
            int month = (int)((date - 10000 * (day)) / 100);
            int year = (int)(date - 10000 * (day) - month * 100)+2000;
            DateTime newdt = new DateTime(year, month, day, hour, minute, second,millisecond);
            newdt = newdt.AddHours(8);
            return newdt;
        }
        //GPS format transform
        private double Angle(string str)
        {
            double initial = double.Parse(str);
            int ang = (int)(initial / 100);
            double min = (initial - (double)ang * 100) / 100 / 0.6;
            double GPSAngle = (double)ang + min;
            return GPSAngle;
        }

        //distance calculation
        
    }
}
