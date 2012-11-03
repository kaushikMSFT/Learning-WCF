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
using HelloIndigo;
using System.Diagnostics;

namespace InProcClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text += ":" + Process.GetCurrentProcess().Id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = this.MyProxy.HelloIndigo(String.Format("Hello from client process: {0}", Process.GetCurrentProcess().Id));        
            MessageBox.Show(s);
        }

        private IHelloIndigoService m_proxy;
        private IHelloIndigoService MyProxy
        {
            get
            {
                if (m_proxy ==null)
                {
                    ChannelFactory<IHelloIndigoService> factory = new ChannelFactory<IHelloIndigoService>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/HelloIndigoService"));
                    m_proxy = factory.CreateChannel();
                }
                return m_proxy;
            }
        }

    }
}