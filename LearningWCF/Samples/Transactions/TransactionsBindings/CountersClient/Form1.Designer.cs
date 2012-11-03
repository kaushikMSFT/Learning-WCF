namespace CountersClient
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counterValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radWSHttpCustomTx = new System.Windows.Forms.RadioButton();
            this.radWSHttpTxRM = new System.Windows.Forms.RadioButton();
            this.radNetTcpTx = new System.Windows.Forms.RadioButton();
            this.radWSHttpTx = new System.Windows.Forms.RadioButton();
            this.radNetPipeTx = new System.Windows.Forms.RadioButton();
            this.radNetTcpTxRm = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(287, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCounter
            // 
            this.txtCounter.Location = new System.Drawing.Point(287, 46);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.Size = new System.Drawing.Size(48, 20);
            this.txtCounter.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Reset Counters";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.counterValueDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(253, 83);
            this.dataGridView1.TabIndex = 8;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // counterValueDataGridViewTextBoxColumn
            // 
            this.counterValueDataGridViewTextBoxColumn.DataPropertyName = "CounterValue";
            this.counterValueDataGridViewTextBoxColumn.HeaderText = "CounterValue";
            this.counterValueDataGridViewTextBoxColumn.Name = "counterValueDataGridViewTextBoxColumn";
            this.counterValueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CountersClient.localhost.CounterInfo);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radWSHttpCustomTx);
            this.groupBox1.Controls.Add(this.radWSHttpTxRM);
            this.groupBox1.Controls.Add(this.radNetTcpTx);
            this.groupBox1.Controls.Add(this.radWSHttpTx);
            this.groupBox1.Controls.Add(this.radNetPipeTx);
            this.groupBox1.Controls.Add(this.radNetTcpTxRm);
            this.groupBox1.Location = new System.Drawing.Point(17, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 174);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Binding";
            // 
            // radWSHttpCustomTx
            // 
            this.radWSHttpCustomTx.AutoSize = true;
            this.radWSHttpCustomTx.Location = new System.Drawing.Point(17, 65);
            this.radWSHttpCustomTx.Name = "radWSHttpCustomTx";
            this.radWSHttpCustomTx.Size = new System.Drawing.Size(124, 17);
            this.radWSHttpCustomTx.TabIndex = 5;
            this.radWSHttpCustomTx.Text = "WS Http Tx (custom)";
            this.radWSHttpCustomTx.UseVisualStyleBackColor = true;
            // 
            // radWSHttpTxRM
            // 
            this.radWSHttpTxRM.AutoSize = true;
            this.radWSHttpTxRM.Location = new System.Drawing.Point(17, 42);
            this.radWSHttpTxRM.Name = "radWSHttpTxRM";
            this.radWSHttpTxRM.Size = new System.Drawing.Size(101, 17);
            this.radWSHttpTxRM.TabIndex = 4;
            this.radWSHttpTxRM.Text = "WS Http Tx RM";
            this.radWSHttpTxRM.UseVisualStyleBackColor = true;
            // 
            // radNetTcpTx
            // 
            this.radNetTcpTx.AutoSize = true;
            this.radNetTcpTx.Location = new System.Drawing.Point(17, 88);
            this.radNetTcpTx.Name = "radNetTcpTx";
            this.radNetTcpTx.Size = new System.Drawing.Size(61, 17);
            this.radNetTcpTx.TabIndex = 3;
            this.radNetTcpTx.Text = "TCP Tx";
            this.radNetTcpTx.UseVisualStyleBackColor = true;
            // 
            // radWSHttpTx
            // 
            this.radWSHttpTx.AutoSize = true;
            this.radWSHttpTx.Checked = true;
            this.radWSHttpTx.Location = new System.Drawing.Point(17, 19);
            this.radWSHttpTx.Name = "radWSHttpTx";
            this.radWSHttpTx.Size = new System.Drawing.Size(81, 17);
            this.radWSHttpTx.TabIndex = 2;
            this.radWSHttpTx.TabStop = true;
            this.radWSHttpTx.Text = "WS Http Tx";
            this.radWSHttpTx.UseVisualStyleBackColor = true;
            // 
            // radNetPipeTx
            // 
            this.radNetPipeTx.AutoSize = true;
            this.radNetPipeTx.Location = new System.Drawing.Point(17, 134);
            this.radNetPipeTx.Name = "radNetPipeTx";
            this.radNetPipeTx.Size = new System.Drawing.Size(103, 17);
            this.radNetPipeTx.TabIndex = 1;
            this.radNetPipeTx.Text = "Named Pipes Tx";
            this.radNetPipeTx.UseVisualStyleBackColor = true;
            // 
            // radNetTcpTxRm
            // 
            this.radNetTcpTxRm.AutoSize = true;
            this.radNetTcpTxRm.Location = new System.Drawing.Point(17, 111);
            this.radNetTcpTxRm.Name = "radNetTcpTxRm";
            this.radNetTcpTxRm.Size = new System.Drawing.Size(81, 17);
            this.radNetTcpTxRm.TabIndex = 0;
            this.radNetTcpTxRm.Text = "TCP Tx RM";
            this.radNetTcpTxRm.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 323);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCounter);
            this.Controls.Add(this.button3);
            this.Name = "Form1";
            this.Text = "Counters Client";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCounter;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn counterValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radWSHttpCustomTx;
        private System.Windows.Forms.RadioButton radWSHttpTxRM;
        private System.Windows.Forms.RadioButton radNetTcpTx;
        private System.Windows.Forms.RadioButton radWSHttpTx;
        private System.Windows.Forms.RadioButton radNetPipeTx;
        private System.Windows.Forms.RadioButton radNetTcpTxRm;
    }
}

