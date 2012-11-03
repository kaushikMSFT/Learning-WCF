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

namespace ExternalClient
{
    public partial class Form1 : Form
    {
        BusinessServiceContracts.IServiceA proxyA;
        BusinessServiceContracts.IServiceB proxyB;

        public Form1()
        {
            InitializeComponent();

            ChannelFactory<BusinessServiceContracts.IServiceA> factoryA = new ChannelFactory<BusinessServiceContracts.IServiceA>("");
            proxyA = factoryA.CreateChannel();

            ChannelFactory<BusinessServiceContracts.IServiceB> factoryB = new ChannelFactory<BusinessServiceContracts.IServiceB>("");
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
            string s = proxyB.Operation4();
            MessageBox.Show(s);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            ICommunicationObject proxyACommunication = proxyA as ICommunicationObject;
            if (proxyACommunication != null)
                proxyACommunication.Close();

            ICommunicationObject proxyBCommunication = proxyB as ICommunicationObject;
            if (proxyBCommunication != null)
                proxyBCommunication.Close();
        }

    }
}