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

namespace WinClient
{


   public partial class Form1 : Form
   {

       localhost.CounterServicePerCallClient m_proxyPerCallBasicHttp = new WinClient.localhost.CounterServicePerCallClient("BasicHttpBinding_ICounterServicePerCall");
       localhost.CounterServicePerCallClient m_proxyPerCallWSHttpNoSession = new WinClient.localhost.CounterServicePerCallClient("WSHttpBinding_ICounterServicePerCall");
       localhost.CounterServicePerCallClient m_proxyPerCallWSHttpSecureSession = new WinClient.localhost.CounterServicePerCallClient("WSHttpBinding_ICounterServicePerCall1"); 
       localhost.CounterServicePerCallClient m_proxyPerCallWSHttpReliableSession = new WinClient.localhost.CounterServicePerCallClient("WSHttpBinding_ICounterServicePerCall2");

       localhost.CounterServicePerCallClient m_proxyPerCallNetPipe = new WinClient.localhost.CounterServicePerCallClient("NetNamedPipeBinding_ICounterServicePerCall");
       localhost.CounterServicePerCallClient m_proxyPerCallNetTcp = new WinClient.localhost.CounterServicePerCallClient("NetTcpBinding_ICounterServicePerCall");

       localhost1.CounterServiceSessionClient m_proxySessionWSHttpSecureSession = new WinClient.localhost1.CounterServiceSessionClient("WSHttpBinding_ICounterServiceSession");
       localhost1.CounterServiceSessionClient m_proxySessionWSHttpReliableSession = new WinClient.localhost1.CounterServiceSessionClient("WSHttpBinding_ICounterServiceSession1");

       localhost1.CounterServiceSessionClient m_proxySessionNetPipe = new WinClient.localhost1.CounterServiceSessionClient("NetNamedPipeBinding_ICounterServiceSession");
       localhost1.CounterServiceSessionClient m_proxySessionNetTcp = new WinClient.localhost1.CounterServiceSessionClient("NetTcpBinding_ICounterServiceSession");

       localhost2.CounterServiceSingleClient m_proxySingleBasicHttp = new WinClient.localhost2.CounterServiceSingleClient("BasicHttpBinding_ICounterServiceSingle");
       localhost2.CounterServiceSingleClient m_proxySingleWSHttpNoSession = new WinClient.localhost2.CounterServiceSingleClient("WSHttpBinding_ICounterServiceSingle");
       localhost2.CounterServiceSingleClient m_proxySingleWSHttpSecureSession = new WinClient.localhost2.CounterServiceSingleClient("WSHttpBinding_ICounterServiceSingle1");
       localhost2.CounterServiceSingleClient m_proxySingleWSHttpReliableSession = new WinClient.localhost2.CounterServiceSingleClient("WSHttpBinding_ICounterServiceSingle2");

       localhost2.CounterServiceSingleClient m_proxySingleNetPipe = new WinClient.localhost2.CounterServiceSingleClient("NetNamedPipeBinding_ICounterServiceSingle");
       localhost2.CounterServiceSingleClient m_proxySingleNetTcp = new WinClient.localhost2.CounterServiceSingleClient("NetTcpBinding_ICounterServiceSingle");

      public Form1()
      {
         InitializeComponent();


          

      }

       private localhost.CounterServicePerCallClient GetPerCallProxy()
       {
           if (radBasicHttp.Checked)
               return this.m_proxyPerCallBasicHttp;
           else if (radWSHttpNoSession.Checked)
               return this.m_proxyPerCallWSHttpNoSession;
           else if (radWSHttpSecureSession.Checked)
               return this.m_proxyPerCallWSHttpSecureSession;
           else if (radWSHttpReliableSession.Checked)
               return this.m_proxyPerCallWSHttpReliableSession;
           else if (radNetPipe.Checked)
               return this.m_proxyPerCallNetPipe;
           else
               return this.m_proxyPerCallNetTcp;
       }

       private localhost1.CounterServiceSessionClient GetSessionProxy()
       {
           if (radWSHttpSecureSession.Checked)
               return this.m_proxySessionWSHttpSecureSession;
           else if (radWSHttpReliableSession.Checked)
               return this.m_proxySessionWSHttpReliableSession;
           else if (radNetPipe.Checked)
               return this.m_proxySessionNetPipe;
           else
               return this.m_proxySessionNetTcp;
       }

       private localhost2.CounterServiceSingleClient GetSingleProxy()
       {
           if (radBasicHttp.Checked)
               return this.m_proxySingleBasicHttp;
           else if (radWSHttpNoSession.Checked)
               return this.m_proxySingleWSHttpNoSession;
           else if (radWSHttpSecureSession.Checked)
               return this.m_proxySingleWSHttpSecureSession;
           else if (radWSHttpReliableSession.Checked)
               return this.m_proxySingleWSHttpReliableSession;
           else if (radNetPipe.Checked)
               return this.m_proxySingleNetPipe;
           else
               return this.m_proxySingleNetTcp;
       }

       private void button1_Click(object sender, EventArgs e)
      {

           GetPerCallProxy().IncrementCounter();
           GetPerCallProxy().IncrementCounter();
      }

      private void button2_Click(object sender, EventArgs e)
      {
          if (radBasicHttp.Checked || radWSHttpNoSession.Checked)
          {
              MessageBox.Show("This endpoint requires a binding that supports sessions.");
              return;
          }
                   

          GetSessionProxy().IncrementCounter();
          GetSessionProxy().IncrementCounter();

      }

      private void button3_Click(object sender, EventArgs e)
      {

          GetSingleProxy().IncrementCounter();
          GetSingleProxy().IncrementCounter();
      }
   }
}