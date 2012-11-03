// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowsHost
{
    static class Program
    {
        public static ServiceHost MyServiceHost;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit +=new EventHandler(Application_ApplicationExit);
            Program.MyServiceHost = new ServiceHost(typeof(HelloIndigo.HelloIndigoService));
            Program.MyServiceHost.Open();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
                if (Program.MyServiceHost!=null)
                {
                    Program.MyServiceHost.Close();
                    Program.MyServiceHost=null;
                }
        }
    }
}