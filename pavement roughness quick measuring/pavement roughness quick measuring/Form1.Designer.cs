namespace pavement_roughness_quick_measuring
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结束ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.监视ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.存储当前结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加速度计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算模型设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务器设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ACCPort = new System.IO.Ports.SerialPort(this.components);
            this.GPSPort = new System.IO.Ports.SerialPort(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.acc2_num_tb = new System.Windows.Forms.TextBox();
            this.acc1_num_tb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Db_check = new System.Windows.Forms.CheckBox();
            this.GPS_check = new System.Windows.Forms.CheckBox();
            this.Acc2_check = new System.Windows.Forms.CheckBox();
            this.Acc1_check = new System.Windows.Forms.CheckBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(1667, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开启ToolStripMenuItem,
            this.结束ToolStripMenuItem,
            this.监视ToolStripMenuItem,
            this.重启ToolStripMenuItem,
            this.存储当前结果ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 开启ToolStripMenuItem
            // 
            this.开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            this.开启ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.开启ToolStripMenuItem.Text = "开启";
            this.开启ToolStripMenuItem.Click += new System.EventHandler(this.开启ToolStripMenuItem_Click);
            // 
            // 结束ToolStripMenuItem
            // 
            this.结束ToolStripMenuItem.Name = "结束ToolStripMenuItem";
            this.结束ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.结束ToolStripMenuItem.Text = "结束";
            this.结束ToolStripMenuItem.Click += new System.EventHandler(this.结束ToolStripMenuItem_Click);
            // 
            // 监视ToolStripMenuItem
            // 
            this.监视ToolStripMenuItem.Name = "监视ToolStripMenuItem";
            this.监视ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.监视ToolStripMenuItem.Text = "监视";
            this.监视ToolStripMenuItem.Click += new System.EventHandler(this.监视ToolStripMenuItem_Click);
            // 
            // 重启ToolStripMenuItem
            // 
            this.重启ToolStripMenuItem.Name = "重启ToolStripMenuItem";
            this.重启ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.重启ToolStripMenuItem.Text = "重启";
            this.重启ToolStripMenuItem.Click += new System.EventHandler(this.重启ToolStripMenuItem_Click);
            // 
            // 存储当前结果ToolStripMenuItem
            // 
            this.存储当前结果ToolStripMenuItem.Name = "存储当前结果ToolStripMenuItem";
            this.存储当前结果ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.存储当前结果ToolStripMenuItem.Text = "存储当前结果";
            this.存储当前结果ToolStripMenuItem.Click += new System.EventHandler(this.存储当前结果ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加速度计ToolStripMenuItem,
            this.计算模型设置ToolStripMenuItem,
            this.服务器设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 加速度计ToolStripMenuItem
            // 
            this.加速度计ToolStripMenuItem.Name = "加速度计ToolStripMenuItem";
            this.加速度计ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.加速度计ToolStripMenuItem.Text = "串口设置";
            this.加速度计ToolStripMenuItem.Click += new System.EventHandler(this.加速度计ToolStripMenuItem_Click);
            // 
            // 计算模型设置ToolStripMenuItem
            // 
            this.计算模型设置ToolStripMenuItem.Name = "计算模型设置ToolStripMenuItem";
            this.计算模型设置ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.计算模型设置ToolStripMenuItem.Text = "计算模型设置";
            this.计算模型设置ToolStripMenuItem.Click += new System.EventHandler(this.计算模型设置ToolStripMenuItem_Click);
            // 
            // 服务器设置ToolStripMenuItem
            // 
            this.服务器设置ToolStripMenuItem.Name = "服务器设置ToolStripMenuItem";
            this.服务器设置ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.服务器设置ToolStripMenuItem.Text = "服务器设置";
            this.服务器设置ToolStripMenuItem.Click += new System.EventHandler(this.服务器设置ToolStripMenuItem_Click);
            // 
            // ACCPort
            // 
            this.ACCPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ACCPort_DataReceived);
            // 
            // GPSPort
            // 
            this.GPSPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.GPSPort_DataReceived);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(357, 80);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(415, 442);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IRI";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "路段长度";
            this.columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "时间";
            this.columnHeader4.Width = 110;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // chart1
            // 
            chartArea1.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.Gray;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(789, 125);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.LegendText = "加速度1";
            series1.Name = "Series1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Black;
            series2.Legend = "Legend1";
            series2.LegendText = "加速度2";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(883, 351);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1667, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(54, 20);
            this.toolStripStatusLabel2.Text = "经纬度";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoCheck = false;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(31, 22);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 19);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "自动运行";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoCheck = false;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(179, 22);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 19);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "手动运行";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1403, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "加速度计1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1403, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "加速度计2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.acc2_num_tb);
            this.groupBox1.Controls.Add(this.acc1_num_tb);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(33, 68);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(292, 247);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // acc2_num_tb
            // 
            this.acc2_num_tb.Location = new System.Drawing.Point(179, 161);
            this.acc2_num_tb.Name = "acc2_num_tb";
            this.acc2_num_tb.Size = new System.Drawing.Size(88, 25);
            this.acc2_num_tb.TabIndex = 6;
            this.acc2_num_tb.Text = "0007";
            // 
            // acc1_num_tb
            // 
            this.acc1_num_tb.Location = new System.Drawing.Point(179, 123);
            this.acc1_num_tb.Name = "acc1_num_tb";
            this.acc1_num_tb.Size = new System.Drawing.Size(88, 25);
            this.acc1_num_tb.TabIndex = 6;
            this.acc1_num_tb.Text = "0006";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 201);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9"});
            this.comboBox3.Location = new System.Drawing.Point(121, 161);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(45, 23);
            this.comboBox3.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9"});
            this.comboBox2.Location = new System.Drawing.Point(121, 126);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(45, 23);
            this.comboBox2.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "100",
            "200",
            "250",
            "500",
            "1000"});
            this.comboBox1.Location = new System.Drawing.Point(121, 89);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(124, 23);
            this.comboBox1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "加速度2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "加速度1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "测量间隔";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3});
            this.statusStrip2.Location = new System.Drawing.Point(0, 580);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip2.Size = new System.Drawing.Size(1667, 25);
            this.statusStrip2.TabIndex = 8;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel3.Text = " ";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.ForestGreen;
            this.progressBar1.Location = new System.Drawing.Point(855, 498);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(735, 22);
            this.progressBar1.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Db_check);
            this.groupBox2.Controls.Add(this.GPS_check);
            this.groupBox2.Controls.Add(this.Acc2_check);
            this.groupBox2.Controls.Add(this.Acc1_check);
            this.groupBox2.Location = new System.Drawing.Point(33, 353);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(292, 156);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态";
            // 
            // Db_check
            // 
            this.Db_check.AutoSize = true;
            this.Db_check.Location = new System.Drawing.Point(31, 119);
            this.Db_check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Db_check.Name = "Db_check";
            this.Db_check.Size = new System.Drawing.Size(74, 19);
            this.Db_check.TabIndex = 0;
            this.Db_check.Text = "数据库";
            this.Db_check.UseVisualStyleBackColor = true;
            this.Db_check.CheckedChanged += new System.EventHandler(this.Db_check_CheckedChanged);
            // 
            // GPS_check
            // 
            this.GPS_check.AutoSize = true;
            this.GPS_check.Location = new System.Drawing.Point(31, 79);
            this.GPS_check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GPS_check.Name = "GPS_check";
            this.GPS_check.Size = new System.Drawing.Size(53, 19);
            this.GPS_check.TabIndex = 0;
            this.GPS_check.Text = "GPS";
            this.GPS_check.UseVisualStyleBackColor = true;
            // 
            // Acc2_check
            // 
            this.Acc2_check.AutoSize = true;
            this.Acc2_check.Location = new System.Drawing.Point(145, 39);
            this.Acc2_check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Acc2_check.Name = "Acc2_check";
            this.Acc2_check.Size = new System.Drawing.Size(97, 19);
            this.Acc2_check.TabIndex = 0;
            this.Acc2_check.Text = "加速度计2";
            this.Acc2_check.UseVisualStyleBackColor = true;
            // 
            // Acc1_check
            // 
            this.Acc1_check.AutoSize = true;
            this.Acc1_check.Location = new System.Drawing.Point(31, 39);
            this.Acc1_check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Acc1_check.Name = "Acc1_check";
            this.Acc1_check.Size = new System.Drawing.Size(97, 19);
            this.Acc1_check.TabIndex = 0;
            this.Acc1_check.Text = "加速度计1";
            this.Acc1_check.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoCheck = false;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(31, 57);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 19);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "百分制模型";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoCheck = false;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(179, 56);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(82, 19);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.Text = "标准IRI";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            this.radioButton4.Click += new System.EventHandler(this.radioButton4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1667, 630);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "平整度检测系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结束ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 监视ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加速度计ToolStripMenuItem;
        private System.IO.Ports.SerialPort ACCPort;
        private System.IO.Ports.SerialPort GPSPort;
        private System.Windows.Forms.ToolStripMenuItem 计算模型设置ToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 存储当前结果ToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem 服务器设置ToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox Db_check;
        private System.Windows.Forms.CheckBox GPS_check;
        private System.Windows.Forms.CheckBox Acc2_check;
        private System.Windows.Forms.CheckBox Acc1_check;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox acc2_num_tb;
        private System.Windows.Forms.TextBox acc1_num_tb;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}

