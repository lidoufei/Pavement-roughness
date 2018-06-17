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
    public partial class MysqlSetForm : Form
    {
        public MysqlSetForm()
        {
            InitializeComponent();
        }
        bool allowValueChange = false;

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (allowValueChange)
            {
                Form1.MySQL_IP = this.dataGridView1.Rows[0].Cells[2].Value.ToString();
                Form1.MySQL_Port = this.dataGridView1.Rows[1].Cells[2].Value.ToString();
                Form1.MySQL_Account = this.dataGridView1.Rows[2].Cells[2].Value.ToString();
                Form1.MySQL_Passwords = this.dataGridView1.Rows[3].Cells[2].Value.ToString();
                Form1.MySQL_Database = this.dataGridView1.Rows[4].Cells[2].Value.ToString();
            }
            
        }

        private void MysqlSetForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
            dataGridView1.Rows[0].Cells[1].Value = "数据库IP";
            dataGridView1.Rows[0].Cells[2].Value = Form1.MySQL_IP;
            dataGridView1.Rows[1].Cells[1].Value = "端口号";
            dataGridView1.Rows[1].Cells[2].Value = Form1.MySQL_Port;
            dataGridView1.Rows[2].Cells[1].Value = "账户名";
            dataGridView1.Rows[2].Cells[2].Value = Form1.MySQL_Account;
            dataGridView1.Rows[3].Cells[1].Value = "密码";
            dataGridView1.Rows[3].Cells[2].Value = Form1.MySQL_Passwords;
            dataGridView1.Rows[4].Cells[1].Value = "数据库名";
            dataGridView1.Rows[4].Cells[2].Value = Form1.MySQL_Database;
            allowValueChange = true;
            
        }
    }
}
