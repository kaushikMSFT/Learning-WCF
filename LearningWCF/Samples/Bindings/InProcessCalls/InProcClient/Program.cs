// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;

namespace InProcClient
{
    static class Program
    {
        public static ServiceHost s_serviceHost;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        
            Application.ApplicationExit +=new EventHandler(Application_ApplicationExit);

            Program.MyHost.Open();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Program.MyHost.Close();
        }

        private static ServiceHost MyHost
        {
            get{
                if (s_serviceHost == null)
                {
                    NetNamedPipeBinding binding = new NetNamedPipeBinding();
                    
                    s_serviceHost = new ServiceHost(typeof(HelloIndigo.HelloIndigoService));
                    s_serviceHost.AddServiceEndpoint(typeof(HelloIndigo.IHelloIndigoService), binding, "net.pipe://localhost/HelloIndigoService");          
                }
                return s_serviceHost;}
        }

    }
}