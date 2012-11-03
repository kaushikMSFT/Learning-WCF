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

namespace Client
{
    public partial class Form1 : Form
    {
        localhost.HelloIndigoServiceClient m_proxy;

        public Form1()
        {
            InitializeComponent();
            this.Text += ": " + Thread.CurrentThread.ManagedThreadId;
            m_proxy = new localhost.HelloIndigoServiceClient();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NOTE: anonymous method syntax
            //Thread t = new Thread(delegate()
            //    {
            //        m_proxy.HelloIndigo(String.Format("{0} on thread {1}", this.Text, Thread.CurrentThread.ManagedThreadId));
            //    });

            //NOTE: lambda expression syntax
            Thread t = new Thread(
                ()=>m_proxy.HelloIndigo(String.Format("{0} on thread {1}", this.Text, Thread.CurrentThread.ManagedThreadId))
                    );

            t.Start();

        }
    }
}