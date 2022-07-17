namespace InstagramMachine
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblAccountName1 = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblNbOfPosts1 = new System.Windows.Forms.Label();
            this.lnlPost = new System.Windows.Forms.Label();
            this.lblNbOfFollowers1 = new System.Windows.Forms.Label();
            this.lblFollower = new System.Windows.Forms.Label();
            this.lblNbOfFollowing1 = new System.Windows.Forms.Label();
            this.lblFollowing = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(614, 213);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNbOfFollowing1);
            this.tabPage1.Controls.Add(this.lblFollowing);
            this.tabPage1.Controls.Add(this.lblNbOfFollowers1);
            this.tabPage1.Controls.Add(this.lblFollower);
            this.tabPage1.Controls.Add(this.lblNbOfPosts1);
            this.tabPage1.Controls.Add(this.lnlPost);
            this.tabPage1.Controls.Add(this.lblAccountName1);
            this.tabPage1.Controls.Add(this.lblAccount);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(606, 187);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblAccountName1
            // 
            this.lblAccountName1.AutoSize = true;
            this.lblAccountName1.Location = new System.Drawing.Point(116, 7);
            this.lblAccountName1.Name = "lblAccountName1";
            this.lblAccountName1.Size = new System.Drawing.Size(35, 13);
            this.lblAccountName1.TabIndex = 1;
            this.lblAccountName1.Text = "label1";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccount.Location = new System.Drawing.Point(7, 7);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(58, 13);
            this.lblAccount.TabIndex = 0;
            this.lblAccount.Text = "Account:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(606, 187);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblNbOfPosts1
            // 
            this.lblNbOfPosts1.AutoSize = true;
            this.lblNbOfPosts1.Location = new System.Drawing.Point(116, 30);
            this.lblNbOfPosts1.Name = "lblNbOfPosts1";
            this.lblNbOfPosts1.Size = new System.Drawing.Size(35, 13);
            this.lblNbOfPosts1.TabIndex = 3;
            this.lblNbOfPosts1.Text = "label1";
            // 
            // lnlPost
            // 
            this.lnlPost.AutoSize = true;
            this.lnlPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnlPost.Location = new System.Drawing.Point(7, 30);
            this.lnlPost.Name = "lnlPost";
            this.lnlPost.Size = new System.Drawing.Size(76, 13);
            this.lnlPost.TabIndex = 2;
            this.lnlPost.Text = "Nb of posts:";
            // 
            // lblNbOfFollowers1
            // 
            this.lblNbOfFollowers1.AutoSize = true;
            this.lblNbOfFollowers1.Location = new System.Drawing.Point(116, 53);
            this.lblNbOfFollowers1.Name = "lblNbOfFollowers1";
            this.lblNbOfFollowers1.Size = new System.Drawing.Size(35, 13);
            this.lblNbOfFollowers1.TabIndex = 5;
            this.lblNbOfFollowers1.Text = "label1";
            // 
            // lblFollower
            // 
            this.lblFollower.AutoSize = true;
            this.lblFollower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFollower.Location = new System.Drawing.Point(7, 53);
            this.lblFollower.Name = "lblFollower";
            this.lblFollower.Size = new System.Drawing.Size(96, 13);
            this.lblFollower.TabIndex = 4;
            this.lblFollower.Text = "Nb of followers:";
            // 
            // lblNbOfFollowing1
            // 
            this.lblNbOfFollowing1.AutoSize = true;
            this.lblNbOfFollowing1.Location = new System.Drawing.Point(116, 76);
            this.lblNbOfFollowing1.Name = "lblNbOfFollowing1";
            this.lblNbOfFollowing1.Size = new System.Drawing.Size(35, 13);
            this.lblNbOfFollowing1.TabIndex = 7;
            this.lblNbOfFollowing1.Text = "label1";
            // 
            // lblFollowing
            // 
            this.lblFollowing.AutoSize = true;
            this.lblFollowing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFollowing.Location = new System.Drawing.Point(7, 76);
            this.lblFollowing.Name = "lblFollowing";
            this.lblFollowing.Size = new System.Drawing.Size(81, 13);
            this.lblFollowing.TabIndex = 6;
            this.lblFollowing.Text = "Nb following:";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(621, 220);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.Label lblAccountName1;
        public System.Windows.Forms.Label lblNbOfFollowing1;
        private System.Windows.Forms.Label lblFollowing;
        public System.Windows.Forms.Label lblNbOfFollowers1;
        private System.Windows.Forms.Label lblFollower;
        public System.Windows.Forms.Label lblNbOfPosts1;
        private System.Windows.Forms.Label lnlPost;
    }
}
