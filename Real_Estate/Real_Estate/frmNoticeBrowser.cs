using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Real_Estate
{
    public partial class frmNoticeBrowser : Form
    {
        int Accesslvl;
        int Userid;

        public frmNoticeBrowser(int accesslvl, int userid)
        {
            InitializeComponent();
            Accesslvl = accesslvl;
            Userid = userid;
        }


        private void frmNoticeBrowser_Load(object sender, EventArgs e)
        {
            FixFormName();

        }

        private void FixFormName()
        {
            if (Accesslvl == 0) { this.Text = "Signed in as Guest"; }
            if (Accesslvl == 1)
            {
                Program.Cmd.Parameters.Clear();
                Program.Cmd.CommandText = "SELECT User_First_Name From Users WHERE User_Id =" + Userid;

                Program.Con.Open();
                String name = Convert.ToString(Program.Cmd.ExecuteScalar());
                Program.Con.Close();
                this.Text = "Welcome " + name + "!";
            }
        }

        private void frmNoticeBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
             
        }
    }


}
