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
using System.Security.Principal;
using System.ServiceModel.Security;
using System.Net;

namespace WinClient
{
    public partial class Form1 : Form
    {
        NetworkCredential m_creds;
        localhost.ImpersonationServiceClient m_proxy;

        public Form1()
        {
            InitializeComponent();

            // TODO: enter some valid windows credentials here
            m_creds = new NetworkCredential("TestUser", "testuser");
        }

        private TokenImpersonationLevel GetImpersonationLevel()
        {
            if (this.radAnonymous.Checked)
                return TokenImpersonationLevel.Anonymous;
            else if (this.radIdentification.Checked)
                return TokenImpersonationLevel.Identification;
            else if (this.radImpersonation.Checked)
                return TokenImpersonationLevel.Impersonation;
            else if (this.radDelegation.Checked)
                return TokenImpersonationLevel.Delegation;
            else 
                return TokenImpersonationLevel.None;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                m_proxy = new localhost.ImpersonationServiceClient();
                m_proxy.ClientCredentials.Windows.ClientCredential = m_creds;
                m_proxy.ClientCredentials.Windows.AllowedImpersonationLevel = GetImpersonationLevel();
                m_proxy.ImpersonationNotAllowed();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                m_proxy = new localhost.ImpersonationServiceClient();
                m_proxy.ClientCredentials.Windows.ClientCredential = m_creds;
                m_proxy.ClientCredentials.Windows.AllowedImpersonationLevel = GetImpersonationLevel();
                m_proxy.ImpersonationAllowed();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                m_proxy = new localhost.ImpersonationServiceClient();
                m_proxy.ClientCredentials.Windows.ClientCredential = m_creds;
                m_proxy.ClientCredentials.Windows.AllowedImpersonationLevel = GetImpersonationLevel();
                m_proxy.ImpersonationRequired();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        
        }

    }
}