// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace UIService
{
        [ServiceContract(Namespace="http://www.thatindigogirl.com/samples/2006/06")]
    public interface IUIService
    {
        [OperationContract(IsOneWay=true)]
        void SendMessage(string message);
    }

    [ServiceBehavior(UseSynchronizationContext=false)]
    public class UIService : IUIService
    {

        private static ServiceForm m_form;

        public static void ShowForm(bool show)
        {
            CreateForm();
            lock(m_form)
            {
                if (m_form.InvokeRequired)
                {
                    MethodInvoker del = delegate 
                        {
                            m_form.Visible=show;
                        };
                    m_form.Invoke(del);
                }
                else
                    m_form.Visible=show;
            }
        }

        static void CreateForm()
        {
            lock (typeof(UIService))
            {
                if (m_form == null || m_form.IsDisposed)
                    m_form = new ServiceForm();
            }
        }

        static UIService()
        {
            m_form = new ServiceForm();
            m_form.FormClosed +=new System.Windows.Forms.FormClosedEventHandler(m_form_FormClosed);
        }

        static void m_form_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            lock(typeof(UIService))
            {
                m_form = null;
            }
        }

        #region IUIService Members


        public void SendMessage(string message)
        {
            CreateForm();
            m_form.AddMessage(message);
        }

        #endregion
    }


}
