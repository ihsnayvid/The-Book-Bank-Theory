using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace LMS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"D:\Divyanshi\C#\LMS\LMS\login.png";
        }
        private void textBox1_MouseClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "divya" && textBox2.Text == "pwd1234")
            {
                //timer1.Enabled = true;
                //timer1.Start();
                //timer1.Tick += new EventHandler(timer1_Tick);
                Home home = new Home();
                home.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    progressBar1.Value++;
        //    if (progressBar1.Value == progressBar1.Maximum)
        //    {
        //        timer1.Stop();
        //        Home home = new Home();
        //        home.Show();
        //    }
        //}

        
        

    }
}
