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
    public partial class addbook : Form
    {
        OleDbConnection db;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        string str, sql;

        public addbook()
        {
            InitializeComponent();
        }

        private void addbook_Load(object sender, EventArgs e)
        {
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            db = new OleDbConnection(str);
            
        }

        public int execute(string sql)
        {
            cmd = new OleDbCommand(sql, db);
            db.Open();
            int r = cmd.ExecuteNonQuery();
            return r;

        }
       

        private void add_btn_Click(object sender, EventArgs e)
        {
            int nos = 0;
            sql = "Insert into books values(" + Convert.ToInt32(textBox5.Text) + ",'" + textBox1.Text + "','" + textBox6.Text + "','" + textBox2.Text + "'," + Convert.ToInt32(textBox3.Text) + "," + Convert.ToInt32(textBox4.Text) + "," + nos + ")";
            int p = execute(sql);
            if (p > 0)
            {
                MessageBox.Show("Book added");
            }
            db.Close();
        }
    }
}
