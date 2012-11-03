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

namespace WinClientV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (localhost.ServiceAContract2Client proxy = new WinClientV2.localhost.ServiceAContract2Client())
            {
                string s = proxy.Operation1();
                MessageBox.Show(s);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (localhost.ServiceAContract2Client proxy = new WinClientV2.localhost.ServiceAContract2Client())
            {
                string s = proxy.Operation2();
                MessageBox.Show(s);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (localhost.ServiceAContract2Client proxy = new WinClientV2.localhost.ServiceAContract2Client())
            {
                string s = proxy.Operation3();
                MessageBox.Show(s);
            }

        }
    }
}