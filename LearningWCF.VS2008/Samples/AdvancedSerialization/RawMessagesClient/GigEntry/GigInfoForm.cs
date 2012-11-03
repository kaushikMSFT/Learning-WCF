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
using ContentTypes;
using System.ServiceModel.Channels;


namespace GigEntry
{
    public partial class GigInfoForm : Form
    {
        IGigManagerService m_proxy;

        public GigInfoForm()
        {
            InitializeComponent();

            ChannelFactory<IGigManagerService> factory = new ChannelFactory<IGigManagerService>("");
            m_proxy = factory.CreateChannel();
            
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            LinkItem item = new LinkItem();

            item.Id = int.Parse(this.txtId.Text);
            item.Title = this.txtTitle.Text;
            item.Description = this.txtDescription.Text;
            item.DateStart = this.dtpStart.Value;
            item.DateEnd = this.dtpEnd.Value;
            item.Url = this.txtUrl.Text;

            System.ServiceModel.Channels.Message requestMessage = new SaveGigRequest(item, MessageVersion.Soap12WSAddressing10);
            m_proxy.SaveGig(requestMessage);
        }


        private void cmdGet_Click(object sender, EventArgs e)
        {
            System.ServiceModel.Channels.Message requestMessage = System.ServiceModel.Channels.Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/GetGig");

            requestMessage.Headers.Action = "http://www.thatindigogirl.com/samples/2006/06/GigManagerServiceContract/GetGig";

            LicenseKeyHeader licenseKeyHeader = new LicenseKeyHeader("XXX");
            requestMessage.Headers.Add(licenseKeyHeader);

            GetGigResponse responseMessage = new GetGigResponse(m_proxy.GetGig(requestMessage));

            LinkItem item = responseMessage.Item;

            if (item != null)
            {
                this.txtId.Text = item.Id.ToString();
                this.txtTitle.Text = item.Title;
                this.txtDescription.Text = item.Description;

                if (item.DateStart != DateTime.MinValue)
                    this.dtpStart.Value = item.DateStart;
                if (item.DateEnd != DateTime.MinValue)
                    this.dtpEnd.Value = item.DateEnd;

                this.txtUrl.Text = item.Url;
            }

        }
    }
}

