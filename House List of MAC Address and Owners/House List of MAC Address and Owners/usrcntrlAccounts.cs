using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace House_List_of_MAC_Address_and_Owners
{
    public partial class usrcntrlAccounts : UserControl
    {
        OleDbDataReader oledbdr;
        OleDbCommand oledbcmd;
        OleDbConnection oledbcon = new OleDbConnection();
        OleDbDataAdapter oledbDA = new OleDbDataAdapter();
        DataSet datSet = new DataSet();
        DataTable datTab = new DataTable();
        public usrcntrlAccounts()
        {
            InitializeComponent();
            oledbcon = new OleDbConnection(ConString.connect);
        }

        private void usrcntrlAccounts_Load(object sender, EventArgs e)
        {
            loadDGV();
        }
        private void loadDGV()
        {
            datSet.Tables.Add(datTab);
            oledbcon.Open();
            oledbDA = new OleDbDataAdapter("SELECT * FROM users order by userid", oledbcon);
            oledbDA.Fill(datTab);
            dgvAccounts.DataSource = datTab.DefaultView;
            oledbcon.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            oledbcmd = new OleDbCommand("Insert into users (username,userpass,usertype) VALUES (@usernam,@userpas,@usertyp)",oledbcon);
            oledbcmd.Parameters.AddWithValue("@usernam", txtbxusername.Text);
            oledbcmd.Parameters.AddWithValue("@userpas", txtbxuserpass.Text);
            oledbcmd.Parameters.AddWithValue("@usertyp", cmbxUsertype.Text);
            oledbcon.Open();
            oledbcmd.ExecuteNonQuery();
            oledbcon.Close();
            //loadDGV();
            MessageBox.Show("Account Added Successfully.", "Notification", MessageBoxButtons.OK);
            this.
        }

        private void clrbx()
        {
            txtbxusername.Clear();
            txtbxuserpass.Clear();
            cmbxUsertype.SelectedIndex = -1;

        }
    }
}
