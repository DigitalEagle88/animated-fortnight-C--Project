using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Real_Estate
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static string ConStr = "Provider=SQLOLEDB;Data Source=.;Initial Catalog=Real_Estate;Integrated Security=SSPI";
        static public System.Data.OleDb.OleDbConnection Con = new System.Data.OleDb.OleDbConnection(ConStr);
        static public System.Data.OleDb.OleDbCommand Cmd = new OleDbCommand("", Con);
        static public System.Data.OleDb.OleDbDataAdapter Da = new OleDbDataAdapter("", Con);
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
