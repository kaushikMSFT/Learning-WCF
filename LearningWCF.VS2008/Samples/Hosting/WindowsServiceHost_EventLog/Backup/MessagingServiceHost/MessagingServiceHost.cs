// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace MessagingServiceHost
{
    public partial class MessagingServiceHost : ServiceBase
    {
        ServiceHost m_serviceHost;

        public MessagingServiceHost()
        {
            InitializeComponent();
            this.ServiceName = "MessagingServiceHost_EventLog";
        }
         
        protected override void OnStart(string[] args)
        {
            m_serviceHost = new ServiceHost(typeof(Messaging.MessagingService));
            m_serviceHost.Faulted += new EventHandler(m_serviceHost_Faulted);
            m_serviceHost.Open();

            string baseAddresses = "";
            foreach (Uri address in m_serviceHost.BaseAddresses)
            {
                baseAddresses += " " + address.AbsoluteUri;
            }
            string s = String.Format("{0} listening at {1}", this.ServiceName, baseAddresses);
            this.EventLog.WriteEntry(s, EventLogEntryType.Information);

        }

        void m_serviceHost_Faulted(object sender, EventArgs e)
        {
            string s = String.Format("{0} has faulted, notify administrators of this problem", this.ServiceName);
            this.EventLog.WriteEntry(s, EventLogEntryType.Error);
        }

        protected override void OnStop()
        {
            if (m_serviceHost != null)
            {
                m_serviceHost.Close();
                string s = String.Format("{0} stopped", this.ServiceName);
                this.EventLog.WriteEntry(s, EventLogEntryType.Information);
            }

            m_serviceHost = null;
        }
    }
}
