namespace InstagramMachine
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStats = new System.Windows.Forms.Button();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.lblDriverState = new System.Windows.Forms.Label();
            this.lblDrivers = new System.Windows.Forms.Label();
            this.lblTemporaryPath = new System.Windows.Forms.Label();
            this.lblDriverPath = new System.Windows.Forms.Label();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnAccount = new System.Windows.Forms.Button();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStats
            // 
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStats.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnStats.Location = new System.Drawing.Point(0, 0);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(100, 40);
            this.btnStats.TabIndex = 0;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.lblDriverState);
            this.pnlControl.Controls.Add(this.lblDrivers);
            this.pnlControl.Controls.Add(this.lblTemporaryPath);
            this.pnlControl.Controls.Add(this.lblDriverPath);
            this.pnlControl.Controls.Add(this.lblComputerName);
            this.pnlControl.Controls.Add(this.lblUsername);
            this.pnlControl.Location = new System.Drawing.Point(107, 12);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(621, 220);
            this.pnlControl.TabIndex = 1;
            // 
            // lblDriverState
            // 
            this.lblDriverState.AutoSize = true;
            this.lblDriverState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverState.ForeColor = System.Drawing.Color.Black;
            this.lblDriverState.Location = new System.Drawing.Point(153, 62);
            this.lblDriverState.Name = "lblDriverState";
            this.lblDriverState.Size = new System.Drawing.Size(134, 16);
            this.lblDriverState.TabIndex = 9;
            this.lblDriverState.Text = "ComputerUsername";
            // 
            // lblDrivers
            // 
            this.lblDrivers.AutoSize = true;
            this.lblDrivers.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrivers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.lblDrivers.Location = new System.Drawing.Point(3, 62);
            this.lblDrivers.Name = "lblDrivers";
            this.lblDrivers.Size = new System.Drawing.Size(113, 16);
            this.lblDrivers.TabIndex = 8;
            this.lblDrivers.Text = "Drivers injection";
            // 
            // lblTemporaryPath
            // 
            this.lblTemporaryPath.AutoSize = true;
            this.lblTemporaryPath.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemporaryPath.ForeColor = System.Drawing.Color.Black;
            this.lblTemporaryPath.Location = new System.Drawing.Point(153, 31);
            this.lblTemporaryPath.Name = "lblTemporaryPath";
            this.lblTemporaryPath.Size = new System.Drawing.Size(134, 16);
            this.lblTemporaryPath.TabIndex = 7;
            this.lblTemporaryPath.Text = "ComputerUsername";
            // 
            // lblDriverPath
            // 
            this.lblDriverPath.AutoSize = true;
            this.lblDriverPath.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.lblDriverPath.Location = new System.Drawing.Point(3, 31);
            this.lblDriverPath.Name = "lblDriverPath";
            this.lblDriverPath.Size = new System.Drawing.Size(80, 16);
            this.lblDriverPath.TabIndex = 6;
            this.lblDriverPath.Text = "Driver path";
            // 
            // lblComputerName
            // 
            this.lblComputerName.AutoSize = true;
            this.lblComputerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComputerName.ForeColor = System.Drawing.Color.Black;
            this.lblComputerName.Location = new System.Drawing.Point(153, 0);
            this.lblComputerName.Name = "lblComputerName";
            this.lblComputerName.Size = new System.Drawing.Size(134, 16);
            this.lblComputerName.TabIndex = 5;
            this.lblComputerName.Text = "ComputerUsername";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.lblUsername.Location = new System.Drawing.Point(3, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(138, 16);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Computer username";
            // 
            // btnAccount
            // 
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnAccount.Location = new System.Drawing.Point(0, 41);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(100, 40);
            this.btnAccount.TabIndex = 2;
            this.btnAccount.Text = "Accounts";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 237);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.btnStats);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnStats;
        public System.Windows.Forms.Panel pnlControl;
        public System.Windows.Forms.Button btnAccount;
        public System.Windows.Forms.Label lblTemporaryPath;
        public System.Windows.Forms.Label lblDriverPath;
        public System.Windows.Forms.Label lblComputerName;
        public System.Windows.Forms.Label lblUsername;
        public System.Windows.Forms.Label lblDriverState;
        public System.Windows.Forms.Label lblDrivers;
    }
}

