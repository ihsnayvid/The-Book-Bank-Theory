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
    public partial class issue : Form
    {
        OleDbConnection db;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        string str, sql;

        public issue()
        {
            InitializeComponent();
        }

        private void issue_Load(object sender, EventArgs e)
        {
           
            con("select bid from books", "books");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["bid"].ToString());
            }
            db.Close();
            cmd.Dispose();

            con("select id from stu", "stu");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox5.Items.Add(dr["id"].ToString());
            }
            db.Close();
            cmd.Dispose();

            

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(2);

        }

        public void con(string sql, string tbl)
        {
            
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            db = new OleDbConnection(str);
            db.Open();
            cmd = new OleDbCommand(sql, db);
            da = new OleDbDataAdapter(cmd);
            

        }
        public int execute(string sql)
        {
            OleDbConnection db = new OleDbConnection(str);
            cmd = new OleDbCommand(sql, db);
            db.Open();
            int r = cmd.ExecuteNonQuery();
            return r;

        }
        public OleDbDataReader read(string sql)
        {
            OleDbConnection db = new OleDbConnection(str);
            cmd = new OleDbCommand(sql, db);
            db.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        private void issue_btn_Click(object sender, EventArgs e)
        {
            int bid, sid;
            string bname, sname, issuedate, duedate, dept, sem;
            sid = Convert.ToInt32(comboBox5.SelectedItem);
            sname = comboBox6.SelectedItem.ToString();
            bid = Convert.ToInt32(comboBox2.SelectedItem);
            bname = comboBox1.SelectedItem.ToString();
            issuedate = dateTimePicker1.Value.ToShortDateString();
            duedate = dateTimePicker2.Value.ToShortDateString();
            dept = comboBox3.SelectedItem.ToString();
            sem = comboBox4.SelectedItem.ToString();
            sql="select count(*) from issue where id="+sid;
            cmd = new OleDbCommand(sql, db);
            db.Open();
            int nob = (int)cmd.ExecuteScalar();

            if (nob == 3)
            {
                MessageBox.Show("Can not issue more than 3 books");
                db.Close();
                cmd.Dispose();
            }
            else
            {
                db.Close();
                cmd.Dispose();
                sql = "insert into issue values(" + sid + "," + bid + ",'" + sname + "','" + bname +"','"+dept+"','"+sem+ "','" + issuedate + "','" + duedate + "')";
                cmd = new OleDbCommand(sql, db);
                db.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    MessageBox.Show("Issued");
                }
                else
                {
                    MessageBox.Show("Error");
                }

                cmd.Dispose();
                sql = "update books set qty=qty-1,issued=issued+1 where bid=" + bid;
                cmd = new OleDbCommand(sql, db);
                int p = cmd.ExecuteNonQuery();
                db.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con("select bname from books where bid=" + Convert.ToInt32(comboBox2.SelectedItem), "books");
            dr = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["bname"].ToString());
            }
            db.Close();
            cmd.Dispose();

        }

       
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            con("select sname,dept,sem from stu where id=" + Convert.ToInt32(comboBox5.SelectedItem), "stu");
            dr = cmd.ExecuteReader();
            comboBox6.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            while (dr.Read())
            {
                comboBox6.Items.Add(dr["sname"].ToString());
                comboBox3.Items.Add(dr["dept"].ToString());
                comboBox4.Items.Add(dr["sem"].ToString());
            }
            db.Close();
            cmd.Dispose();
        }       
    }
}