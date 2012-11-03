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
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Security;

namespace WinClient
{
    public partial class Form1 : Form
    {
        string m_username;
        string m_password;

        localhost.SecureServiceContractClient m_proxySoap11UserNameSSL;
        localhost.SecureServiceContractClient m_proxySoap12UserNameSSL;
        localhost.SecureServiceContractClient m_proxySoap12UserNameOneShot;
        localhost.SecureServiceContractClient m_proxySoap12UserNameSecureSession;
        localhost.SecureServiceContractClient m_proxySoap12UserNameSecureReliableSession;

        public Form1()
        {
            Thread.GetDomain().SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
            
            InitializeComponent();
            InitializeProxy();
        }

        private void InitializeProxy()
        {
            this.m_proxySoap11UserNameSSL = new WinClient.localhost.SecureServiceContractClient("Soap11UserNameSSL");
            this.m_proxySoap12UserNameSSL= new WinClient.localhost.SecureServiceContractClient("Soap12UserNameSSL");
            this.m_proxySoap12UserNameOneShot= new WinClient.localhost.SecureServiceContractClient("Soap12UserNameOneShot");
            this.m_proxySoap12UserNameSecureSession= new WinClient.localhost.SecureServiceContractClient("Soap12UserNameSecureSession");
            this.m_proxySoap12UserNameSecureReliableSession= new WinClient.localhost.SecureServiceContractClient("Soap12UserNameSecureReliableSession");

            if (!(String.IsNullOrEmpty(m_username) || String.IsNullOrEmpty(this.m_password)))
            {
                this.m_proxySoap11UserNameSSL.ClientCredentials.UserName.UserName = this.m_username;
                this.m_proxySoap11UserNameSSL.ClientCredentials.UserName.Password = this.m_password;


                this.m_proxySoap12UserNameSSL.ClientCredentials.UserName.UserName = this.m_username;
                this.m_proxySoap12UserNameSSL.ClientCredentials.UserName.Password = this.m_password;

                this.m_proxySoap12UserNameOneShot.ClientCredentials.UserName.UserName = this.m_username;
                this.m_proxySoap12UserNameOneShot.ClientCredentials.UserName.Password = this.m_password;

                this.m_proxySoap12UserNameSecureSession.ClientCredentials.UserName.UserName = this.m_username;
                this.m_proxySoap12UserNameSecureSession.ClientCredentials.UserName.Password = this.m_password;

                this.m_proxySoap12UserNameSecureReliableSession.ClientCredentials.UserName.UserName = this.m_username;
                this.m_proxySoap12UserNameSecureReliableSession.ClientCredentials.UserName.Password = this.m_password;
            }

        }

        private void cmdAdminOp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(GetProxy().AdminOperation());
            }
            catch (FaultException faultEx)
            {
                MessageBox.Show(faultEx.Message);
                InitializeProxy();
            }
            catch (CommunicationException comEx)
            {
                MessageBox.Show(comEx.Message);
                InitializeProxy();
            }
        }

        private localhost.SecureServiceContractClient GetProxy()
        {
            if (this.radSoap11UserNameSSL.Checked)
                return this.m_proxySoap11UserNameSSL;
            else if (this.radSoap12UserNameSSL.Checked)
                return this.m_proxySoap12UserNameSSL;
            else if (this.radSoap12UserNameOneShot.Checked)
                return this.m_proxySoap12UserNameOneShot;
            else if (this.radSoap12UserNameSecureSession.Checked)
                return this.m_proxySoap12UserNameSecureSession;
            else if (this.radSoap12UserNameSecureReliableSession.Checked)
                return this.m_proxySoap12UserNameSecureReliableSession;
            else
                return null;
        }

        private void cmdUserOp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(GetProxy().UserOperation());
            }
            catch (CommunicationException comEx)
            {
                MessageBox.Show(comEx.Message);
                InitializeProxy();
            }

        }

        private void cmdGuestOp_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show(GetProxy().GuestOperation());
            }
            catch (CommunicationException comEx)
            {

                MessageBox.Show(comEx.Message);
                InitializeProxy();

            }

        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {

            SecurityUtility.LoginForm f = new SecurityUtility.LoginForm();
            f.ShowDomain = false;

			DialogResult res = f.ShowDialog();
			if (res == DialogResult.OK)
			{

                try
                {
                    this.m_username = f.Username;
                    this.m_password = f.Password;

                    InitializeProxy();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

			}

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}