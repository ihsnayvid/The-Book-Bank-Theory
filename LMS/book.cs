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
    public partial class book : Form
    {
        OleDbConnection db;
        OleDbCommand cmd;
        OleDbCommandBuilder cbuild;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet ds;
        DataTable dt;
        string str, sql;

        public book()
        {
            InitializeComponent();
        }
        private void book_Load(object sender, EventArgs e)
        {
            con("select * from books", "books");
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
       

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            con("select * from books", "books");
        }
        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            da.Update(dt);
            sql = "update books set bname='" + textBox2.Text + "',category='"+textBox8.Text+"',author='" + textBox3.Text + "',price=" + Convert.ToInt32(textBox4.Text) + ",qty='" + Convert.ToInt32(textBox5.Text) + " where bid=" + Convert.ToInt32(textBox7.Text);
            int p = execute(sql);
            if (p > 0)
            {
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("error");
            }

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                da.Update(dt);
            }
            sql = "delete from books where id=" + Convert.ToInt32(textBox7.Text);
            int p = execute(sql);
            if (p > 0)
            {
                MessageBox.Show("Deleted");
            }
        }
      
       
         private void dataGridView1_Click_1(object sender, EventArgs e)
         {
             textBox7.Text = Convert.ToString(dataGridView1.SelectedCells[0].Value);
             textBox2.Text = Convert.ToString(dataGridView1.SelectedCells[1].Value);
             textBox8.Text = Convert.ToString(dataGridView1.SelectedCells[2].Value);
             textBox3.Text = Convert.ToString(dataGridView1.SelectedCells[3].Value);
             textBox4.Text = Convert.ToString(dataGridView1.SelectedCells[4].Value);
             textBox5.Text = Convert.ToString(dataGridView1.SelectedCells[5].Value);
             textBox6.Text = Convert.ToString(dataGridView1.SelectedCells[6].Value);
         }

         private void search_btn_Click(object sender, EventArgs e)
         {
             try
             {
                 if (radioButton1.Checked == true)
                 {
                     con("select * from books where bname='" + comboBox1.SelectedItem.ToString() + "'", "books");
                 }

                 if (radioButton2.Checked == true)
                 {                    
                     con("select * from books where bid=" + Convert.ToInt32(comboBox1.SelectedItem), "books");
                 }
                 if (radioButton3.Checked == true)
                 {
                     con("select * from books where category='" + comboBox1.SelectedItem.ToString() + "'", "books");
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
             }
        }

         private void radioButton1_CheckedChanged(object sender, EventArgs e)
         {
             comboBox1.SelectedItem = "";
             if (radioButton1.Checked == true)
             {
                 conx("select bname from books", "books");
                 dr = cmd.ExecuteReader();
                
                 comboBox1.Items.Clear();
                 while (dr.Read())
                 {
                     comboBox1.Items.Add(dr["bname"].ToString());
                 }
                 db.Close();
                 cmd.Dispose();         
             }
         }

         private void radioButton2_CheckedChanged(object sender, EventArgs e)
         {
             comboBox1.SelectedItem = "";
             if (radioButton2.Checked == true)
             {
                 conx("select bid from books", "books");
                 dr = cmd.ExecuteReader();
                 comboBox1.Items.Clear();
                 while (dr.Read())
                 {
                     comboBox1.Items.Add(dr["bid"].ToString());
                 }
                 db.Close();
                 cmd.Dispose();               
             }
         }

         private void radioButton3_CheckedChanged(object sender, EventArgs e)
         {
             comboBox1.SelectedItem = "";
             if (radioButton3.Checked == true)
             {
                 conx("select distinct(category) from books", "books");
                 dr = cmd.ExecuteReader();
                 comboBox1.Items.Clear();
                 while (dr.Read())
                 {
                     comboBox1.Items.Add(dr["category"].ToString());
                 }
                 db.Close();
                 cmd.Dispose();              
             }
         }
    }
}
