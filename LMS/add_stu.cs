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
    public partial class add_stu : Form
    {
        OleDbConnection db;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        string str, sql,path;

        public add_stu()
        {
            InitializeComponent();
        }

        public int execute(string sql)
        {
            cmd = new OleDbCommand(sql, db);
            db.Open();
            int r = cmd.ExecuteNonQuery();
            return r;

        }
        private void add_stu_Load(object sender, EventArgs e)
        {
            str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Divyanshi\C#\LMS.accdb";
            db = new OleDbConnection(str);
            
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
             path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            pictureBox1.ImageLocation = path;
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "Insert into stu values(" + Convert.ToInt32(textBox1.Text) + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + path.ToString() + "')";
                int p = execute(sql);
                if (p > 0)
                {
                    MessageBox.Show("Student added");
                }
                db.Close();
            }
            catch
            {
                MessageBox.Show("Ambiguos Details");
            }
                
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsLetter(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsLetter(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

      
    }
}
