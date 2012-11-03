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
using WinClient.localhost;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace WinClient
{
    [CallbackBehavior(UseSynchronizationContext=false)]
    public partial class Form1 : Form, IHelloIndigoServiceCallback
    {
        private InstanceContext m_callbackInstance = null;
        private localhost.HelloIndigoServiceClient m_proxy = null;

        public Form1()
        {
            InitializeComponent();

            this.Text = String.Format("WinClient: Thread {0}", Thread.CurrentThread.GetHashCode());
            m_callbackInstance = new InstanceContext(this);
        }
         
        private void cmdInvoke_Click(object sender, EventArgs e)
        {
            InitializeProxy();            
            m_proxy.HelloIndigo(String.Format("Hello from WinClient over {0}", m_proxy.Endpoint.Binding.GetType()));
        }

        private void InitializeProxy()
        {
            if (this.rbTcpBinding.Checked)
            {
                m_proxy = new localhost.HelloIndigoServiceClient(m_callbackInstance,"NetTcpBinding_IHelloIndigoService");
            }
            else if (this.rbNamedPipesBinding.Checked)
            {
                m_proxy = new localhost.HelloIndigoServiceClient(m_callbackInstance,"NetNamedPipeBinding_IHelloIndigoService");
            }
            else if (this.rbHttpBinding.Checked)
            {
                m_proxy = new localhost.HelloIndigoServiceClient(m_callbackInstance,"WSDualHttpBinding_IHelloIndigoService");
                
                WSDualHttpBinding binding = m_proxy.Endpoint.Binding as WSDualHttpBinding;
                binding.ClientBaseAddress = new Uri("http://localhost:8100");
            }
            else 
            {
                m_proxy = new localhost.HelloIndigoServiceClient(m_callbackInstance,"CustomBinding_IHelloIndigoService");

                WSDualHttpBinding binding = m_proxy.Endpoint.Binding as WSDualHttpBinding;
                binding.ClientBaseAddress = new Uri("http://localhost:8100");
                
            }
        }



        #region IHelloIndigoServiceCallback Members


        public void HelloIndigoCallback(string message)
        {
            MessageBox.Show(string.Format("One-way callback received on thread {0}. Message: {1}", System.Threading.Thread.CurrentThread.GetHashCode(), message));
        }

        public void HelloIndigoCallback2(string message)
        {
            MessageBox.Show(string.Format("Request-Reply callback received on thread {0}. Message: {1}", System.Threading.Thread.CurrentThread.GetHashCode(), message));
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeProxy();            
            m_proxy.HelloIndigo2(String.Format("Hello from WinClient over {0}", m_proxy.Endpoint.Binding.GetType()));

        }
    }
}