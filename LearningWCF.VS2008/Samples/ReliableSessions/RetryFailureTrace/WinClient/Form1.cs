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

      public Form1()
      {
         InitializeComponent();
      }

       private void button1_Click(object sender, EventArgs e)
      {
          try
          {
              using (localhost.MessagingServiceClient proxy = new WinClient.localhost.MessagingServiceClient())
              {
                  MessageBox.Show("About to establish an RM session on first call. Make sure you have started TcpTrace to listen on port 8080 and send to destination port 8000 before you close this dialog.");
                proxy.SendMessage("Message 1");

                  MessageBox.Show("About to send second message. To test RM retries, go to TcpTrace and stop the trace session, then restart it right away. To test retry failure, do not restart the trace session.");
                  proxy.SendMessage("Message 2");

                  MessageBox.Show("About to send third message.");
                  proxy.SendMessage("Message 3");

                  MessageBox.Show("About to close the proxy.");

              }
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.ToString());
          }
           
      }

      
   }
}