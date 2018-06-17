namespace pavement_roughness_quick_measuring
{
    partial class ModelSetting
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
            this.参数设定 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.model2_rd = new System.Windows.Forms.RadioButton();
            this.model1_rb = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.参数设定.SuspendLayout();
            this.SuspendLayout();
            // 
            // 参数设定
            // 
            this.参数设定.Controls.Add(this.button1);
            this.参数设定.Controls.Add(this.label3);
            this.参数设定.Controls.Add(this.label2);
            this.参数设定.Controls.Add(this.label1);
            this.参数设定.Controls.Add(this.model2_rd);
            this.参数设定.Controls.Add(this.model1_rb);
            this.参数设定.Controls.Add(this.textBox2);
            this.参数设定.Controls.Add(this.textBox3);
            this.参数设定.Controls.Add(this.textBox1);
            this.参数设定.Location = new System.Drawing.Point(71, 67);
            this.参数设定.Name = "参数设定";
            this.参数设定.Size = new System.Drawing.Size(652, 273);
            this.参数设定.TabIndex = 0;
            this.参数设定.TabStop = false;
            this.参数设定.Text = "参数设定";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 37);
            this.button1.TabIndex = 5;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "参数2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "参数1";
            // 
            // model2_rd
            // 
            this.model2_rd.AutoCheck = false;
            this.model2_rd.AutoSize = true;
            this.model2_rd.Location = new System.Drawing.Point(258, 52);
            this.model2_rd.Name = "model2_rd";
            this.model2_rd.Size = new System.Drawing.Size(82, 19);
            this.model2_rd.TabIndex = 3;
            this.model2_rd.Text = "标准IRI";
            this.model2_rd.UseVisualStyleBackColor = true;
            this.model2_rd.CheckedChanged += new System.EventHandler(this.model2_rd_CheckedChanged);
            this.model2_rd.Click += new System.EventHandler(this.model2_rd_Click);
            // 
            // model1_rb
            // 
            this.model1_rb.AutoCheck = false;
            this.model1_rb.AutoSize = true;
            this.model1_rb.Checked = true;
            this.model1_rb.Location = new System.Drawing.Point(69, 53);
            this.model1_rb.Name = "model1_rb";
            this.model1_rb.Size = new System.Drawing.Size(73, 19);
            this.model1_rb.TabIndex = 2;
            this.model1_rb.TabStop = true;
            this.model1_rb.Text = "百分制";
            this.model1_rb.UseVisualStyleBackColor = true;
            this.model1_rb.CheckedChanged += new System.EventHandler(this.model1_rb_CheckedChanged);
            this.model1_rb.Click += new System.EventHandler(this.model1_rb_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(105, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(306, 114);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(506, 114);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 25);
            this.textBox3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(441, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "参数3";
            // 
            // ModelSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 386);
            this.Controls.Add(this.参数设定);
            this.Name = "ModelSetting";
            this.Text = "ModelSetting";
            this.Load += new System.EventHandler(this.ModelSetting_Load);
            this.参数设定.ResumeLayout(false);
            this.参数设定.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox 参数设定;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton model2_rd;
        private System.Windows.Forms.RadioButton model1_rb;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
    }
}