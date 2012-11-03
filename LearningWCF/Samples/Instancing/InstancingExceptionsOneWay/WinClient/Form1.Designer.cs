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
          this.button2 = new System.Windows.Forms.Button();
          this.button3 = new System.Windows.Forms.Button();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.radWSHttpSecureSession = new System.Windows.Forms.RadioButton();
          this.radWSHttpReliableSession = new System.Windows.Forms.RadioButton();
          this.radNetTcp = new System.Windows.Forms.RadioButton();
          this.radNetPipe = new System.Windows.Forms.RadioButton();
          this.radWSHttpNoSession = new System.Windows.Forms.RadioButton();
          this.radBasicHttp = new System.Windows.Forms.RadioButton();
          this.button4 = new System.Windows.Forms.Button();
          this.button5 = new System.Windows.Forms.Button();
          this.button6 = new System.Windows.Forms.Button();
          this.button7 = new System.Windows.Forms.Button();
          this.button8 = new System.Windows.Forms.Button();
          this.button9 = new System.Windows.Forms.Button();
          this.groupBox1.SuspendLayout();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(267, 75);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 0;
          this.button1.Text = "PerCall";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // button2
          // 
          this.button2.Location = new System.Drawing.Point(358, 75);
          this.button2.Name = "button2";
          this.button2.Size = new System.Drawing.Size(75, 23);
          this.button2.TabIndex = 1;
          this.button2.Text = "Session";
          this.button2.UseVisualStyleBackColor = true;
          this.button2.Click += new System.EventHandler(this.button2_Click);
          // 
          // button3
          // 
          this.button3.Location = new System.Drawing.Point(449, 75);
          this.button3.Name = "button3";
          this.button3.Size = new System.Drawing.Size(75, 23);
          this.button3.TabIndex = 2;
          this.button3.Text = "Single";
          this.button3.UseVisualStyleBackColor = true;
          this.button3.Click += new System.EventHandler(this.button3_Click);
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.radWSHttpSecureSession);
          this.groupBox1.Controls.Add(this.radWSHttpReliableSession);
          this.groupBox1.Controls.Add(this.radNetTcp);
          this.groupBox1.Controls.Add(this.radNetPipe);
          this.groupBox1.Controls.Add(this.radWSHttpNoSession);
          this.groupBox1.Controls.Add(this.radBasicHttp);
          this.groupBox1.Location = new System.Drawing.Point(13, 13);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(248, 174);
          this.groupBox1.TabIndex = 3;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Binding";
          // 
          // radWSHttpSecureSession
          // 
          this.radWSHttpSecureSession.AutoSize = true;
          this.radWSHttpSecureSession.Location = new System.Drawing.Point(17, 68);
          this.radWSHttpSecureSession.Name = "radWSHttpSecureSession";
          this.radWSHttpSecureSession.Size = new System.Drawing.Size(181, 17);
          this.radWSHttpSecureSession.TabIndex = 5;
          this.radWSHttpSecureSession.TabStop = true;
          this.radWSHttpSecureSession.Text = "WSHttpBinding (Secure Session)";
          this.radWSHttpSecureSession.UseVisualStyleBackColor = true;
          // 
          // radWSHttpReliableSession
          // 
          this.radWSHttpReliableSession.AutoSize = true;
          this.radWSHttpReliableSession.Location = new System.Drawing.Point(17, 91);
          this.radWSHttpReliableSession.Name = "radWSHttpReliableSession";
          this.radWSHttpReliableSession.Size = new System.Drawing.Size(185, 17);
          this.radWSHttpReliableSession.TabIndex = 4;
          this.radWSHttpReliableSession.TabStop = true;
          this.radWSHttpReliableSession.Text = "WSHttpBinding (Reliable Session)";
          this.radWSHttpReliableSession.UseVisualStyleBackColor = true;
          // 
          // radNetTcp
          // 
          this.radNetTcp.AutoSize = true;
          this.radNetTcp.Location = new System.Drawing.Point(17, 137);
          this.radNetTcp.Name = "radNetTcp";
          this.radNetTcp.Size = new System.Drawing.Size(96, 17);
          this.radNetTcp.TabIndex = 3;
          this.radNetTcp.TabStop = true;
          this.radNetTcp.Text = "NetTcpBinding";
          this.radNetTcp.UseVisualStyleBackColor = true;
          // 
          // radNetPipe
          // 
          this.radNetPipe.AutoSize = true;
          this.radNetPipe.Location = new System.Drawing.Point(17, 114);
          this.radNetPipe.Name = "radNetPipe";
          this.radNetPipe.Size = new System.Drawing.Size(132, 17);
          this.radNetPipe.TabIndex = 2;
          this.radNetPipe.TabStop = true;
          this.radNetPipe.Text = "NetNamedPipeBinding";
          this.radNetPipe.UseVisualStyleBackColor = true;
          // 
          // radWSHttpNoSession
          // 
          this.radWSHttpNoSession.AutoSize = true;
          this.radWSHttpNoSession.Location = new System.Drawing.Point(17, 45);
          this.radWSHttpNoSession.Name = "radWSHttpNoSession";
          this.radWSHttpNoSession.Size = new System.Drawing.Size(161, 17);
          this.radWSHttpNoSession.TabIndex = 1;
          this.radWSHttpNoSession.TabStop = true;
          this.radWSHttpNoSession.Text = "WSHttpBinding (No Session)";
          this.radWSHttpNoSession.UseVisualStyleBackColor = true;
          // 
          // radBasicHttp
          // 
          this.radBasicHttp.AutoSize = true;
          this.radBasicHttp.Location = new System.Drawing.Point(17, 22);
          this.radBasicHttp.Name = "radBasicHttp";
          this.radBasicHttp.Size = new System.Drawing.Size(106, 17);
          this.radBasicHttp.TabIndex = 0;
          this.radBasicHttp.TabStop = true;
          this.radBasicHttp.Text = "BasicHttpBinding";
          this.radBasicHttp.UseVisualStyleBackColor = true;
          // 
          // button4
          // 
          this.button4.Location = new System.Drawing.Point(267, 46);
          this.button4.Name = "button4";
          this.button4.Size = new System.Drawing.Size(75, 23);
          this.button4.TabIndex = 4;
          this.button4.Text = "New Proxy";
          this.button4.UseVisualStyleBackColor = true;
          this.button4.Click += new System.EventHandler(this.button4_Click);
          // 
          // button5
          // 
          this.button5.Location = new System.Drawing.Point(358, 46);
          this.button5.Name = "button5";
          this.button5.Size = new System.Drawing.Size(75, 23);
          this.button5.TabIndex = 5;
          this.button5.Text = "New Proxy";
          this.button5.UseVisualStyleBackColor = true;
          this.button5.Click += new System.EventHandler(this.button5_Click);
          // 
          // button6
          // 
          this.button6.Location = new System.Drawing.Point(449, 46);
          this.button6.Name = "button6";
          this.button6.Size = new System.Drawing.Size(75, 23);
          this.button6.TabIndex = 6;
          this.button6.Text = "New Proxy";
          this.button6.UseVisualStyleBackColor = true;
          this.button6.Click += new System.EventHandler(this.button6_Click);
          // 
          // button7
          // 
          this.button7.Location = new System.Drawing.Point(267, 104);
          this.button7.Name = "button7";
          this.button7.Size = new System.Drawing.Size(75, 23);
          this.button7.TabIndex = 7;
          this.button7.Text = "Exception";
          this.button7.UseVisualStyleBackColor = true;
          this.button7.Click += new System.EventHandler(this.button7_Click);
          // 
          // button8
          // 
          this.button8.Location = new System.Drawing.Point(358, 104);
          this.button8.Name = "button8";
          this.button8.Size = new System.Drawing.Size(75, 23);
          this.button8.TabIndex = 8;
          this.button8.Text = "Exception";
          this.button8.UseVisualStyleBackColor = true;
          this.button8.Click += new System.EventHandler(this.button8_Click);
          // 
          // button9
          // 
          this.button9.Location = new System.Drawing.Point(449, 104);
          this.button9.Name = "button9";
          this.button9.Size = new System.Drawing.Size(75, 23);
          this.button9.TabIndex = 9;
          this.button9.Text = "Exception";
          this.button9.UseVisualStyleBackColor = true;
          this.button9.Click += new System.EventHandler(this.button9_Click);
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(530, 199);
          this.Controls.Add(this.button9);
          this.Controls.Add(this.button8);
          this.Controls.Add(this.button7);
          this.Controls.Add(this.button6);
          this.Controls.Add(this.button5);
          this.Controls.Add(this.button4);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.button3);
          this.Controls.Add(this.button2);
          this.Controls.Add(this.button1);
          this.Name = "Form1";
          this.Text = "Instancing";
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
       private System.Windows.Forms.GroupBox groupBox1;
       private System.Windows.Forms.RadioButton radNetTcp;
       private System.Windows.Forms.RadioButton radNetPipe;
       private System.Windows.Forms.RadioButton radWSHttpNoSession;
       private System.Windows.Forms.RadioButton radBasicHttp;
       private System.Windows.Forms.RadioButton radWSHttpSecureSession;
       private System.Windows.Forms.RadioButton radWSHttpReliableSession;
       private System.Windows.Forms.Button button4;
       private System.Windows.Forms.Button button5;
       private System.Windows.Forms.Button button6;
       private System.Windows.Forms.Button button7;
       private System.Windows.Forms.Button button8;
       private System.Windows.Forms.Button button9;
   }
}

