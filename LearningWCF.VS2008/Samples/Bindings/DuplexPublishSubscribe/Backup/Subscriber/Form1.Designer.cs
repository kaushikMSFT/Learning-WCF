namespace Subscriber
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
            this.cmdSubscribe = new System.Windows.Forms.Button();
            this.cmdUnsubscribe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSubscribe
            // 
            this.cmdSubscribe.Location = new System.Drawing.Point(52, 12);
            this.cmdSubscribe.Name = "cmdSubscribe";
            this.cmdSubscribe.Size = new System.Drawing.Size(131, 23);
            this.cmdSubscribe.TabIndex = 1;
            this.cmdSubscribe.Text = "Subscribe";
            this.cmdSubscribe.UseVisualStyleBackColor = true;
            this.cmdSubscribe.Click += new System.EventHandler(this.cmdSubscribe_Click);
            // 
            // cmdUnsubscribe
            // 
            this.cmdUnsubscribe.Location = new System.Drawing.Point(52, 50);
            this.cmdUnsubscribe.Name = "cmdUnsubscribe";
            this.cmdUnsubscribe.Size = new System.Drawing.Size(131, 23);
            this.cmdUnsubscribe.TabIndex = 2;
            this.cmdUnsubscribe.Text = "Unsubscribe";
            this.cmdUnsubscribe.UseVisualStyleBackColor = true;
            this.cmdUnsubscribe.Click += new System.EventHandler(this.cmdUnsubscribe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 102);
            this.Controls.Add(this.cmdUnsubscribe);
            this.Controls.Add(this.cmdSubscribe);
            this.Name = "Form1";
            this.Text = "Subscriber";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdSubscribe;
        private System.Windows.Forms.Button cmdUnsubscribe;
    }
}

