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
    public partial class ModelSetting : Form
    {
        public ModelSetting()
        {
            InitializeComponent();
        }
        bool modeltype;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.a1 = double.Parse(textBox1.Text);
            Form1.a2 = double.Parse(textBox2.Text);
            Form1.c = double.Parse(textBox3.Text);
            string settings_path = Application.StartupPath + "\\settings.ini";
            StreamReader sr = new StreamReader(settings_path, Encoding.Default);
            string line;
            modeltype = model1_rb.Checked;
            string formera1="";
            string formera2="";
            string formerc="";
            string formerb1 = "";
            string formerb2 = "";
            string newa1 = "";
            string newa2 = "";
            string newc = "";
            string newb1 = "";
            string newb2 = "";
            
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Length > 0 && line[0] == '#')
                {
                    string[] str = line.Split(':');
                    int len = str[0].Length;
                    string collumn = str[0].Substring(1, len - 1);
                    if (collumn == "a1")
                    {
                        formera1= collumn + ":" + str[1];
                        if (modeltype)
                            newa1 = collumn + ":" + textBox1.Text;
                        else
                            newa1 = formera1;

                    }
                    else if (collumn == "a2")
                    {
                        formera2 = collumn + ":" + str[1];
                        if (modeltype)
                            newa2 = collumn + ":" + textBox2.Text;
                        else
                            newa2 = formera2;

                    }
                    else if (collumn == "b1")
                    {
                        formerb1 = collumn + ":" + str[1];
                        if (!modeltype)
                            newb1 = collumn + ":" + textBox1.Text;
                        else
                            newb1 = formerb1;

                    }
                    else if (collumn == "b2")
                    {
                        formerb2 = collumn + ":" + str[1];
                        if (!modeltype)
                            newb2 = collumn + ":" + textBox2.Text;
                        else
                            newb2 = formerb2;

                    }
                    else if (collumn == "c")
                    {
                        formerc = collumn + ":" + str[1];
                        
                            newc = collumn + ":" + textBox3.Text;



                    }
                }
            }
            sr.Close();
            sr = new StreamReader(settings_path);
            string strr = sr.ReadToEnd();
            strr = strr.Replace(formera1, newa1);
            strr = strr.Replace(formera2, newa2);
            strr = strr.Replace(formerb1, newb1);
            strr = strr.Replace(formerb2, newb2);
            strr = strr.Replace(formerc, newc);
            sr.Close();
            StreamWriter sw = new StreamWriter(settings_path, false);
            sw.WriteLine(strr);
            sw.Close();
        }

        private void model2_rd_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void model1_rb_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void model2_rd_Click(object sender, EventArgs e)
        {
            model1_rb.Checked = false;
            model2_rd.Checked = true;
        }

        private void model1_rb_Click(object sender, EventArgs e)
        {
            model2_rd.Checked = false;
            model1_rb.Checked = true;
        }

        private void ModelSetting_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.a1.ToString();
            textBox2.Text = Form1.a2.ToString();
        }
    }
}
