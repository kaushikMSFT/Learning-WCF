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
using System.Transactions;

namespace CountersClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetCounters();

        }

        private void GetCounters()
        {
            using (localhost.CountersServiceClient proxy = GetProxy())
            {
                this.bindingSource1.DataSource = proxy.GetCounters();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                using (localhost.CountersServiceClient proxy = GetProxy())
                {
                    proxy.SetCounter1(int.Parse(this.txtCounter.Text));
                    proxy.SetCounter2(int.Parse(this.txtCounter.Text));

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            GetCounters();

        }

        private localhost.CountersServiceClient GetProxy()
        {
            if (this.radWSHttpTx.Checked)
                return new localhost.CountersServiceClient("wsHttpTx");
            else if (this.radWSHttpTxRM.Checked)
                return new localhost.CountersServiceClient("wsHttpTxRM");
            else if (this.radWSHttpCustomTx.Checked)
                return new localhost.CountersServiceClient("wsHttpCustomTx");
            else if (this.radNetTcpTx.Checked)
                return new localhost.CountersServiceClient("netTcpTx");
            else if (this.radNetTcpTxRm.Checked)
                return new localhost.CountersServiceClient("netTcpTxRM");
            else if (this.radNetPipeTx.Checked)
                return new localhost.CountersServiceClient("netPipeTx");
            else
                return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                using (localhost.CountersServiceClient proxy = GetProxy())
                {
                    proxy.ResetCounters();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            GetCounters();
        }
    }
}