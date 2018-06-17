using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace pavement_roughness_quick_measuring
{
    public partial class AccSetting : Form
    {
        public AccSetting()
        {
            InitializeComponent();
        }

        private void AccSetting_Load(object sender, EventArgs e)
        {
            string[] portnames = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(portnames);
            comboBox2.Items.AddRange(portnames);
            comboBox1.Text = Form1.PortInfo.acc_comm;
            comboBox2.Text = Form1.PortInfo.GPS_comm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("串口冲突，请重新选择。");
                return;
            }
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("串口未选择。");
                return;
            }
            Form1.PortInfo.acc_comm = comboBox1.Text;
            Form1.PortInfo.GPS_comm = comboBox2.Text;
            string formerAccComm="";
            string formerGPSComm="";
            string newAccComm = "";
            string newGPSComm = "";
            string settings_path = Application.StartupPath + "\\settings.ini";
            StreamReader sr = new StreamReader(settings_path, Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Length > 0 && line[0] == '#')
                {
                    string[] str = line.Split(':');
                    int len = str[0].Length;
                    string collumn = str[0].Substring(1, len - 1);
                    if (collumn == "acceleration comm")
                    {
                        formerAccComm = collumn + ":" + str[1];
                        newAccComm = collumn + ":" + comboBox1.Text;
                    }
                    else if (collumn == "GPS comm")
                    {
                        formerGPSComm = collumn + ":" + str[1];
                        newGPSComm = collumn + ":" + comboBox2.Text;
                    }

                }
            }
            sr.Close();
            sr = new StreamReader(settings_path);
            string strr = sr.ReadToEnd();
            strr = strr.Replace(formerAccComm, newAccComm);
            strr = strr.Replace(formerGPSComm, newGPSComm);
            sr.Close();
            StreamWriter sw = new StreamWriter(settings_path, false);
            sw.WriteLine(strr);
            sw.Close();
            
        }
    }
}
