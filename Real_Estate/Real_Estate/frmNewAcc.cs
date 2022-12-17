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
    public partial class frmNewAcc : Form
    {
        public frmNewAcc()
        {
            InitializeComponent();
            int a;
        }
        private Boolean Validation()
        {
            string message = "This";
            int validEmail = 0;
            int validPhone = 0;
            int validNationalCode = 0;

            Program.Con.Open();
            Program.Cmd.Parameters.Clear();
            Program.Cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE User_Phone =" + txtPhone.Text;
            validPhone = Convert.ToInt32(Program.Cmd.ExecuteScalar());
            Program.Cmd.CommandText = "SELECT COUNT(*)  FROM Users WHERE USER_Email ='" + txtEmail.Text + "'";
            validEmail = Convert.ToInt32(Program.Cmd.ExecuteScalar());
            Program.Cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE User_National_Code =" + txtNationalCode.Text;
            validNationalCode = Convert.ToInt32(Program.Cmd.ExecuteScalar());
            Program.Con.Close();

            if (validPhone > 0) { message = message + " Phone Number"; }
            if (validEmail > 0)
            {
                if (message.Length > 4) { message = message + " And Email"; }
                else                    { message = message + " Email"; }
            }
            if (validNationalCode > 0)
            {
                if (message.Length > 4) { message = message + " And National Code"; }
                else                    { message = message + " National Code"; }
            }

            if (message.Length > 4)
            {
                MessageBox.Show(message); //Icon Error be in ezafe kon  ("_")
                return true;
            } 
            else { return false; }

        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {   
            //Baraye Hame Text Box Ha Validation Lazem Ro Benevis  ("_")
            //Baraye Hamkhani Password Validation Benevis (hamrah ba msgbox)  ("_")
            if (Validation()) { return; }
            int success = 0;
            Program.Cmd.Parameters.Clear();
            Program.Cmd.CommandText = "INSERT INTO Users(User_First_Name ,User_Last_Name ,User_Phone ,User_Email ,User_National_Code ,User_Passwrod) Values (?,?,?,?,?,?)";
            Program.Cmd.Parameters.AddWithValue("User_First_Name"       ,txtFirstName.Text);
            Program.Cmd.Parameters.AddWithValue("User_Last_Name"        ,txtLastName.Text);
            Program.Cmd.Parameters.AddWithValue("User_Phone"            ,txtPhone.Text);
            Program.Cmd.Parameters.AddWithValue("User_Email"            ,txtEmail.Text);
            Program.Cmd.Parameters.AddWithValue("User_National_Code"    ,txtNationalCode.Text);
            Program.Cmd.Parameters.AddWithValue("User_Password"         ,txtPass.Text);

            Program.Con.Open();
            success = Program.Cmd.ExecuteNonQuery();
            Program.Con.Close();

            if (success == 0)
            {
                MessageBox.Show("Operation Failed");  //Icon Ezafe Kon ("_")
            }
            else
            {
                MessageBox.Show("Operation Successful");  //Icon Ezafe kon ("_")
                this.Close();
            }
        }
    }
}
