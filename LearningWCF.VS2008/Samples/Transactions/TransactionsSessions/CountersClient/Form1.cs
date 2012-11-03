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
            using (localhost.CountersServiceClient proxy = new CountersClient.localhost.CountersServiceClient())
            {
                this.bindingSource1.DataSource = proxy.GetCounters();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    using (localhost.CountersServiceClient proxy = new CountersClient.localhost.CountersServiceClient())
                    {
                        proxy.SetCounter1(int.Parse(this.txtCounter.Text));
                        proxy.SetCounter2(int.Parse(this.txtCounter.Text));
                    }

                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            GetCounters();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (localhost.CountersServiceClient proxy = new CountersClient.localhost.CountersServiceClient())
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