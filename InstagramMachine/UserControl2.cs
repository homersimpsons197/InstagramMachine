using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramMachine
{
    public partial class UserControl2 : UserControl
    {
        ActionController a;
        ImgResizer iR = new ImgResizer();

        //Variables
        public String temp;
        public String proxy;
        public String account;
        public String profile;
        public String path;
        public String filePath;
        public int intervalPost;
        public int intervalLike;
        public int intervalFollow;
        public int intervalUnfollow;
        public int nbOfLike;
        public int nbOfFollow;
        public int nbOfUnfollow;


        public UserControl2()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var color = ColorTranslator.FromHtml("#f0f0f0");
            var color2 = ColorTranslator.FromHtml("#4285f4");
            var pnl = new Panel();
            var lblProxy = new Label();
            var lblProfile = new Label();
            var lblPathImg = new Label();
            var lblStatus = new Label();
            var lblState = new Label();
            var lblInterval = new Label();
            var lblAmount = new Label();
            var lblAccount = new Label();
            var txtProxy = new TextBox();
            var txtIntervalPost = new TextBox();
            var txtIntervalLike = new TextBox();
            var txtIntervalFollow = new TextBox();
            var txtIntervalUnfollow = new TextBox();
            var txtNbLike = new TextBox();
            var txtNbFollow = new TextBox();
            var txtNbUnfollow = new TextBox();
            var txtAccount = new TextBox();
            var cBoxProfile = new ComboBox();
            var txtEmailPass = new TextBox();
            var txtPathImg = new TextBox();
            var btnStart = new Button();
            var btnStop = new Button();
            var btnClose = new Button();
            var chBoxPost = new CheckBox();
            var chBoxFollow = new CheckBox();
            var chBoxUnfollow = new CheckBox();
            var chBoxLike = new CheckBox();
            var chBoxProxy = new CheckBox();

            pnl.Name = "panel" + (panel0.Controls.Count);
            pnl.BackColor = color;
            pnl.Size = new Size(panel0.ClientSize.Width, 150);
            pnl.BorderStyle = BorderStyle.Fixed3D;
            pnl.Dock = DockStyle.Top;

            //Label Proxy
            lblProxy.Text = "Proxy";
            lblProxy.ForeColor = color2;
            lblProxy.Font = new Font("Verdana", lblProxy.Font.Size);
            lblProxy.Size = new Size(40, 15);
            lblProxy.Location = new Point(10, 90);
            pnl.Controls.Add(lblProxy);

            //Label Profile
            lblProfile.Text = "Profile";
            lblProfile.ForeColor = color2;
            lblProfile.Font = new Font("Verdana", lblProfile.Font.Size);
            lblProfile.Size = new Size(45, 15);
            lblProfile.Location = new Point(460, 90);
            pnl.Controls.Add(lblProfile);

            //Label Account
            lblAccount.Text = "Follow account";
            lblAccount.ForeColor = color2;
            lblAccount.Font = new Font("Verdana", lblAccount.Font.Size);
            lblAccount.Size = new Size(90, 15);
            lblAccount.Location = new Point(200, 90);
            pnl.Controls.Add(lblAccount);

            //Label Interval
            lblInterval.Text = "Interval";
            lblInterval.ForeColor = color2;
            lblInterval.Font = new Font("Verdana", lblInterval.Font.Size);
            lblInterval.Size = new Size(55, 15);
            lblInterval.Location = new Point(10, 30);
            pnl.Controls.Add(lblInterval);

            //Label Amount
            lblAmount.Text = "#";
            lblAmount.ForeColor = color2;
            lblAmount.Font = new Font("Verdana", lblAmount.Font.Size);
            lblAmount.Size = new Size(55, 15);
            lblAmount.Location = new Point(10, 57);
            pnl.Controls.Add(lblAmount);

            //Label PathImg
            lblPathImg.Text = "Path";
            lblPathImg.ForeColor = color2;
            lblPathImg.Font = new Font("Verdana", lblPathImg.Font.Size);
            lblPathImg.Size = new Size(40, 15);
            lblPathImg.Location = new Point(10, 120);
            pnl.Controls.Add(lblPathImg);

            //Label Status
            lblStatus.Text = "Status:";
            lblStatus.ForeColor = Color.Black;
            lblStatus.Font = new Font("Verdana", lblStatus.Font.Size);
            lblStatus.Size = new Size(50, 15);
            lblStatus.Location = new Point(504, 35);
            pnl.Controls.Add(lblStatus);

            //Label State
            lblState.Text = "Offline";
            lblState.ForeColor = Color.Red;
            lblState.Font = new Font("Verdana", lblState.Font.Size);
            lblState.Size = new Size(60, 30);
            lblState.Location = new Point(551, 35);
            pnl.Controls.Add(lblState);

            //TextBox for Proxy
            txtProxy.Name = "txtProxy";
            txtProxy.Size = new Size(120, 20);
            txtProxy.Location = new Point(70, 87);
            txtProxy.Enabled = false;
            pnl.Controls.Add(txtProxy);

            //TextBox for Account
            txtAccount.Name = "txtAccount";
            txtAccount.Size = new Size(120, 20);
            txtAccount.Location = new Point(310, 87);
            txtAccount.Enabled = false;
            pnl.Controls.Add(txtAccount);

            //TextBox for Post interval
            txtIntervalPost.Name = "txtIntervalPost";
            txtIntervalPost.Size = new Size(25, 20);
            txtIntervalPost.Location = new Point(70, 27);
            txtIntervalPost.Enabled = false;
            pnl.Controls.Add(txtIntervalPost);

            //TextBox for Like interval
            txtIntervalLike.Name = "txtIntervaLike";
            txtIntervalLike.Size = new Size(25, 20);
            txtIntervalLike.Location = new Point(150, 27);
            txtIntervalLike.Enabled = false;
            pnl.Controls.Add(txtIntervalLike);

            //TextBox for Follow interval
            txtIntervalFollow.Name = "txtIntervalFollow";
            txtIntervalFollow.Size = new Size(25, 20);
            txtIntervalFollow.Location = new Point(230, 27);
            txtIntervalFollow.Enabled = false;
            pnl.Controls.Add(txtIntervalFollow);

            //TextBox for Unfollow interval
            txtIntervalUnfollow.Name = "txtIntervalUnfollow";
            txtIntervalUnfollow.Size = new Size(25, 20);
            txtIntervalUnfollow.Location = new Point(310, 27);
            txtIntervalUnfollow.Enabled = false;
            pnl.Controls.Add(txtIntervalUnfollow);

            //TextBox for # Likes
            txtNbLike.Name = "txtNbLike";
            txtNbLike.Size = new Size(25, 20);
            txtNbLike.Location = new Point(150, 57);
            txtNbLike.Enabled = false;
            pnl.Controls.Add(txtNbLike);

            //TextBox for # Follows
            txtNbFollow.Name = "txtNbFollow";
            txtNbFollow.Size = new Size(25, 20);
            txtNbFollow.Location = new Point(230, 57);
            txtNbFollow.Enabled = false;
            pnl.Controls.Add(txtNbFollow);

            //TextBox for # Unfollows
            txtNbUnfollow.Name = "txtNbUnfollow";
            txtNbUnfollow.Size = new Size(25, 20);
            txtNbUnfollow.Location = new Point(310, 57);
            txtNbUnfollow.Enabled = false;
            pnl.Controls.Add(txtNbUnfollow);

            //ComboBox for Profile
            cBoxProfile.Name = "cBoxProfile";
            cBoxProfile.Size = new Size(70, 20);
            cBoxProfile.Location = new Point(520, 87);
            cBoxProfile.Items.Insert(0, "--Profile--");
            cBoxProfile.Items.Insert(1, "Profile 1");
            cBoxProfile.Items.Insert(2, "Profile 2");
            cBoxProfile.Items.Insert(3, "Profile 3");
            cBoxProfile.Items.Insert(4, "Profile 4");
            cBoxProfile.Items.Insert(5, "Profile 5");
            cBoxProfile.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxProfile.SelectedIndex = 0;
            pnl.Controls.Add(cBoxProfile);

            //TextBox for Path
            txtPathImg.Name = "txtPathImg";
            txtPathImg.Size = new Size(295, 20);
            txtPathImg.Location = new Point(70, 117);
            txtPathImg.Enabled = false;
            pnl.Controls.Add(txtPathImg);

            //Button Start
            btnStart.Name = "btnStart";
            btnStart.Text = "Start";
            btnStart.Font = new Font("Verdana", btnStart.Font.Size);
            btnStart.ForeColor = color2;
            btnStart.Size = new Size(50, 20);
            btnStart.Location = new Point(504, 7);
            btnStart.Click += (s, ex) => Task.Run(() =>
            {
                BtnStartClick(pnl, txtProxy, cBoxProfile, txtPathImg, txtIntervalPost, txtIntervalLike, txtIntervalFollow, txtIntervalUnfollow, lblState, chBoxPost, chBoxLike, chBoxFollow, chBoxUnfollow, chBoxProxy, txtNbLike, txtNbFollow, txtNbUnfollow, txtAccount);
            });
            pnl.Controls.Add(btnStart);

            //Button Close
            btnClose.Name = "btnClose";
            btnClose.Text = "Close";
            btnClose.Font = new Font("Verdana", btnClose.Font.Size);
            btnClose.ForeColor = color2;
            btnClose.Size = new Size(50, 20);
            btnClose.Location = new Point(555, 7);
            btnClose.Click += (s, ex) => Task.Run(() =>
            {
                BtnCloseClick(pnl);
            });
            pnl.Controls.Add(btnClose);

            //CheckBox Post
            chBoxPost.Name = "chBoxPost";
            chBoxPost.Text = "Post";
            chBoxPost.Font = new Font("Verdana", chBoxPost.Font.Size);
            chBoxPost.ForeColor = color2;
            chBoxPost.Size = new Size(50, 20);
            chBoxPost.CheckedChanged += (s, ex) => Task.Run(() =>
            {
                ChBoxPost(chBoxPost, chBoxLike, txtIntervalPost, txtPathImg);
            });
            chBoxPost.Location = new Point(70, 0);
            pnl.Controls.Add(chBoxPost);

            //CheckBox Like
            chBoxLike.Name = "chBoxLike";
            chBoxLike.Text = "Like";
            chBoxLike.Font = new Font("Verdana", chBoxPost.Font.Size);
            chBoxLike.ForeColor = color2;
            chBoxLike.Size = new Size(50, 20);
            chBoxLike.CheckedChanged += (s, ex) => Task.Run(() =>
            {
                ChBoxLike(chBoxLike, chBoxPost, txtIntervalLike, txtNbLike, txtPathImg);
            });
            chBoxLike.Location = new Point(150, 0);
            pnl.Controls.Add(chBoxLike);

            //CheckBox Follow
            chBoxFollow.Name = "chBoxFollow";
            chBoxFollow.Text = "Follow";
            chBoxFollow.Font = new Font("Verdana", chBoxFollow.Font.Size);
            chBoxFollow.ForeColor = color2;
            chBoxFollow.Size = new Size(70, 20);
            chBoxFollow.CheckedChanged += (s, ex) => Task.Run(() =>
            {
                ChBoxFollow(chBoxFollow, txtIntervalFollow, txtNbFollow, txtAccount);
            });
            chBoxFollow.Location = new Point(230, 0);
            pnl.Controls.Add(chBoxFollow);

            //CheckBox Unfollow
            chBoxUnfollow.Name = "chBoxUnfollow";
            chBoxUnfollow.Text = "Unfollow";
            chBoxUnfollow.Font = new Font("Verdana", chBoxUnfollow.Font.Size);
            chBoxUnfollow.ForeColor = color2;
            chBoxUnfollow.Size = new Size(75, 20);
            chBoxUnfollow.CheckedChanged += (s, ex) => Task.Run(() =>
            {
                ChBoxUnfollow(chBoxUnfollow, txtIntervalUnfollow, txtNbUnfollow);
            });
            chBoxUnfollow.Location = new Point(310, 0);
            pnl.Controls.Add(chBoxUnfollow);

            //CheckBox Proxy
            chBoxProxy.Name = "chBoxProxy";
            chBoxProxy.Text = "Proxy";
            chBoxProxy.Font = new Font("Verdana", chBoxProxy.Font.Size);
            chBoxProxy.ForeColor = color2;
            chBoxProxy.Size = new Size(70, 20);
            chBoxProxy.CheckedChanged += (s, ex) => Task.Run(() =>
            {
                ChBoxProxy(chBoxProxy, txtProxy);
            });
            chBoxProxy.Location = new Point(390, 0);
            pnl.Controls.Add(chBoxProxy);

            panel0.Controls.Add(pnl);
            panel0.AutoScroll = false;
            panel0.HorizontalScroll.Enabled = false;
            panel0.HorizontalScroll.Visible = false;
            panel0.HorizontalScroll.Maximum = 0;
            panel0.AutoScroll = true;
        }

        public async void BtnCloseClick(Panel p)
        {
            if (p.InvokeRequired)
            {
                p.Invoke(new MethodInvoker(delegate { p.Dispose(); }));
            }
        }

        public void ChBoxProxy(CheckBox c, TextBox t)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate
                {
                    t.Enabled = (c.CheckState == CheckState.Checked);
                }));
            }
        }

        public void ChBoxPost(CheckBox c, CheckBox c2, TextBox t, TextBox t2)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate
                {
                    t.Enabled = (c.CheckState == CheckState.Checked);
                    if (!c2.Checked)
                        t2.Enabled = (c.CheckState == CheckState.Checked);
                }));
            }
        }

        public void ChBoxLike(CheckBox c, CheckBox c2, TextBox t, TextBox t2, TextBox t3)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate
                {
                    t.Enabled = (c.CheckState == CheckState.Checked);
                    t2.Enabled = (c.CheckState == CheckState.Checked);
                    if (!c2.Checked)
                        t3.Enabled = (c.CheckState == CheckState.Checked);
                }));
            }
        }

        public void ChBoxFollow(CheckBox c, TextBox t, TextBox t2, TextBox t3)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate
                {
                    t.Enabled = (c.CheckState == CheckState.Checked);
                    t2.Enabled = (c.CheckState == CheckState.Checked);
                    t3.Enabled = (c.CheckState == CheckState.Checked);
                }));
            }
        }

        public void ChBoxUnfollow(CheckBox c, TextBox t, TextBox t2)
        {
            if (c.InvokeRequired)
            {
                c.Invoke(new MethodInvoker(delegate
                {
                    t.Enabled = (c.CheckState == CheckState.Checked);
                    t2.Enabled = (c.CheckState == CheckState.Checked);
                }));
            }
        }

        public async void BtnStartClick(Panel p, TextBox prox, ComboBox prof, TextBox path, TextBox iPost, TextBox iLike, TextBox iFollow, TextBox iUnfollow, Label state, CheckBox cPost, CheckBox cLike, CheckBox cFollow, CheckBox cUnfollow, CheckBox cP, TextBox nbLike, TextBox nbFollow, TextBox nbUnfollow, TextBox acc)
        {

            if (cP.Checked)
            {
                proxy = prox.Text;
            }
            if (cUnfollow.Checked && iUnfollow.Text != String.Empty && nbUnfollow.Text != String.Empty)
            {
                intervalUnfollow = int.Parse(iUnfollow.Text);
                //intervalUnfollow = (intervalUnfollow * 1000 * 60 * 60);
                nbOfUnfollow = int.Parse(nbUnfollow.Text);
            }
            if (cFollow.Checked && iFollow.Text != String.Empty && nbFollow.Text != String.Empty && acc.Text != String.Empty)
            {
                intervalFollow = int.Parse(iFollow.Text);
                //intervalFollow = (intervalFollow * 1000 * 60 * 60);
                nbOfFollow = int.Parse(nbFollow.Text);
                account = acc.Text;
            }
            if (cLike.Checked && iLike.Text != String.Empty && nbLike.Text != String.Empty)
            {
                intervalLike = int.Parse(iLike.Text);
                //intervalLike = (intervalLike * 1000 * 60 * 60);
                nbOfLike = int.Parse(nbLike.Text);
                filePath = path.Text;
            }
            if (cPost.Checked && iPost.Text != String.Empty && path.Text != String.Empty)
            {
                intervalPost = int.Parse(iPost.Text);
                //intervalPost = (intervalPost * 1000 * 60 * 60);
                filePath = path.Text;
            }
            if (prof.InvokeRequired)
            {
                prof.Invoke(new MethodInvoker(delegate
                {
                    profile = prof.GetItemText(prof.SelectedItem);
                }));
            }

            a = new ActionController(this);

            await Task.Run( () =>
            {                
                if (cPost.Checked)
                {
                    OnTimerPost(intervalPost, filePath, proxy, profile, state);
                }
                if (cLike.Checked)
                {            
                    OnTimerLike(intervalLike, filePath, proxy, profile, nbOfLike, state);
                }
                if (cFollow.Checked)
                {                
                    OnTimerFollow(intervalFollow, filePath, proxy, profile, nbOfFollow, account, state);              
                }
                if (cUnfollow.Checked)
                {                
                    OnTimerUnfollow(intervalUnfollow, filePath, proxy, profile, nbOfUnfollow, state);               
                }
            });


        }

        public async void OnTimerPost(int intervalPost, String filePath, String proxy, String profile, Label state)
        {
            do
            {
                await Task.Delay(intervalPost);
                a.Post(filePath, proxy, profile, state);
            }
            while (true);
        }

        public async void OnTimerLike(int intervalLike, String filePath, String proxy, String profile, int nbOfLike, Label state)
        {
            do
            {
                await Task.Delay(intervalLike);
                a.Like(filePath, proxy, profile, nbOfLike, state);
            }
            while(true);
        }

        public async void OnTimerFollow(int intervalFollow, String filePath, String proxy, String profile, int nbOfFollow, String account, Label state)
        {
            do
            {
                await Task.Delay(intervalFollow);
                a.Follow(filePath, proxy, profile, nbOfFollow, account, state);
            }
            while (true);
        }

        public async void OnTimerUnfollow(int intervalUnfollow, String filePath, String proxy, String profile, int nbOfUnfollow, Label state)
        {
            do
            {
                await Task.Delay(intervalUnfollow);
                a.Unfollow(filePath, proxy, profile, nbOfUnfollow, state);
            }
            while (true);
        }
    }
}
