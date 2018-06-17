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
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;
using System.Security.Permissions;


namespace pavement_roughness_quick_measuring
{
    public partial class Form1 : Form
    {
        List<double[]> accdata1 = new List<double[]>();
        List<double[]> accdata2 = new List<double[]>();
        //List<DateTime> timedata = new List<DateTime>();
        List<GPSdata> gps = new List<GPSdata>();
        public int readnum = 0;
        public int handlenum = 0;
        public int nownum = 0;
        public int[] readpoint = { 0, 0 };
        public byte[] buf1 = new byte[8192];
        public byte[] buf2 = new byte[8192];
        public Queue<double> ChartQueue1 = new Queue<double>(500);
        public Queue<double> ChartQueue2 = new Queue<double>(500);
        private int num = 200;
        public double[] IRIThreshold = { 100, 95, 90, 85, 80, 0 };
        bool autochecked = true;
        bool ismanualState = false;
        bool ifsave = false;
        double dist_interval = 200;
        bool isrunning = false;
        //SerPort GPSPort1;
        // SerPort ACCPort1;
        //SerPort ACCPort2;
        GPSdata currentGPS;
        // GPSdata formerGPS;
        int GPS_index = 0;
        FileStream fs_log = null;
        bool accPortExist = false;
        bool GPSPortExist = false;
        bool PortsOpen = false;
        //results
        public List<double> iriresults = new List<double>();
        public List<double> latitude = new List<double>();
        public List<double> longitude = new List<double>();
        public List<double> distance = new List<double>();
        public List<DateTime> measuredtime = new List<DateTime>();
        GPSdata startGPS;
        DataTable results = new DataTable();
        public int ID = 0;
        //iri calculation coefficients
        public static double a1 = -4.53804;
        public static double a2 = -10.0891;
        public static double c = 100;
        //distance
        double Current_distance = 0;
        //double[] dist_interval = { 100, 200, 500, 1000 };

        //Mysql info
        private MySqlConnection mycon;
        static public string MySQL_IP = "localhost";
        static public string MySQL_Port = "3306";
        static public string MySQL_Account = "tongji";
        static public string MySQL_Passwords = "tjjt";
        static public string MySQL_Database = "PAVEMENT_CONDITION";
        bool DatabaseLinked = false;


        public struct PortInfo
        {
            static public string acc_comm = "COM1";
            static public string GPS_comm = "COM3";
            static public int acc_baudrate = 512000;
            static public int GPS_baudrate = 115200;
            static public int GPS_sf = 5;
            static public int accNum1 = 6;
            static public int accNum2 = 7;
            static public Byte[] Num6 = { 0x06, 0x06, 0x82, 0x12 };
            static public Byte[] Num7 = { 0x07, 0x07, 0x42, 0x42 };
            static public Byte[] Num8 = { 0x08, 0x08, 0x07, 0xB6 };
            static public Byte[] Num9 = { 0x09, 0x09, 0xC7, 0xE6 };
        }

        public struct GPSdata
        {
            public DateTime utcTime;
            public bool GPSStatus;
            public double latitude;
            public double longitude;
            public double dop;
            public double speed;
            public double Azimuth;
            public double Declinaion;
            public GPSdata(DateTime dt, bool sta, double lat, double longi, double d, double sp, double az, double de)
            {
                GPSStatus = sta;
                GPSStatus = sta;
                utcTime = dt;
                latitude = lat;
                longitude = longi;
                dop = d;
                speed = sp;
                Azimuth = az;
                Declinaion = de;
            }

            //distance calculation
            public double getDistance(GPSdata gd1, GPSdata gd2)
            {
                double radLat1 = gd1.latitude * Math.PI / 180;
                double radLog1 = gd1.longitude * Math.PI / 180;
                double radLat2 = gd2.latitude * Math.PI / 180;
                double radLog2 = gd2.longitude * Math.PI / 180;
                double r = 6380693.5;
                double dx = r * Math.Cos(radLat1) * Math.Abs(radLog1 - radLog2);
                double dy = r * Math.Abs(radLat1 - radLat2);
                double GPSDist = Math.Sqrt(dx * dx + dy * dy);
                if (GPSDist < 2.5)
                    return 0;
                else
                    return GPSDist;
            }
        }



        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //toolStripStatusLabel3.Text = ifsave.GetType().ToString() ;
            //chartDrawing();
            //log writting
            InitChart();
            string path = Application.StartupPath;
            string[] ports = SerialPort.GetPortNames();
            this.KeyPreview = true;
            // chart1.Visible = false;
            // label1.Visible = false;
            //label2.Visible = false;
            progressBar1.Visible = false;
            toolStripStatusLabel1.Text = "当前为自动模式";
            comboBox1.Text = "200";
            comboBox2.Text = PortInfo.accNum1.ToString();
            comboBox3.Text = PortInfo.accNum2.ToString();

