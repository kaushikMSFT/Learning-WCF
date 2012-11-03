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

namespace Sessions
{

    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06", SessionMode = SessionMode.Required)]
    public interface ISessionService
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void StartSession();
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void IncrementCounter();
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        int GetCounter();
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        string GetSessionId();
        [OperationContract(IsInitiating = false, IsTerminating = true)]
        void StopSession();
    }


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class SessionService : ISessionService
    {
        private int m_counter = 0;

        #region ISessionService Members

        public void StartSession()
        {
            m_counter = 1;
        }

        public void IncrementCounter()
        {
            m_counter++;
        }

        public int GetCounter()
        {
            return m_counter;
        }

        public string GetSessionId()
        {
            return OperationContext.Current.SessionId;
        }

        public void StopSession()
        {
            m_counter = 0;

        }

        #endregion
    }
}
