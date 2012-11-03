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

       localhost.CounterServicePerCallClient m_proxyPerCall = new WinClient.localhost.CounterServicePerCallClient();
       localhost1.CounterServiceSessionClient m_proxySession = new WinClient.localhost1.CounterServiceSessionClient();
       localhost2.CounterServiceSingleClient m_proxySingle = new WinClient.localhost2.CounterServiceSingleClient();

      public Form1()
      {
         InitializeComponent();
      }


       private void button1_Click(object sender, EventArgs e)
      {
          m_proxyPerCall.IncrementCounter();
      }

      private void button2_Click(object sender, EventArgs e)
      {
          m_proxySession.IncrementCounter();
      }

      private void button3_Click(object sender, EventArgs e)
      {
          m_proxySingle.IncrementCounter();
      }
   }
}