            if (ports.Length < 2)
            {
                MessageBox.Show("检查串口是否连接正常");
                return;
            }
            if (!File.Exists(path + "\\log.txt"))
            {

                string filepath = path + "\\log.txt";
                Encoding encoder = Encoding.UTF8;
                DateTime dt = DateTime.Now;
                string startline = "*************" + dt.ToLongDateString() + "   " + dt.ToLongTimeString() + "****************" + "\r\n";
                byte[] bytes = encoder.GetBytes(startline);
                try
                {
                    fs_log = File.OpenWrite(filepath);
                    fs_log.Position = fs_log.Length;
                    fs_log.Write(bytes, 0, bytes.Length);
                }
                catch (Exception ex)
                {
                }

            }

            //ports setting
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
                    if (collumn == "acceleration baudrate")
                        PortInfo.acc_baudrate = int.Parse(str[1]);
                    else if (collumn == "acceleration comm")
                        PortInfo.acc_comm = str[1];
                    else if (collumn == "GPS comm")
                        PortInfo.GPS_comm = str[1];
                    else if (collumn == "GPS frequency")
                        PortInfo.GPS_sf = int.Parse(str[1]);

                }
            }
            sr.Close();

            for (int i = 0; i < ports.Length; i++)
            {
                if (PortInfo.acc_comm == ports[i])
                    accPortExist = true;
                if (PortInfo.GPS_comm == ports[i])
                    GPSPortExist = true;
            }

            if (!accPortExist || !GPSPortExist)
            {
                MessageBox.Show("串口无法匹配，需重新设置");
            }

            MySQLIni();



        }

        private void 加速度计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccSetting asform = new AccSetting();
            asform.ShowDialog();

        }

        private void ACCPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (ACCPort.BytesToRead >= 1)
            {
                try
                {
                    int n = ACCPort.BytesToRead;

                    ACCPort.Read(buf1, readnum, n);
                    readnum += n;


                }
                catch (System.Exception se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        private void 开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GPSPortExist || !accPortExist)
            {
                MessageBox.Show("串口不匹配，无法启动");
                return;
            }
            if (isrunning)
            {
                return;
            }
            try
            {
                ACCPort.PortName = PortInfo.acc_comm;
                ACCPort.BaudRate = PortInfo.acc_baudrate;
                ACCPort.Open();
                ACCPort.DiscardInBuffer();

                GPSPort.PortName = PortInfo.GPS_comm;
                GPSPort.BaudRate = PortInfo.GPS_baudrate;
                GPSPort.Open();
                GPSPort.DiscardInBuffer();
                PortInfo.accNum1 = int.Parse(comboBox2.Text);
                PortInfo.accNum2 = int.Parse(comboBox3.Text);
                PortsOpen = true;
                Acc1_check.Checked = true;
                Acc2_check.ForeColor = Color.Green;
                Acc2_check.Checked = true;
                Acc1_check.ForeColor = Color.Green;
                timer1.Enabled = true;
                timer1.Interval = 50;
                timer2.Enabled = true;
                timer2.Interval = 1000;
                timer3.Enabled = true;
                timer3.Interval = 100;
                dist_interval = double.Parse(comboBox1.Text);
                isrunning = true;

                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                acc1_num_tb.Enabled = false;
                acc2_num_tb.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;




                //log writing
                /* Encoding encoder = Encoding.UTF8;
                 string startline = "Ports opened successfully" + "\r\n";
                 byte[] bytes = encoder.GetBytes(startline);
                 fs_log.Position = fs_log.Length;
                 fs_log.Write(bytes, 0, bytes.Length);*/
                //datatable operation
                results.Columns.Add("ID", Type.GetType("System.Int16"));
                results.Columns.Add("IRI", Type.GetType("System.Double"));
                results.Columns.Add("Time", Type.GetType("System.String"));
                results.Columns.Add("distance", Type.GetType("System.Double"));
                results.Columns.Add("latitude", Type.GetType("System.Double"));
                results.Columns.Add("longitude", Type.GetType("System.Double"));


            }
            catch (System.Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void GPSPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (GPSPort.BytesToRead >= 10)
            {
                try
                {
                    string buf = GPSPort.ReadLine();
                    string[] info = buf.Split(',');

                    if (info[0] == "$GNGGA" && info[1] != "")
                    {
                        if (info[8] == "") currentGPS.dop = 99;
                        else
                            currentGPS.dop = double.Parse(info[8]);
                    }
                    else if (info[0] == "$GPRMC" && info[1] != "")
                    {
                        currentGPS.utcTime = GetTime(info[1], info[9]);
                        if (info[2] == "A") currentGPS.GPSStatus = true;
                        else currentGPS.GPSStatus = false;
                        currentGPS.latitude = Angle(info[3]);
                        currentGPS.longitude = Angle(info[5]);
                        currentGPS.speed = double.Parse(info[7]) * 1852 / 3600;
                        currentGPS.Azimuth = double.Parse(info[8]);
                        currentGPS.Declinaion = double.Parse(info[10]);
                        gps.Add(currentGPS);
                        InsertGPS(currentGPS);

                    }
                }
                catch (System.Exception ex)
                {
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //sending bytes to acceleration ports
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!PortsOpen)
                return;
            if (!autochecked && !ismanualState)
                return;
            if (nownum == 0)
            {
                nownum = 1;
                switch (PortInfo.accNum1)
                {
                    case 6:
                        ACCPort.Write(PortInfo.Num6, 0, 4);
                        break;
                    case 7:
                        ACCPort.Write(PortInfo.Num7, 0, 4);
                        break;
                    case 8:
                        ACCPort.Write(PortInfo.Num8, 0, 4);
                        break;
                    case 9:
                        ACCPort.Write(PortInfo.Num9, 0, 4);
                        break;

                }

            }
            else if (nownum == 1)
            {
                nownum = 0;
                switch (PortInfo.accNum2)
                {
                    case 6:
                        ACCPort.Write(PortInfo.Num6, 0, 4);
                        break;
                    case 7:
                        ACCPort.Write(PortInfo.Num7, 0, 4);
                        break;
                    case 8:
                        ACCPort.Write(PortInfo.Num8, 0, 4);
                        break;
                    case 9:
                        ACCPort.Write(PortInfo.Num9, 0, 4);
                        break;

                }
            }
            while (readnum >= (handlenum + 160))
            {
                for (int i = 0; i < 160; i++)
                {
                    if (buf1[i] == 0x06 || buf1[i] == 0x07)
                    {
                        byte[] tmpbuf = new byte[160];
                        Buffer.BlockCopy(buf1, i, tmpbuf, 0, 160);
                        if (CRC16(tmpbuf, 160) == 0)
                        {
                            if (tmpbuf[0] == 0x06)
                                bufferAna(tmpbuf, 0);
                            else if (tmpbuf[0] == 0x07)
                                bufferAna(tmpbuf, 1);

                            Buffer.BlockCopy(buf1, 160 + i, buf1, 0, readnum - 160);
                            readnum -= 160;
                            readnum -= i;
                            break;
                        }
                    }
                }
            }

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //gps operation
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!PortsOpen)
                return;
            if (!autochecked && !ismanualState)
                return;
            double thre = dist_interval;
            if (gps.Count >= 5 || ifsave)
            {
                progressBar1.Visible = true;
                GPS_check.Checked = true;
                GPS_check.ForeColor = Color.Green;
                if (gps.Count == 0)
                {
                    GPSdata g1 = new GPSdata(DateTime.Now, false, 0, 0, 99, 0, 0, 0);
                    GPSdata g2 = g1;
                    gps.Add(g1);
                    gps.Add(g2);
                    InsertGPS(g1);
                    InsertGPS(g2);
                }
                if (gps.Count == 2)
                {
                    startGPS = gps[0];

                }
                GPSdata gd1 = gps[GPS_index];
                GPSdata gd2 = gps[gps.Count - 1];
                Current_distance += getDistance(gd1, gd2);
                if ((Current_distance >= thre && autochecked) || ifsave)
                {
                    ID++;
                    double currentIRI = GetIRI();
                    accdata1 = new List<double[]>();
                    accdata2 = new List<double[]>();
                    DateTime dt = DateTime.Now;
                    iriresults.Add(currentIRI);
                    measuredtime.Add(dt);
                    latitude.Add(currentGPS.latitude);
                    longitude.Add(currentGPS.longitude);
                    distance.Add(Current_distance);
                    Color itemcolor = Color.WhiteSmoke;
                    int ColorIndex = IRILevel(currentIRI);
                    startGPS = currentGPS;
                    switch (ColorIndex)
                    {
                        case 0:
                            itemcolor = Color.WhiteSmoke;
                            break;
                        case 1:
                            itemcolor = Color.LightYellow;
                            break;
                        case 2:
                            itemcolor = Color.Yellow;
                            break;
                        case 3:
                            itemcolor = Color.Orange;
                            break;
                        case 4:
                            itemcolor = Color.OrangeRed;
                            break;
                        case 10:
                            itemcolor = Color.Blue;
                            break;
                    }
                    ListViewShow(ID, currentIRI, Current_distance, dt, itemcolor);
                    progressBar1.Value = (int)(currentGPS.speed * (double)progressBar1.Maximum / 108);
                    //database
                    string IRIID = acc1_num_tb + "-" + acc2_num_tb + "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string GPS_ID = currentGPS.utcTime.ToString("yyyyMMddHHmmssfff");
                    string sqlstr = "insert into IRI values('";
                    sqlstr += IRIID + "','" + GPS_ID + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + startGPS.latitude.ToString() + "," + startGPS.longitude.ToString() + ",";
                    sqlstr += currentGPS.latitude.ToString() + "," + currentGPS.longitude.ToString() + "," + currentIRI.ToString() + "," + Current_distance.ToString() + ");";
                    getmysqlcom(sqlstr);

                    //datatable
                    DataRow dr = results.NewRow();
                    dr["ID"] = ID;
                    dr["IRI"] = currentIRI;
                    dr["Time"] = dt.ToLongDateString();
                    dr["distance"] = Current_distance;
                    dr["latitude"] = gps[gps.Count - 1].latitude;
                    dr["longitude"] = gps[gps.Count - 1].longitude;
                    results.Rows.Add(dr);
                    if (ifsave)
                    {
                        toolStripStatusLabel1.Text = "记录成功";
                        ifsave = false;
                    }
                    Current_distance = 0;
                }
            }
        }

        //chart operation
        private void InitChart()
        {
            chart1.Visible = true;
            //chart properties
            //this.chart1.ChartAreas[0].AxisY.Minimum = -100;
            // this.chart1.ChartAreas[0].AxisY.Minimum = 100;
            //this.chart1.ChartAreas[0].AxisX.Interval = 2;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;

            this.chart1.Series[0].Color = Color.Red;
            this.chart1.Series[0].ChartType = SeriesChartType.Line;
            this.chart1.Series[1].Color = Color.Black;
            // this.chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

        }

        //update chartQueue
        private void UpdateChartQueue()
        {
            chart1.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            if (ChartQueue1.Count > 500)
            {

                ChartQueue1.Dequeue();
            }
            if (ChartQueue2.Count > 500)
            {

                ChartQueue2.Dequeue();

            }
            if (PortsOpen && accdata1.Count >= 1 && accdata2.Count >= 1)
            {
                double showdata1 = accdata1[accdata1.Count - 1][2];
                double showdata2 = accdata2[accdata2.Count - 1][2];
                ChartQueue1.Enqueue(showdata1);
                ChartQueue2.Enqueue(showdata2);
            }
        }


        //drawing
        private void timer3_Tick(object sender, EventArgs e)
        {
            UpdateChartQueue();
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            for (int i = 0; i < ChartQueue1.Count; i++)
            {
                chart1.Series[0].Points.AddXY((i + 1), ChartQueue1.ElementAt(i));
            }
            for (int i = 0; i < ChartQueue2.Count; i++)
            {
                chart1.Series[1].Points.AddXY((i + 1), ChartQueue2.ElementAt(i));
            }
            if (accdata1.Count > 0)
            {
                label1.Text = "加速度1：" + accdata1[accdata1.Count - 1][2].ToString();
                label1.ForeColor = Color.Red;
            }
            if (accdata2.Count > 0)
            {
                label2.Text = "加速度2：" + accdata2[accdata2.Count - 1][2].ToString();
                label2.ForeColor = Color.Black;
            }
            if (gps.Count > 0)
            {
                toolStripStatusLabel2.Text = "当前经纬度：" + currentGPS.latitude.ToString() + "，" + currentGPS.longitude.ToString();
            }
        }

        private void ListViewShow(int ID, double IRI, double Length, DateTime dt, Color col)
        {
            string[] listdata = new string[4];
            listdata[0] = ID.ToString();
            listdata[1] = IRI.ToString("f2");
            listdata[2] = Length.ToString();
            listdata[3] = dt.ToLongTimeString();
            ListViewItem lvi = new ListViewItem(listdata);
            lvi.BackColor = col;
            this.listView1.Items.Add(lvi);
        }

        private void 结束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                if (ACCPort.IsOpen)
                    ACCPort.Close();
                if (GPSPort.IsOpen)
                    GPSPort.Close();

                PortsOpen = false;
                accdata1 = new List<double[]>();
                accdata2 = new List<double[]>();
                gps = new List<GPSdata>();
                readnum = 0;
                handlenum = 0;
                nownum = 0;
                buf1 = new byte[8192];
                buf2 = new byte[8192];
                ChartQueue1 = new Queue<double>(500);
                ChartQueue2 = new Queue<double>(500);
                GPS_index = 0;
                PortsOpen = false;
                iriresults = new List<double>();
                latitude = new List<double>();
                longitude = new List<double>();
                distance = new List<double>();
                measuredtime = new List<DateTime>();
                ID = 0;
                autochecked = true;
                ismanualState = false;
                ifsave = false;
                isrunning = false;
                DataTable results = new DataTable();

                //distance
                Current_distance = 0;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                if (iriresults.Count > 0)
                    Save2CSV();
                if (ACCPort.IsOpen)
                    ACCPort.Close();
                if (GPSPort.IsOpen)
                    GPSPort.Close();
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //Application.Exit;
                this.Close();
            }

        }

        private void 重启ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Restart();
        }

        //saving results to csv file
        private void Save2CSV()
        {
            string filename = DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv";
            string savePath = Application.StartupPath + "\\" + filename;
            FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            for (int i = 0; i < results.Columns.Count; i++)
            {
                sw.Write(results.Columns[i].ColumnName);
                sw.Write("\t");
            }
            sw.WriteLine("");
            for (int i = 0; i < results.Rows.Count; i++)
            {
                for (int j = 0; j < results.Columns.Count; j++)
                {
                    sw.Write(results.Rows[i][j].ToString());
                    sw.Write("\t");
                }
                sw.WriteLine("");
            }
            sw.Flush();
            sw.Close();
            fs.Close();
            MessageBox.Show("已存储");

        }

        private void 存储当前结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Save2CSV();

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (autochecked)
                return;

            if (Keys.Escape == e.KeyCode && ismanualState)
            {

                ismanualState = false;
                toolStripStatusLabel1.Text = "已结束当前测量";

            }
            else if (Keys.Space == e.KeyCode && ismanualState && !ifsave)
            {
                ifsave = true;
            }
        }

        private void 计算模型设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModelSetting nf = new ModelSetting();
            nf.ShowDialog();
        }

        private void 监视ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int SelectedIndex = listView1.SelectedItems[0].Index;

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Db_check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            开启ToolStripMenuItem_Click(sender, e);
        }

        private void 服务器设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MysqlSetForm nf = new MysqlSetForm();
            nf.Show();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            ismanualState = true;
            toolStripStatusLabel1.Text = "数据开始采集，按空格结束该路段";
            autochecked = false;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            radioButton1.Checked = true;
            toolStripStatusLabel1.Text = "当前为自动模式";
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
            radioButton4.Checked = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioButton4.Checked = true;
            radioButton3.Checked = false;
        }
    }

}
