﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace House_List_of_MAC_Address_and_Owners
{
    public partial class frmLogin : Form
    {
        
        OleDbConnection oledbcon = new OleDbConnection();
        public frmLogin()
        {
            InitializeComponent();
            
            oledbcon.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\OwnerandMacAddress.accdb;";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult Diagresult = MessageBox.Show("Are you sure you want to exit","Notification",MessageBoxButtons.YesNo);
            if(Diagresult == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {

            }
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                
                oledbcon.Open();
                MessageBox.Show("Connection Open", "Notification", MessageBoxButtons.OK);
                oledbcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OleDbDataReader oledbdr;
            OleDbCommand oledbcmd;
            try
            {
               
                oledbcon.Open();
                 oledbcmd = new OleDbCommand();
                oledbcmd.Parameters.AddWithValue("@usernam", txtbxusername.Text);
                oledbcmd.Parameters.AddWithValue("@userpas", txtbxuserpass.Text);
                oledbcmd.Connection = oledbcon;
                oledbcmd.CommandText = "SElECT * FROM users where username=@usernam and userpass=@userpas and usertype='Admin' ";
                
                oledbdr = oledbcmd.ExecuteReader();
                if (oledbdr.HasRows == true)
                {
                    MessageBox.Show("Access Granted Admin", "Notification", MessageBoxButtons.OK);
                    oledbcon.Close();
                }
                else if (oledbdr.HasRows == false)
                {
                    oledbcon.Close();
                    oledbcon.Open();
                    oledbcmd = new OleDbCommand();
                    oledbcmd.Parameters.AddWithValue("@usernam", txtbxusername.Text);
                    oledbcmd.Parameters.AddWithValue("@userpas", txtbxuserpass.Text);
                    oledbcmd.Connection = oledbcon;
                    oledbcmd.CommandText = "SElECT * FROM users where username=@usernam and userpass=@userpas and usertype='User' ";

                    oledbdr = oledbcmd.ExecuteReader();
                    if (oledbdr.HasRows == true)
                    {
                        MessageBox.Show("Access Granted User", "Notification", MessageBoxButtons.OK);
                        oledbcon.Close();
                    }
                    else
                    {
                        MessageBox.Show("Access Denied", "Notification", MessageBoxButtons.OK);
                        oledbcon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Notification", MessageBoxButtons.OK);
                oledbcon.Close();

            }
            clrtxtbx();
        }
        public void clrtxtbx()
        {
            txtbxusername.Clear();
            txtbxuserpass.Clear();
        }
    }
}
