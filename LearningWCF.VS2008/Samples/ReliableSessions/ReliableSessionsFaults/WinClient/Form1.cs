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
using System.Diagnostics;

namespace WinClient
{


   public partial class Form1 : Form
   {

      public Form1()
      {
         InitializeComponent();
      }

       private localhost.CounterServiceClient GetProxy()
       {
           if (radWSHttpSecureSession.Checked)
               return new localhost.CounterServiceClient("wsHttpSecureRM");
           else if (radWSHttpReliableSession.Checked)
               return new localhost.CounterServiceClient("wsHttpRM");
           else
               return new WinClient.localhost.CounterServiceClient("netTcpRM");
       }

       private void button1_Click(object sender, EventArgs e)
       {
           localhost.CounterServiceClient proxy = GetProxy();
           proxy.IncrementCounter();
           proxy.IncrementCounter();
       }

       private void button2_Click(object sender, EventArgs e)
       {
           localhost.CounterServiceClient proxy = GetProxy();
           try
           {
               proxy.IncrementCounter();
               proxy.ThrowException();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           try
           {
               proxy.IncrementCounter();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           try
           {
               proxy.Close();
           }
           catch {}


       }

       private void button3_Click(object sender, EventArgs e)
       {
           localhost.CounterServiceClient proxy = GetProxy();
           try
           {
               proxy.IncrementCounter();
               proxy.ThrowFault();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           try
           {
               proxy.IncrementCounter();
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.ToString());
           }

           try
           {
               proxy.Close();
           }
           catch { }

       }


   }
}