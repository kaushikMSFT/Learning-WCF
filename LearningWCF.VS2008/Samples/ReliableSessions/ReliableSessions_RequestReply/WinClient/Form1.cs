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

       private localhost.MessagingServiceClient GetProxy()
       {
           if (this.radNetPipeCustomRM.Checked)
               return new localhost.MessagingServiceClient("netPipeCustomRM");
           else if (this.radNetTcpCustomRM.Checked)
               return new localhost.MessagingServiceClient("netTcpCustomRM");
           else if (this.radNetTcpRM.Checked)
               return new localhost.MessagingServiceClient("netTcpRM");
           else if (this.radWSHttpCustomRM.Checked)
               return new localhost.MessagingServiceClient("wsHttpCustomRM");
           else if (this.radWSHttpRM.Checked)
               return new localhost.MessagingServiceClient("wsHttpRM");
           else if (this.radWSHttpSecureRM.Checked)
               return new localhost.MessagingServiceClient("wsHttpSecureRM");
           else
               return null;
       }

       private void button1_Click(object sender, EventArgs e)
      {
          try
          {
              using (localhost.MessagingServiceClient proxy = GetProxy())
              {
                  for (int i = 0; i < 2; i++)
                  {
                      proxy.SendMessage("Message " + i.ToString());
                  }
              }
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.StackTrace);
          }
           
      }

      
   }
}