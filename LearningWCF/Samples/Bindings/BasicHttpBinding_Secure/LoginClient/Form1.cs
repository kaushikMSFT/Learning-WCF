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

namespace LoginClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              using (localhost.HelloIndigoServiceClient proxy = new localhost.HelloIndigoServiceClient())
            {

                proxy.ClientCredentials.UserName.UserName=this.txtUsername.Text;
                proxy.ClientCredentials.UserName.Password=this.txtPassword.Text;

                string s = proxy.HelloIndigo();
                MessageBox.Show(s);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            binding.MaxBufferSize=100000;
            binding.MaxReceivedMessageSize=100000;
            binding.ReaderQuotas.MaxArrayLength=100000;
            binding.ReaderQuotas.MaxStringContentLength=100000;

            EndpointAddress address = new EndpointAddress("https://localhost/BasicHttpBinding_Secure_WebHost/Service.svc");

             using (localhost.HelloIndigoServiceClient proxy = new localhost.HelloIndigoServiceClient(binding, address))
            {

                proxy.ClientCredentials.UserName.UserName=this.txtUsername.Text;
                proxy.ClientCredentials.UserName.Password=this.txtPassword.Text;

                string s = proxy.HelloIndigo();
                MessageBox.Show(s);
            }
        }
    }
}