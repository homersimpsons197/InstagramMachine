using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramMachine
{
    public partial class Form1 : Form
    {
        UserControl1 uc1 = new UserControl1();
        UserControl2 uc2 = new UserControl2();
        ActionController ac = new ActionController();
        public static String rawComputerName;
        public static String computerName;
        public static String path;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlControl.Controls.Add(uc1);
            uc1.Hide();
            pnlControl.Controls.Add(uc2);
            uc2.Hide();

            rawComputerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            computerName = rawComputerName.Substring(rawComputerName.LastIndexOf('\\') + 1).ToLower();
            lblComputerName.Text = computerName;

            path = (String.Format("C:\\Users\\{0}\\AppData\\Local\\Google\\Chrome\\User Data", computerName));
            lblTemporaryPath.Text = path;

            try
            {
                byte[] bytes1 = Properties.Resources.chromedriver;
                File.WriteAllBytes(path + "\\chromedriver.exe", bytes1);

                byte[] bytes2 = Properties.Resources.SeleniumExtras_WaitHelpers;
                File.WriteAllBytes(path + "\\SeleniumExtras.WaitHelpers.dll", bytes2);

                byte[] bytes3 = Properties.Resources.WebDriver;
                File.WriteAllBytes(path + "\\WebDriver.dll", bytes3);

                lblDriverState.Text = "Succes";
                lblDriverState.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblDriverState.Text = "Failed";
                lblDriverState.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete(path + "\\chromedriver.exe");
            File.Delete(path + "\\SeleniumExtras.WaitHelpers.dll");
            File.Delete(path + "\\WebDriver.dll");
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            uc1.BringToFront();
            uc1.Show();
            if(ac.GetActualProfile() == "Profile 1")
            {
                uc1.lblAccountName1.Text = ac.GetAccountName();
                uc1.lblNbOfPosts1.Text = ac.GetPosts();
                uc1.lblNbOfFollowers1.Text = ac.GetFollowers();
                uc1.lblNbOfFollowing1.Text = ac.GetFollowing();
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            uc2.BringToFront();
            uc2.Show();            
        }

        public String GetComputerName()
        {
            return computerName;
        }
    }
}
