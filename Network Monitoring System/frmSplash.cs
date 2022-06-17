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
    public partial class frmSplash : Form
    {
        int a = 0;
        public frmSplash()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(a == 0)
            {
                pBar.Value = pBar.Value + 5;
                if(pBar.Value >= 100)
                {
                    a = 1;
                }
            }
            else
            {
                lblC.Visible = !lblC.Visible;
            }
           

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Hide();
            frmLogin fm = new frmLogin();
            fm.ShowDialog();
            this.Dispose();
            //this.Close();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {

        }
    }
}
