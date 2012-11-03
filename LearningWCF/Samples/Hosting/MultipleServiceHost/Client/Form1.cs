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
using System.ServiceModel;


namespace Client
{
    public partial class Form1 : Form
    {
        Client.ServiceA.ServiceAClient m_proxyA;
        Client.ServiceB.ServiceBClient m_proxyB;
        
        public Form1()
        {
            InitializeComponent();

            m_proxyA = new Client.ServiceA.ServiceAClient();
            m_proxyB = new Client.ServiceB.ServiceBClient();

        }



        private void button6_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation2();
            MessageBox.Show(s);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = m_proxyA.Operation1();
            MessageBox.Show(s);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string s = m_proxyB.Operation3();
            MessageBox.Show(s);

        }

    }
}