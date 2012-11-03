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

namespace InternalClient
{
    public partial class Form1 : Form
    {
        BusinessServiceContracts.IInternalServiceA proxyA;
        BusinessServiceContracts.IInternalServiceB proxyB;
        
        public Form1()
        {
            InitializeComponent();

            ChannelFactory<BusinessServiceContracts.IInternalServiceA> factoryA = new ChannelFactory<BusinessServiceContracts.IInternalServiceA>("");
            proxyA = factoryA.CreateChannel();

            ChannelFactory<BusinessServiceContracts.IInternalServiceB> factoryB = new ChannelFactory<BusinessServiceContracts.IInternalServiceB>("");
            proxyB = factoryB.CreateChannel();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = proxyA.Operation1();
            MessageBox.Show(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = proxyA.Operation2();
            MessageBox.Show(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = proxyA.Operation3();
            MessageBox.Show(s);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string s = proxyB.Operation4();
            MessageBox.Show(s);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = proxyB.Operation5();
            MessageBox.Show(s);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = proxyB.Operation6();
            MessageBox.Show(s);

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            ICommunicationObject proxyACommunication = proxyA as ICommunicationObject;
            try
            {
                if (proxyACommunication != null)
                    proxyACommunication.Close();
            }
            catch { }

            ICommunicationObject proxyBCommunication = proxyB as ICommunicationObject;
            try
            {
                if (proxyBCommunication != null)
                    proxyBCommunication.Close();
            }
            catch { }
        }
    }
}