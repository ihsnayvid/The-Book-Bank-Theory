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
    public partial class info : Form
    {
        OleDbConnection db;
        OleDbCommand cmd;
        OleDbCommandBuilder cbuild;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet ds;
        DataTable dt;
        string str, sql;

        public info()
        {
            InitializeComponent();
        }

        public void con(string sql, string tbl)
        {
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            db = new OleDbConnection(str);
            db.Open();
            cmd = new OleDbCommand(sql, db);
            da = new OleDbDataAdapter(cmd);
        }
        private void info_Load(object sender, EventArgs e)
        {
            con("select bname from books", "books");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["bname"].ToString());
            }
            db.Close();
            cmd.Dispose();

            con("select sname from stu", "stu");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["sname"].ToString());
            }
            db.Close();
            cmd.Dispose();

            comboBox3.Items.Add("BCA");
            comboBox3.Items.Add("Bsc");
            comboBox3.Items.Add("BCom");
            comboBox3.Items.Add("BA");
            comboBox3.Items.Add("BBA");
            comboBox3.Items.Add("MA");
            comboBox4.Items.Add("1");
            comboBox4.Items.Add("2");
            comboBox4.Items.Add("3");
            comboBox4.Items.Add("4");
            comboBox4.Items.Add("5");
            comboBox4.Items.Add("6");
            
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox2.Enabled = false;
                comboBox1.Enabled = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
            }          
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {           
            string bname = comboBox1.SelectedItem.ToString();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            OleDbConnection db = new OleDbConnection(str);
            db.Open();
            sql = "select ID,sname,issuedate,duedate from issue where bname='" + bname + "'";
            cmd = new OleDbCommand(sql, db);
            da = new OleDbDataAdapter(cmd);
            cbuild = new OleDbCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "issue");
            dt = ds.Tables["issue"];
            db.Close();
            dataGridView1.DataSource = ds.Tables["issue"];
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string sname = comboBox2.SelectedItem.ToString();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            OleDbConnection db = new OleDbConnection(str);
            db.Open();
            sql = "select bid,bname,issuedate,duedate from issue where sname='" + sname + "'";
            cmd = new OleDbCommand(sql, db);
            da = new OleDbDataAdapter(cmd);
            cbuild = new OleDbCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "issue");
            dt = ds.Tables["issue"];
            db.Close();
            dataGridView1.DataSource = ds.Tables["issue"];
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string dept = comboBox3.SelectedItem.ToString();
            string sem = comboBox4.SelectedItem.ToString();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            OleDbConnection db = new OleDbConnection(str);
            db.Open();
            sql = "select ID,sname,bname,issuedate,duedate from issue where dept='" + dept + "'and sem='"+sem+"'";
            cmd = new OleDbCommand(sql, db);
            da = new OleDbDataAdapter(cmd);
            cbuild = new OleDbCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "issue");
            dt = ds.Tables["issue"];
            db.Close();
            dataGridView1.DataSource = ds.Tables["issue"];
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
