using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDiemSVKhoaCNNT
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtUsername.Text = "mainad1";
            txtPassword.Text = "1234";
        }

        public string getUserName()
        {
            return txtUsername.Text;
        }

        public string getPassword()
        {
            return txtPassword.Text;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
