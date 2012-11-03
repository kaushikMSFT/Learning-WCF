namespace Publisher
{
    partial class PublisherForm
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
            this.lstSubscribers = new System.Windows.Forms.ListBox();
            this.cmdNotifyAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSubscribers
            // 
            this.lstSubscribers.FormattingEnabled = true;
            this.lstSubscribers.Location = new System.Drawing.Point(12, 12);
            this.lstSubscribers.Name = "lstSubscribers";
            this.lstSubscribers.Size = new System.Drawing.Size(254, 160);
            this.lstSubscribers.TabIndex = 1;
            // 
            // cmdNotifyAll
            // 
            this.cmdNotifyAll.Location = new System.Drawing.Point(94, 178);
            this.cmdNotifyAll.Name = "cmdNotifyAll";
            this.cmdNotifyAll.Size = new System.Drawing.Size(75, 23);
            this.cmdNotifyAll.TabIndex = 2;
            this.cmdNotifyAll.Text = "Notify All";
            this.cmdNotifyAll.UseVisualStyleBackColor = true;
            this.cmdNotifyAll.Click += new System.EventHandler(this.cmdNotifyAll_Click);
            // 
            // PublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 211);
            this.Controls.Add(this.cmdNotifyAll);
            this.Controls.Add(this.lstSubscribers);
            this.Name = "PublisherForm";
            this.Text = "Publisher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PublisherForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSubscribers;
        private System.Windows.Forms.Button cmdNotifyAll;
    }
}