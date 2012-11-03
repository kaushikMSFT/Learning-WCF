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

namespace MessagingClient
{
    public partial class SendMessageForm : Form
    {
        public SendMessageForm()
        {
            InitializeComponent();
        }

        localhost.MessageManagerServiceContractClient m_proxy = new MessagingClient.localhost.MessageManagerServiceContractClient();

        private void cmdSend_Click(object sender, EventArgs e)
        {

            try
            {
                this.txtResponse.Text = m_proxy.SendMessage(this.txtMessage.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}