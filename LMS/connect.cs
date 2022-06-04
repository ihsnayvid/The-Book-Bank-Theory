using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace LMS
{   
    class connect
    {
       OleDbConnection db;
        OleDbCommand cmd;
        //OleDbCommandBuilder cbuild;
       // OleDbDataAdapter da;
        OleDbDataReader dr;
       // DataSet ds;
        DataTable dt;
        string str, sql;
        
        //public void con(string sql, string tbl)
        //{
        //    str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ADMIN\Desktop\LMS.accdb";
        //    OleDbConnection db = new OleDbConnection(str);
        //    db.Open();
        //    cmd = new OleDbCommand(sql, db);
        //    da = new OleDbDataAdapter(cmd);
        //    cbuild = new OleDbCommandBuilder(da);
        //    ds = new DataSet();
        //    da.Fill(ds, tbl);
        //    dt = ds.Tables[tbl];
        //    db.Close();
            
        //}

        public void updategrid(string dtg)
        {

        }
        public void deletegrid(string dtg)
        {

        }
        public int execute(string sql)
        {
            cmd = new OleDbCommand(sql, db);
            db.Open();
            int r = cmd.ExecuteNonQuery();
            return r;
        
        }
        public OleDbDataReader read(string sql)
        {
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
    }
}
