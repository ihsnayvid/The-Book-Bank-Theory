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
    public partial class Home : Form
    {       
        public Home()
        {
            InitializeComponent();
        }
            
        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            student stu= new student();
            stu.Show();            
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_stu addstu = new add_stu();
            addstu.Show();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addbook book = new addbook();
            book.Show();
        }
             
        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            book b = new book();
            b.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            issue i = new issue();
            i.Show();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info i = new info();
            i.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            returnbook r = new returnbook();
            r.Show();
        }

        private void stockBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stock s = new stock();
            s.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }      
    }
}
