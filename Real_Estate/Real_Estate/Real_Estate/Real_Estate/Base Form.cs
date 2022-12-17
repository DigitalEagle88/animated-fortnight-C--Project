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
    public partial class Base_Form : Form
    {
        public Base_Form()
        {
            InitializeComponent();
        }

        private void Base_Form_Load(object sender, EventArgs e)
        {
            frmLogin frmlgn= new frmLogin();
            frmlgn.MdiParent = this;
            frmlgn.Show();
        }
    }
}
