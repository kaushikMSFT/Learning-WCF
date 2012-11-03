namespace WinClient
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
            this.cmdAdminOp = new System.Windows.Forms.Button();
            this.cmdUserOp = new System.Windows.Forms.Button();
            this.cmdGuestOp = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radSoap12UserNameSecureReliableSession = new System.Windows.Forms.RadioButton();
            this.radSoap12UserNameOneShot = new System.Windows.Forms.RadioButton();
            this.radSoap12UserNameSSL = new System.Windows.Forms.RadioButton();
            this.radSoap12UserNameSecureSession = new System.Windows.Forms.RadioButton();
            this.radSoap11UserNameSSL = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAdminOp
            // 
            this.cmdAdminOp.Location = new System.Drawing.Point(272, 49);
            this.cmdAdminOp.Name = "cmdAdminOp";
            this.cmdAdminOp.Size = new System.Drawing.Size(149, 31);
            this.cmdAdminOp.TabIndex = 0;
            this.cmdAdminOp.Text = "Admin Operation";
            this.cmdAdminOp.UseVisualStyleBackColor = true;
            this.cmdAdminOp.Click += new System.EventHandler(this.cmdAdminOp_Click);
            // 
            // cmdUserOp
            // 
            this.cmdUserOp.Location = new System.Drawing.Point(272, 91);
            this.cmdUserOp.Name = "cmdUserOp";
            this.cmdUserOp.Size = new System.Drawing.Size(149, 31);
            this.cmdUserOp.TabIndex = 1;
            this.cmdUserOp.Text = "User Operation";
            this.cmdUserOp.UseVisualStyleBackColor = true;
            this.cmdUserOp.Click += new System.EventHandler(this.cmdUserOp_Click);
            // 
            // cmdGuestOp
            // 
            this.cmdGuestOp.Location = new System.Drawing.Point(272, 133);
            this.cmdGuestOp.Name = "cmdGuestOp";
            this.cmdGuestOp.Size = new System.Drawing.Size(149, 31);
            this.cmdGuestOp.TabIndex = 2;
            this.cmdGuestOp.Text = "Guest Operation";
            this.cmdGuestOp.UseVisualStyleBackColor = true;
            this.cmdGuestOp.Click += new System.EventHandler(this.cmdGuestOp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLogin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuLogin
            // 
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(52, 20);
            this.mnuLogin.Text = "Login!";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radSoap12UserNameSecureReliableSession);
            this.groupBox2.Controls.Add(this.radSoap12UserNameOneShot);
            this.groupBox2.Controls.Add(this.radSoap12UserNameSSL);
            this.groupBox2.Controls.Add(this.radSoap12UserNameSecureSession);
            this.groupBox2.Controls.Add(this.radSoap11UserNameSSL);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 247);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Protocol";
            // 
            // radSoap12UserNameSecureReliableSession
            // 
            this.radSoap12UserNameSecureReliableSession.AutoSize = true;
            this.radSoap12UserNameSecureReliableSession.Location = new System.Drawing.Point(24, 144);
            this.radSoap12UserNameSecureReliableSession.Name = "radSoap12UserNameSecureReliableSession";
            this.radSoap12UserNameSecureReliableSession.Size = new System.Drawing.Size(190, 17);
            this.radSoap12UserNameSecureReliableSession.TabIndex = 26;
            this.radSoap12UserNameSecureReliableSession.Text = "SOAP 1.2 Secure Reliable Session";
            this.radSoap12UserNameSecureReliableSession.UseVisualStyleBackColor = true;
            // 
            // radSoap12UserNameOneShot
            // 
            this.radSoap12UserNameOneShot.AutoSize = true;
            this.radSoap12UserNameOneShot.Location = new System.Drawing.Point(24, 98);
            this.radSoap12UserNameOneShot.Name = "radSoap12UserNameOneShot";
            this.radSoap12UserNameOneShot.Size = new System.Drawing.Size(120, 17);
            this.radSoap12UserNameOneShot.TabIndex = 25;
            this.radSoap12UserNameOneShot.Text = "SOAP 1.2 One Shot";
            this.radSoap12UserNameOneShot.UseVisualStyleBackColor = true;
            // 
            // radSoap12UserNameSSL
            // 
            this.radSoap12UserNameSSL.AutoSize = true;
            this.radSoap12UserNameSSL.Location = new System.Drawing.Point(24, 75);
            this.radSoap12UserNameSSL.Name = "radSoap12UserNameSSL";
            this.radSoap12UserNameSSL.Size = new System.Drawing.Size(95, 17);
            this.radSoap12UserNameSSL.TabIndex = 24;
            this.radSoap12UserNameSSL.Text = "SOAP 1.2 SSL";
            this.radSoap12UserNameSSL.UseVisualStyleBackColor = true;
            // 
            // radSoap12UserNameSecureSession
            // 
            this.radSoap12UserNameSecureSession.AutoSize = true;
            this.radSoap12UserNameSecureSession.Location = new System.Drawing.Point(24, 121);
            this.radSoap12UserNameSecureSession.Name = "radSoap12UserNameSecureSession";
            this.radSoap12UserNameSecureSession.Size = new System.Drawing.Size(149, 17);
            this.radSoap12UserNameSecureSession.TabIndex = 22;
            this.radSoap12UserNameSecureSession.Text = "SOAP 1.2 Secure Session";
            this.radSoap12UserNameSecureSession.UseVisualStyleBackColor = true;
            // 
            // radSoap11UserNameSSL
            // 
            this.radSoap11UserNameSSL.AutoSize = true;
            this.radSoap11UserNameSSL.Checked = true;
            this.radSoap11UserNameSSL.Location = new System.Drawing.Point(24, 29);
            this.radSoap11UserNameSSL.Name = "radSoap11UserNameSSL";
            this.radSoap11UserNameSSL.Size = new System.Drawing.Size(95, 17);
            this.radSoap11UserNameSSL.TabIndex = 21;
            this.radSoap11UserNameSSL.TabStop = true;
            this.radSoap11UserNameSSL.Text = "SOAP 1.1 SSL";
            this.radSoap11UserNameSSL.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 280);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdGuestOp);
            this.Controls.Add(this.cmdUserOp);
            this.Controls.Add(this.cmdAdminOp);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "WinClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAdminOp;
        private System.Windows.Forms.Button cmdUserOp;
        private System.Windows.Forms.Button cmdGuestOp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radSoap12UserNameSecureSession;
        private System.Windows.Forms.RadioButton radSoap11UserNameSSL;
        private System.Windows.Forms.RadioButton radSoap12UserNameOneShot;
        private System.Windows.Forms.RadioButton radSoap12UserNameSSL;
        private System.Windows.Forms.RadioButton radSoap12UserNameSecureReliableSession;
    }
}

