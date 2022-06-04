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
    public partial class student : Form
    {
        OleDbConnection db;
        OleDbCommand cmd;
        OleDbCommandBuilder cbuild;
        OleDbDataAdapter da;
        OleDbDataReader dr;
        DataSet ds;
        DataTable dt;
        string str, sql;

        public student()
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
        private void student_Load(object sender, EventArgs e)
        {
            con("select * from stu", "stu");
          
        }

        
        private void refresh_btn_Click(object sender, EventArgs e)
        {
            con("select * from stu", "stu");            
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            string path = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            pictureBox1.ImageLocation = path;
        }       

        private void update_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            da.Update(dt);
            sql = "update stu set sname='" + textBox3.Text + "',dept='" + textBox4.Text + "',sem='" + textBox5.Text + "',img='" + pictureBox1.ImageLocation + "' where id=" + Convert.ToInt32(textBox2.Text);
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
            sql = "delete from stu where id=" + Convert.ToInt32(textBox2.Text);
            int p = execute(sql);
            if (p > 0)
            {
                MessageBox.Show("Deleted");
            }
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                sql = "select * from stu where sname='" + textBox1.Text+"'";
                con(sql, "stu");                
            }

            if (radioButton2.Checked == true)
            {
                con("select * from stu where id=" + Convert.ToInt32(textBox1.Text), "stu");                
            }           
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(dataGridView1.SelectedCells[0].Value);
            textBox3.Text = Convert.ToString(dataGridView1.SelectedCells[1].Value);
            textBox4.Text = Convert.ToString(dataGridView1.SelectedCells[2].Value);
            textBox5.Text = Convert.ToString(dataGridView1.SelectedCells[3].Value);
            pictureBox1.ImageLocation = Convert.ToString(dataGridView1.SelectedCells[4].Value);
        }

        private void viewimg_btn_Click(object sender, EventArgs e)
        {
            int i = 0;
            Bitmap img;
            DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
            imgcol.HeaderText = "Student Img";
            imgcol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            imgcol.Width = 100;
            dataGridView1.Columns.Add(imgcol);

            foreach (DataRow drow in dt.Rows)
            {
                img = new Bitmap(drow["img"].ToString());
                dataGridView1.Rows[i].Cells[5].Value = img;
                dataGridView1.Rows[i].Height = 100;
                i++;
            }            
        }
    }
}
