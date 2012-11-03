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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Counters.Dalc;
using System.Transactions;

namespace Counters
{
    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface ICountersService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ResetCounters();

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SetCounter1(int counterValue);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SetCounter2(int counterValue);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        List<CounterInfo> GetCounters();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, TransactionTimeout="00:00:01")]
    public class CountersService : ICountersService
    {

        #region ICountersService Members

        [OperationBehavior(TransactionScopeRequired=true, TransactionAutoComplete=true)]
        public void ResetCounters()
        {
            Transaction.Current.TransactionCompleted += new TransactionCompletedEventHandler(Current_TransactionCompleted);

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter1(0);
                Thread.Sleep(5000);
                countersDataAccess.SetCounter2(0);

            }
                
        }

        void Current_TransactionCompleted(object sender, TransactionEventArgs e)
        {
            Console.WriteLine("Transaction completed with the following status: {0}", e.Transaction.TransactionInformation.Status);
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SetCounter1(int counterValue)
        {

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter1(counterValue);
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SetCounter2(int counterValue)
        {
            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter2(counterValue);
            }
        }

        public List<CounterInfo> GetCounters()
        {
            List<CounterInfo> counters = new List<CounterInfo>();

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                CountersDataSet.CountersDataTable table = countersDataAccess.GetCounters();
                foreach (CountersDataSet.CountersRow r in table)
                {

                    CounterInfo counter = new CounterInfo();
                    counter.Id = r.id;
                    counter.CounterValue = r.value;
                    counters.Add(counter);
                }
            }

            return counters;

        }

        #endregion
    }
}
