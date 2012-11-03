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
            this.cmdInvoke = new System.Windows.Forms.Button();
            this.rbTcpBinding = new System.Windows.Forms.RadioButton();
            this.rbNamedPipesBinding = new System.Windows.Forms.RadioButton();
            this.rbHttpBinding = new System.Windows.Forms.RadioButton();
            this.rbCustomHttpBinding = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdInvoke
            // 
            this.cmdInvoke.Location = new System.Drawing.Point(53, 84);
            this.cmdInvoke.Name = "cmdInvoke";
            this.cmdInvoke.Size = new System.Drawing.Size(131, 23);
            this.cmdInvoke.TabIndex = 1;
            this.cmdInvoke.Text = "Invoke One-Way";
            this.cmdInvoke.UseVisualStyleBackColor = true;
            this.cmdInvoke.Click += new System.EventHandler(this.cmdInvoke_Click);
            // 
            // rbTcpBinding
            // 
            this.rbTcpBinding.AutoSize = true;
            this.rbTcpBinding.Checked = true;
            this.rbTcpBinding.Location = new System.Drawing.Point(12, 12);
            this.rbTcpBinding.Name = "rbTcpBinding";
            this.rbTcpBinding.Size = new System.Drawing.Size(46, 17);
            this.rbTcpBinding.TabIndex = 2;
            this.rbTcpBinding.TabStop = true;
            this.rbTcpBinding.Text = "TCP";
            this.rbTcpBinding.UseVisualStyleBackColor = true;
            // 
            // rbNamedPipesBinding
            // 
            this.rbNamedPipesBinding.AutoSize = true;
            this.rbNamedPipesBinding.Location = new System.Drawing.Point(12, 36);
            this.rbNamedPipesBinding.Name = "rbNamedPipesBinding";
            this.rbNamedPipesBinding.Size = new System.Drawing.Size(88, 17);
            this.rbNamedPipesBinding.TabIndex = 3;
            this.rbNamedPipesBinding.Text = "Named Pipes";
            this.rbNamedPipesBinding.UseVisualStyleBackColor = true;
            // 
            // rbHttpBinding
            // 
            this.rbHttpBinding.AutoSize = true;
            this.rbHttpBinding.Location = new System.Drawing.Point(130, 12);
            this.rbHttpBinding.Name = "rbHttpBinding";
            this.rbHttpBinding.Size = new System.Drawing.Size(54, 17);
            this.rbHttpBinding.TabIndex = 4;
            this.rbHttpBinding.Text = "HTTP";
            this.rbHttpBinding.UseVisualStyleBackColor = true;
            // 
            // rbCustomHttpBinding
            // 
            this.rbCustomHttpBinding.AutoSize = true;
            this.rbCustomHttpBinding.Location = new System.Drawing.Point(130, 36);
            this.rbCustomHttpBinding.Name = "rbCustomHttpBinding";
            this.rbCustomHttpBinding.Size = new System.Drawing.Size(92, 17);
            this.rbCustomHttpBinding.TabIndex = 5;
            this.rbCustomHttpBinding.Text = "Custom HTTP";
            this.rbCustomHttpBinding.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Invoke Request-Reply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 149);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbCustomHttpBinding);
            this.Controls.Add(this.rbHttpBinding);
            this.Controls.Add(this.rbNamedPipesBinding);
            this.Controls.Add(this.rbTcpBinding);
            this.Controls.Add(this.cmdInvoke);
            this.Name = "Form1";
            this.Text = "Callback Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdInvoke;
        private System.Windows.Forms.RadioButton rbTcpBinding;
        private System.Windows.Forms.RadioButton rbNamedPipesBinding;
        private System.Windows.Forms.RadioButton rbHttpBinding;
        private System.Windows.Forms.RadioButton rbCustomHttpBinding;
        private System.Windows.Forms.Button button1;
    }
}

