using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Monitoring_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                MessageBox.Show("Username field cannot be empty, please enter your username", "Field Empty");
                txtusername.Focus();
            }else if (txtpassword.Text == "")
            {
                MessageBox.Show("Password field cannot be empty, please enter your password","Field Empty");
                txtpassword.Focus();
            }
            else
            {
                if (txtpassword.Text == "admin" && txtusername.Text == "admin")
                {
                    this.Hide();
                    frmMonitoring nn = new frmMonitoring();
                    nn.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invlaid username or password", "Error");
                }
            }
        }
    }
}
