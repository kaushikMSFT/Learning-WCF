// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UIService
{
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            InitializeComponent();
            this.Text += ": " + Thread.CurrentThread.ManagedThreadId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddMessage(string message)
        {

            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate 
                        {
                            this.listBox1.Items.Add(message);
                        };
                this.Invoke(del);
            }
              else
                this.listBox1.Items.Add(message);
        }


    }
}