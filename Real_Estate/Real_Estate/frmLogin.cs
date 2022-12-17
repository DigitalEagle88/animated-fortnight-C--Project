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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            frmNewAcc frmNA = new frmNewAcc();
            frmNA.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Validation() == false) { return; }
            int userid = 0;           
            int useraccesslevel = 0;
            DataTable Dt = new DataTable();

            Program.Cmd.Parameters.Clear();          
            Program.Con.Open();
            Program.Da.SelectCommand.CommandText = "SELECT User_Id,User_Access_Level_Id FROM Users WHERE User_Phone =" + txtPhoneNumber.Text + " AND User_Password ='" + txtPassword.Text + "'";
            Program.Da.Fill(Dt);
            Program.Con.Close();

            userid          = Convert.ToInt32(Dt.Rows[0]["User_id"]);
            useraccesslevel = Convert.ToInt32(Dt.Rows[0]["User_Access_Level_Id"]);

            //Program.Cmd.CommandText = "SELECT User_Access_Level_Id FROM Users WHERE User_Phone =" + txtPhoneNumber.Text + " AND User_Password ='" + txtPassword.Text + "'";
            //useraccesslevel = Convert.ToInt32(Program.Cmd.ExecuteScalar());
            //Program.Cmd.CommandText = "SELECT User_Id FROM Users WHERE User_Phone =" + txtPhoneNumber.Text + " AND User_Password ='" + txtPassword.Text + "'";
            //userid = Convert.ToInt32(Program.Cmd.ExecuteScalar());

            frmNoticeBrowser frmNB = new frmNoticeBrowser(useraccesslevel, userid);
            frmNB.Show(); 
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            frmNoticeBrowser frmNB = new frmNoticeBrowser(0,0);
            frmNB.Show();
        }

        private Boolean Validation()
        {
            //method validation ro kamel kon ke natone phone + pass khlali ya cherto pert bezane ("_")

            int useristrue = 0;

            Program.Cmd.Parameters.Clear();
            Program.Cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE User_Phone =" + txtPhoneNumber.Text + " AND User_Password =" + txtPassword.Text;

            Program.Con.Open();            
            useristrue = Convert.ToInt32(Program.Cmd.ExecuteScalar());
            Program.Con.Close();
            
            if (useristrue == 1) { return true; }
            else
            {
                MessageBox.Show("Invalid Credentials");  //Inja Ham Icon Bezar ("_")
                return false;
            }
            

        }
    }
}
