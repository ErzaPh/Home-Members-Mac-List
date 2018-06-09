using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace House_List_of_MAC_Address_and_Owners
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        bool mousedown;
        int mousx = 0;
        int mousy = 0;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                mousx = MousePosition.X - 560;
                mousy = MousePosition.Y - 10;
                this.SetDesktopLocation(mousx, mousy);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult Diagresult = MessageBox.Show("Are you sure you want to Logout", "Notification", MessageBoxButtons.YesNo);
            if (Diagresult == DialogResult.Yes)
            {
                frmLogin frmlogin = new frmLogin();
                this.Close();
                frmlogin.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
