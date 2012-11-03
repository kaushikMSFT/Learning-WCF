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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radAnonymous = new System.Windows.Forms.RadioButton();
            this.radIdentification = new System.Windows.Forms.RadioButton();
            this.radImpersonation = new System.Windows.Forms.RadioButton();
            this.radDelegation = new System.Windows.Forms.RadioButton();
            this.radNone = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ImpersonationNotAllowed()";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radNone);
            this.groupBox1.Controls.Add(this.radDelegation);
            this.groupBox1.Controls.Add(this.radImpersonation);
            this.groupBox1.Controls.Add(this.radIdentification);
            this.groupBox1.Controls.Add(this.radAnonymous);
            this.groupBox1.Location = new System.Drawing.Point(40, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impersonation Level";
            // 
            // radAnonymous
            // 
            this.radAnonymous.AutoSize = true;
            this.radAnonymous.Location = new System.Drawing.Point(20, 20);
            this.radAnonymous.Name = "radAnonymous";
            this.radAnonymous.Size = new System.Drawing.Size(80, 17);
            this.radAnonymous.TabIndex = 0;
            this.radAnonymous.TabStop = true;
            this.radAnonymous.Text = "Anonymous";
            this.radAnonymous.UseVisualStyleBackColor = true;
            // 
            // radIdentification
            // 
            this.radIdentification.AutoSize = true;
            this.radIdentification.Location = new System.Drawing.Point(20, 43);
            this.radIdentification.Name = "radIdentification";
            this.radIdentification.Size = new System.Drawing.Size(85, 17);
            this.radIdentification.TabIndex = 1;
            this.radIdentification.TabStop = true;
            this.radIdentification.Text = "Identification";
            this.radIdentification.UseVisualStyleBackColor = true;
            // 
            // radImpersonation
            // 
            this.radImpersonation.AutoSize = true;
            this.radImpersonation.Location = new System.Drawing.Point(20, 66);
            this.radImpersonation.Name = "radImpersonation";
            this.radImpersonation.Size = new System.Drawing.Size(91, 17);
            this.radImpersonation.TabIndex = 2;
            this.radImpersonation.TabStop = true;
            this.radImpersonation.Text = "Impersonation";
            this.radImpersonation.UseVisualStyleBackColor = true;
            // 
            // radDelegation
            // 
            this.radDelegation.AutoSize = true;
            this.radDelegation.Location = new System.Drawing.Point(106, 20);
            this.radDelegation.Name = "radDelegation";
            this.radDelegation.Size = new System.Drawing.Size(76, 17);
            this.radDelegation.TabIndex = 3;
            this.radDelegation.TabStop = true;
            this.radDelegation.Text = "Delegation";
            this.radDelegation.UseVisualStyleBackColor = true;
            // 
            // radNone
            // 
            this.radNone.AutoSize = true;
            this.radNone.Location = new System.Drawing.Point(106, 43);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(51, 17);
            this.radNone.TabIndex = 4;
            this.radNone.TabStop = true;
            this.radNone.Text = "None";
            this.radNone.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "ImpersonationAllowed()";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(60, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "ImpersonationRequired()";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Impersonation Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radNone;
        private System.Windows.Forms.RadioButton radDelegation;
        private System.Windows.Forms.RadioButton radImpersonation;
        private System.Windows.Forms.RadioButton radIdentification;
        private System.Windows.Forms.RadioButton radAnonymous;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

