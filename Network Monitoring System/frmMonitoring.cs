using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Network_Monitoring_System
{
    public partial class frmMonitoring : Form
    {
        public frmMonitoring()
        {
            InitializeComponent();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMonitoring_Load(object sender, EventArgs e)
        {
            btnChrome.PerformClick();
        }

        private void BtnChrome_Click(object sender, EventArgs e)
        {
            string google = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\User Data\Default\History";
            string query = @"SELECT url AS URL, title AS Title, visit_count as 'Visit Count', time(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime') AS Time, date(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch') as Date FROM urls ORDER BY last_visit_time DESC LIMIT 200";
            string name = "Chrome";
            string fileName = "g_" + DateTime.Now.Ticks.ToString();
            File.Copy(google, Application.StartupPath + "\\" + fileName);
            using (SQLiteConnection con = new SQLiteConnection("DataSource = " + Application.StartupPath + "\\" + fileName + ";Versio=3;New=False;Compress=True;"))
            {
                label4.Text = "Google Chrome";
                con.Open();
                //SQLiteDataAdapter da = new SQLiteDataAdapter("select url,title,visit_count,last_visit_time from urls order by last_visit_time desc", con);
                SQLiteDataAdapter sd = new SQLiteDataAdapter(query, con);
                DataSet ds = new DataSet();
                sd.Fill(ds);
                dGrid.DataSource = ds.Tables[0];
                con.Close();
            }
            try // File already open error is skipped
            {
                if (File.Exists(Application.StartupPath + "\\" + fileName))
                    File.Delete(Application.StartupPath + "\\" + fileName);
            }
            catch (Exception er)
            {
                //MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure history file exists." + er);
            }
        }

        private void BtnMozilla_Click(object sender, EventArgs e)
        {
            string mozilla = "C:\\Users\\yinka\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\y7ds4qbq.default-release\\places.sqlite";//Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Mozilla\Firefox \Profiles\ss7tmnm2.default\places.sqlite";
            string query = @"SELECT url AS URL, title AS Title, visit_count as 'Visit Count', time(last_visit_date / 1000000 + (strftime('%s', '1970-01-01')), 'unixepoch', 'localtime') AS Time, date(last_visit_date / 1000000 + (strftime('%s', '1970-01-01')), 'unixepoch') as Date FROM moz_places ORDER BY last_visit_date DESC LIMIT 200";
            string name = "Mozilla";
            string fileName = "m_" + DateTime.Now.Ticks.ToString();
            try
            {
                File.Copy(mozilla, Application.StartupPath + "\\" + fileName);
                label4.Text = "Mozilla Firefox";
                using (SQLiteConnection con = new SQLiteConnection("DataSource = " + Application.StartupPath + "\\" + fileName + ";Versio=3;New=False;Compress=True;"))
                {
                    con.Open();
                    //SQLiteDataAdapter da = new SQLiteDataAdapter("select url,title,visit_count,last_visit_time from urls order by last_visit_time desc", con);
                    SQLiteDataAdapter sd = new SQLiteDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    sd.Fill(ds);
                    dGrid.DataSource = ds.Tables[0];
                    con.Close();
                }
                try // File already open error is skipped
                {
                    if (File.Exists(Application.StartupPath + "\\" + fileName))
                        File.Delete(Application.StartupPath + "\\" + fileName);
                }
                catch (Exception er)
                {
                    //MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure history file exists." + er);
                }
            }
            catch (IOException er)
            {
                MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure you have mozilla installed on your system so that the history file exists.");
            }
        }

        private void BtnOpera_Click(object sender, EventArgs e)
        {
            string mozilla = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Opera Software\Opera Stable\History";
            string query = @"SELECT * from URLS";
            string name = "Opera Browser";
            string fileName = "o_" + DateTime.Now.Ticks.ToString();
            try
            {
                File.Copy(mozilla, Application.StartupPath + "\\" + fileName);
                label4.Text = "Opera Browser";
                using (SQLiteConnection con = new SQLiteConnection("DataSource = " + Application.StartupPath + "\\" + fileName + ";Versio=3;New=False;Compress=True;"))
                {
                    con.Open();
                    //SQLiteDataAdapter da = new SQLiteDataAdapter("select url,title,visit_count,last_visit_time from urls order by last_visit_time desc", con);
                    SQLiteDataAdapter sd = new SQLiteDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    sd.Fill(ds);
                    dGrid.DataSource = ds.Tables[0];
                    con.Close();
                }
                try // File already open error is skipped
                {
                    if (File.Exists(Application.StartupPath + "\\" + fileName))
                        File.Delete(Application.StartupPath + "\\" + fileName);
                }
                catch (Exception er)
                {
                    //MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure history file exists." + er);
                }
            }
            catch (IOException er)
            {
                MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure you have opera installed on your system so that the history file exists.");
            }
        }

        private void BtnEdge_Click(object sender, EventArgs e)
        {
            string mozilla = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Microsoft\Edge\User Data\Default\History";
            string query = @"SELECT url AS URL, title AS Title, visit_count as 'Visit Count', time(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch', 'localtime') AS Time, date(last_visit_time / 1000000 + (strftime('%s', '1601-01-01')), 'unixepoch') as Date FROM urls ORDER BY last_visit_time DESC LIMIT 200";
            string name = "Microsoft Edge";
            string fileName = "e_" + DateTime.Now.Ticks.ToString();
            try
            {
                File.Copy(mozilla, Application.StartupPath + "\\" + fileName);
                label4.Text = "Microsoft Edge";
                using (SQLiteConnection con = new SQLiteConnection("DataSource = " + Application.StartupPath + "\\" + fileName + ";Versio=3;New=False;Compress=True;"))
                {
                    con.Open();
                    //SQLiteDataAdapter da = new SQLiteDataAdapter("select url,title,visit_count,last_visit_time from urls order by last_visit_time desc", con);
                    SQLiteDataAdapter sd = new SQLiteDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    sd.Fill(ds);
                    dGrid.DataSource = ds.Tables[0];
                    con.Close();
                }
                try // File already open error is skipped
                {
                    if (File.Exists(Application.StartupPath + "\\" + fileName))
                        File.Delete(Application.StartupPath + "\\" + fileName);
                }
                catch (Exception er)
                {
                    //MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure history file exists." + er);
                }
            }
            catch (IOException er)
            {
                MessageBox.Show("Failed to retrieve " + name + "'s browser history. Please ensure you have opera installed on your system so that the history file exists.");
            }

        }
    }
}
