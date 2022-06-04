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
    public partial class stock : Form
    {
        OleDbConnection db;
        OleDbCommand cmd;
        OleDbCommandBuilder cbuild;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet ds;
        DataTable dt;
        string str, sql;

        public stock()
        {
            InitializeComponent();
        }
        public void con(string sql, string tbl)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            OleDbConnection db = new OleDbConnection(str);
            db.Open();
            cmd = new OleDbCommand(sql, db);
            da = new OleDbDataAdapter(cmd);
            cbuild = new OleDbCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, tbl);
            dt = ds.Tables[tbl];
            db.Close();
            dataGridView1.DataSource = ds.Tables[tbl];            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public void conx(string sql, string tbl)
        {
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            db = new OleDbConnection(str);
            db.Open();
            cmd = new OleDbCommand(sql, db);
            da = new OleDbDataAdapter(cmd);
        }
        private void stock_Load(object sender, EventArgs e)
        {           
             con("select * from books", "books");
        }
        private void viewsupplier_btn_Click(object sender, EventArgs e)
        {
            con("select * from supplier", "supplier");
        }
        private void updateqty_btn_Click(object sender, EventArgs e)
        {
            addqty_btn.Enabled = true;
            subqty_btn.Enabled = true;
            textBox1.Enabled = true;           
        }
        private void addqty_btn_Click(object sender, EventArgs e)
        {
            cmd.Dispose();
            int bid=Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            sql = "update books set qty=qty+"+Convert.ToInt32(textBox1.Text)+" where bid=" + bid;
            conx(sql, "books");
            int p = cmd.ExecuteNonQuery();
            db.Close();
            dataGridView1.Refresh();
            con("select * from books", "books");
        }
        private void subqty_btn_Click(object sender, EventArgs e)
        {
            cmd.Dispose();
            int bid = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            sql = "update books set qty=qty-" + Convert.ToInt32(textBox1.Text) + " where bid=" + bid;
            conx(sql,"books");
            int p = cmd.ExecuteNonQuery();
            db.Close();
            dataGridView1.Refresh();
            con("select * from books", "books");
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
