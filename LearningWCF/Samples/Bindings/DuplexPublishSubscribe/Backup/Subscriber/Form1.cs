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
using Subscriber.localhost;
using System.ServiceModel;
using System.Threading;

namespace Subscriber
{
    public partial class Form1 : Form, IPublisherServiceCallback
    {
        
        private localhost.PublisherServiceClient m_proxy = null;

        public Form1()
        {
            InitializeComponent();

            InstanceContext callbackInstance = new InstanceContext(this);
            m_proxy = new localhost.PublisherServiceClient(callbackInstance);

            this.Text = string.Format("Subscriber: Thread {0}", Thread.CurrentThread.GetHashCode());
        }

        private Guid m_myGuid = Guid.NewGuid();

        private void cmdSubscribe_Click(object sender, EventArgs e)
        {
            m_proxy.Subscribe(this.m_myGuid);
        }


        #region IPublisherServiceCallback Members

        public void Notify()
        {
            MessageBox.Show(String.Format("Received notification on thread {0}", Thread.CurrentThread.GetHashCode()));
        }

        #endregion

        private void cmdUnsubscribe_Click(object sender, EventArgs e)
        {
            m_proxy.Unsubscribe(this.m_myGuid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}