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
using System.ServiceModel;
using System.Diagnostics;

namespace Client
{
    public partial class Form1 : Form
    {
        localhost.MessagingServiceClient m_proxy;

        public Form1()
        {
            InitializeComponent();
            this.Text += ": Process " + Process.GetCurrentProcess().Id.ToString();

            m_proxy = new localhost.MessagingServiceClient();
            ICommunicationObject obj = m_proxy as ICommunicationObject;
            obj.Faulted +=new EventHandler(obj_Faulted);
        }

        void obj_Faulted(object sender, EventArgs e)
        {
            MessageBox.Show("Communication channel has faulted. Creating a new proxy instance.");
            m_proxy = new localhost.MessagingServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MethodInvoker m = new MethodInvoker(CallService);
            m.BeginInvoke(null, null);
        }

        private void CallService()
        {
            lock(m_proxy)
            {
                try
                {
                    m_proxy.SendMessage(String.Format("Hello from {0}", this.Text));
                }
                catch{}
            }
        }
    }
}