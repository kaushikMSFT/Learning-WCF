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
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void SetCounter1(int counterValue);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void SetCounter2(int counterValue);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        List<CounterInfo> GetCounters();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, TransactionIsolationLevel=IsolationLevel.Serializable)]
    public class CountersService : ICountersService
    {

        #region ICountersService Members

        [OperationBehavior(TransactionScopeRequired=true, TransactionAutoComplete=true)]
        public void ResetCounters()
        {

            TraceTransactionInfo("ResetCounters()");

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter1(0);
                countersDataAccess.SetCounter2(0);
            }
            
        }

        private void TraceTransactionInfo(string methodName)
        {
            Console.WriteLine("Transaction information for {0}:", methodName);

            if (Transaction.Current != null)
            {
                Console.WriteLine("\t IsolationLevel: {0} \r\n\t CreationTime: {1} \r\n\t DistributedIdentifier: {2} \r\n\t Status: {3}", Transaction.Current.IsolationLevel, Transaction.Current.TransactionInformation.CreationTime, Transaction.Current.TransactionInformation.DistributedIdentifier, Transaction.Current.TransactionInformation.Status);
            }
            else
                Console.WriteLine("Transaction.Current == null");
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SetCounter1(int counterValue)
        {
            TraceTransactionInfo("SetCounter1()");

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter1(counterValue);
            }
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SetCounter2(int counterValue)
        {
            TraceTransactionInfo("SetCounter2()");

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter2(counterValue);
            }
        }

        public List<CounterInfo> GetCounters()
        {
            TraceTransactionInfo("GetCounters()");

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
