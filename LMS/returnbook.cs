using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LMS
{
    public partial class returnbook : Form
    {
        OleDbConnection db;
        OleDbDataReader dr;
        OleDbCommand cmd;
        string sql, str;

        public returnbook()
        {
            InitializeComponent();
        }
        public void con(string sql, string tbl)
        {
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            db = new OleDbConnection(str);
            db.Open();
            cmd = new OleDbCommand(sql, db);           
        }

        private void returnbook_Load(object sender, EventArgs e)
        {
            con("select sname from stu", "stu");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["sname"].ToString());
            }
            db.Close();
            cmd.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Remove(comboBox2.SelectedItem);
            comboBox2.Items.Clear();
            con("select bname from issue where sname='"+comboBox1.SelectedItem.ToString()+"'", "issue");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["bname"].ToString());
            }
            db.Close();
            cmd.Dispose();
        }

        private void return_btn_Click(object sender, EventArgs e)
        {
            string sname=comboBox1.SelectedItem.ToString();
            string bname=comboBox2.SelectedItem.ToString();
            
            con("select duedate from issue where sname='" + sname + "'", "issue");
            int fine;
            DateTime nod_due, nod_now;
            dr = cmd.ExecuteReader();
            DateTime duedate=DateTime.Today;
            while (dr.Read())
            {
                duedate = Convert.ToDateTime(dr["duedate"]);
            }
            nod_due = duedate.Date;
            nod_now = DateTime.Today.Date;
            TimeSpan diff = nod_now - nod_due;
            int nod = diff.Days;
            
            if (duedate < DateTime.Today)
            {
               fine = nod * 10;
                MessageBox.Show("fine applied Rs. "+fine);
            }
            cmd.Dispose();
            db.Close();
            con("delete from issue where sname='"+sname+"' and bname='"+bname+"'", "issue");
           
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                MessageBox.Show("Returned");
            }
            else
            {
                MessageBox.Show("Error");
            }
            cmd.Dispose();
            sql = "update books set qty=qty+1,issued=issued-1 where bname='" + bname+"'";
            cmd = new OleDbCommand(sql, db);
            int p = cmd.ExecuteNonQuery();
            db.Close();           
        }
    }
}
