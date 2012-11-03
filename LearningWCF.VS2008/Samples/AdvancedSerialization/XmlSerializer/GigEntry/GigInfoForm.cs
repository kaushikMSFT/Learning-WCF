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


namespace GigEntry
{
    public partial class GigInfoForm : Form
    {
        public GigInfoForm()
        {
            InitializeComponent();
        }

        // Proxy generated with the following command:
        // Svcutil.exe /o:serviceproxy.cs /config:app.config /serializer:XmlSerializer http://localhost:8000
        GigManagerServiceContractClient m_proxy = new GigManagerServiceContractClient();

        private void cmdSave_Click(object sender, EventArgs e)
        {
            LinkItem item = new LinkItem();

            item.Id = int.Parse(this.txtId.Text);
            item.Title = this.txtTitle.Text;
            item.Description = this.txtDescription.Text;
            item.DateStart = this.dtpStart.Value;
            item.DateEnd = this.dtpEnd.Value;
            item.Url = this.txtUrl.Text;

            m_proxy.SaveGig(item);
        }


        private void cmdGet_Click(object sender, EventArgs e)
        {
            LinkItem item = m_proxy.GetGig();
            if (item != null)
            {
                this.txtId.Text = item.Id.ToString();
                this.txtTitle.Text = item.Title;
                this.txtDescription.Text = item.Description;

                if (Convert.ToDateTime(item.DateStart) != DateTime.MinValue)
                    this.dtpStart.Value = item.DateStart;
                if (Convert.ToDateTime(item.DateEnd) != DateTime.MinValue)
                    this.dtpEnd.Value = item.DateEnd;

                this.txtUrl.Text = item.Url;
            }

        }
    }
}

