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
          this.radWSHttpCustomRM = new System.Windows.Forms.RadioButton();
          this.radWSHttpSecureRM = new System.Windows.Forms.RadioButton();
          this.radNetTcpRM = new System.Windows.Forms.RadioButton();
          this.radWSHttpRM = new System.Windows.Forms.RadioButton();
          this.radNetPipeCustomRM = new System.Windows.Forms.RadioButton();
          this.radNetTcpCustomRM = new System.Windows.Forms.RadioButton();
          this.groupBox1.SuspendLayout();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(288, 35);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 0;
          this.button1.Text = "Send";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.radWSHttpCustomRM);
          this.groupBox1.Controls.Add(this.radWSHttpSecureRM);
          this.groupBox1.Controls.Add(this.radNetTcpRM);
          this.groupBox1.Controls.Add(this.radWSHttpRM);
          this.groupBox1.Controls.Add(this.radNetPipeCustomRM);
          this.groupBox1.Controls.Add(this.radNetTcpCustomRM);
          this.groupBox1.Location = new System.Drawing.Point(13, 13);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(248, 174);
          this.groupBox1.TabIndex = 3;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Binding";
          // 
          // radWSHttpCustomRM
          // 
          this.radWSHttpCustomRM.AutoSize = true;
          this.radWSHttpCustomRM.Location = new System.Drawing.Point(17, 137);
          this.radWSHttpCustomRM.Name = "radWSHttpCustomRM";
          this.radWSHttpCustomRM.Size = new System.Drawing.Size(109, 17);
          this.radWSHttpCustomRM.TabIndex = 5;
          this.radWSHttpCustomRM.TabStop = true;
          this.radWSHttpCustomRM.Text = "WS Http (custom)";
          this.radWSHttpCustomRM.UseVisualStyleBackColor = true;
          // 
          // radWSHttpSecureRM
          // 
          this.radWSHttpSecureRM.AutoSize = true;
          this.radWSHttpSecureRM.Location = new System.Drawing.Point(17, 68);
          this.radWSHttpSecureRM.Name = "radWSHttpSecureRM";
          this.radWSHttpSecureRM.Size = new System.Drawing.Size(149, 17);
          this.radWSHttpSecureRM.TabIndex = 4;
          this.radWSHttpSecureRM.TabStop = true;
          this.radWSHttpSecureRM.Text = "WS Http (Secure Session)";
          this.radWSHttpSecureRM.UseVisualStyleBackColor = true;
          // 
          // radNetTcpRM
          // 
          this.radNetTcpRM.AutoSize = true;
          this.radNetTcpRM.Location = new System.Drawing.Point(17, 114);
          this.radNetTcpRM.Name = "radNetTcpRM";
          this.radNetTcpRM.Size = new System.Drawing.Size(49, 17);
          this.radNetTcpRM.TabIndex = 3;
          this.radNetTcpRM.TabStop = true;
          this.radNetTcpRM.Text = "TCP ";
          this.radNetTcpRM.UseVisualStyleBackColor = true;
          // 
          // radWSHttpRM
          // 
          this.radWSHttpRM.AutoSize = true;
          this.radWSHttpRM.Location = new System.Drawing.Point(17, 45);
          this.radWSHttpRM.Name = "radWSHttpRM";
          this.radWSHttpRM.Size = new System.Drawing.Size(66, 17);
          this.radWSHttpRM.TabIndex = 2;
          this.radWSHttpRM.TabStop = true;
          this.radWSHttpRM.Text = "WS Http";
          this.radWSHttpRM.UseVisualStyleBackColor = true;
          // 
          // radNetPipeCustomRM
          // 
          this.radNetPipeCustomRM.AutoSize = true;
          this.radNetPipeCustomRM.Location = new System.Drawing.Point(17, 91);
          this.radNetPipeCustomRM.Name = "radNetPipeCustomRM";
          this.radNetPipeCustomRM.Size = new System.Drawing.Size(131, 17);
          this.radNetPipeCustomRM.TabIndex = 1;
          this.radNetPipeCustomRM.TabStop = true;
          this.radNetPipeCustomRM.Text = "Named Pipes (custom)";
          this.radNetPipeCustomRM.UseVisualStyleBackColor = true;
          // 
          // radNetTcpCustomRM
          // 
          this.radNetTcpCustomRM.AutoSize = true;
          this.radNetTcpCustomRM.Location = new System.Drawing.Point(17, 22);
          this.radNetTcpCustomRM.Name = "radNetTcpCustomRM";
          this.radNetTcpCustomRM.Size = new System.Drawing.Size(89, 17);
          this.radNetTcpCustomRM.TabIndex = 0;
          this.radNetTcpCustomRM.TabStop = true;
          this.radNetTcpCustomRM.Text = "TCP (custom)";
          this.radNetTcpCustomRM.UseVisualStyleBackColor = true;
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(387, 199);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.button1);
          this.Name = "Form1";
          this.Text = "Reliable Sessions";
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

       private System.Windows.Forms.Button button1;

       private System.Windows.Forms.GroupBox groupBox1;
       private System.Windows.Forms.RadioButton radNetTcpRM;
       private System.Windows.Forms.RadioButton radWSHttpRM;
       private System.Windows.Forms.RadioButton radNetPipeCustomRM;
       private System.Windows.Forms.RadioButton radNetTcpCustomRM;
       private System.Windows.Forms.RadioButton radWSHttpCustomRM;
       private System.Windows.Forms.RadioButton radWSHttpSecureRM;
   }
}

