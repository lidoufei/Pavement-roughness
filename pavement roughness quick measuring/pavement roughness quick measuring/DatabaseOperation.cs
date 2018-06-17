using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pavement_roughness_quick_measuring
{
    public partial class Form1 : Form
    {
        private void MySQLIni()
        {
            string sqlStr = "server=" + MySQL_IP + ";port=" + MySQL_Port.ToString() + ";user id=" + MySQL_Account + ";password=" + MySQL_Passwords + ";database=" + MySQL_Database + ";Allow Zero Datetime=True;Charset=utf8";
            try
            {
                if (DatabaseLinked == false)
                {
                    mycon = new MySqlConnection(sqlStr);
                    mycon.Open();
                    DatabaseLinked = true;
                    toolStripStatusLabel3.Text = "数据库已连接";
                    Db_check.Checked = true;
                    Db_check.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MysqlSetForm nf = new MysqlSetForm();
                nf.Show();
            }


        }

        private void getmysqlcom(string sqlstr)
        {
            if (!DatabaseLinked)
                return;
            MySqlCommand mysqlcom = new MySqlCommand();
            mysqlcom.CommandText = sqlstr;
            try
            {
                mysqlcom.Connection = mycon;
                mysqlcom.ExecuteNonQuery();
                mysqlcom.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertGPS(GPSdata gd)
        {
            string CREATE_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string upload_time = CREATE_TIME;
            //string upload_time = new DateTime().ToString();
            string original_url = null;
            //original_url += "001";
            //original_url += DateTime.Now.ToString("yyyymmddhhmmssfff");
            string result = null;
            string sqlStr = "insert into GPS values('";
            sqlStr += gd.utcTime.ToString("yyyyMMddHHmmssfff") + "','" + gd.utcTime.ToString("yyyy-MM-dd HH:mm:ss") + "'," + gd.GPSStatus.ToString() + "," + gd.latitude.ToString() + "," + gd.longitude.ToString() + ",";
            sqlStr += "25" + "," + gd.Azimuth.ToString() + "," + gd.Declinaion.ToString() + ",'" + CREATE_TIME + "','" + upload_time + "','" + original_url + "','" + result + "');";
            getmysqlcom(sqlStr);
        }



    }
}
