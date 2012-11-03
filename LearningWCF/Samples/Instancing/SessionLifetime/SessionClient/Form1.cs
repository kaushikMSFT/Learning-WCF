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

namespace SessionClient
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		localhost.SessionServiceClient m_proxy = new localhost.SessionServiceClient();
		private void button1_Click(object sender, EventArgs e)
		{
				m_proxy.IncrementCounter();
		}

		private void button2_Click(object sender, EventArgs e)
		{
				string s = m_proxy.GetSessionId();
				MessageBox.Show(s);
		}

		private void button3_Click(object sender, EventArgs e)
		{
            int n = m_proxy.GetCounter();
			MessageBox.Show(n.ToString());

		}

		private void button4_Click(object sender, EventArgs e)
		{
			m_proxy = new localhost.SessionServiceClient();
		}

        private void button6_Click(object sender, EventArgs e)
        {
            m_proxy.StartSession();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            m_proxy.StopSession();
        }
	}
}