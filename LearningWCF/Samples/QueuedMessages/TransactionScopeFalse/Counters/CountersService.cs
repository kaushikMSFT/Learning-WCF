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
        [OperationContract(IsOneWay=true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void ResetCounters();

        [OperationContract(IsOneWay = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SetCounter1(int counterValue);

        [OperationContract(IsOneWay = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void SetCounter2(int counterValue);

    }

    [ServiceContract(Namespace = "http://www.thatindigogirl.com/samples/2006/06")]
    public interface ICountersAdmin
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        List<CounterInfo> GetCounters();
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class CountersService : ICountersService, ICountersAdmin
    {

        [OperationBehavior(TransactionScopeRequired=false)]
        public void ResetCounters()
        {

            using (TransactionScope scope = new TransactionScope())
            {
                Console.WriteLine("About to reset counters to {0} on transaction id {1}", 0, Transaction.Current.TransactionInformation.LocalIdentifier);

                using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
                {
                    countersDataAccess.SetCounter1(0);
                    countersDataAccess.SetCounter2(0);
                }

                Console.WriteLine("Reset counters to {0} on transaction id {1}", 0, Transaction.Current.TransactionInformation.LocalIdentifier);

                scope.Complete();
            }

        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public void SetCounter1(int counterValue)
        {
            Console.WriteLine("About to reset counter 1 to {0}", counterValue);

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter1(counterValue);
            }
            Console.WriteLine("Reset counter 1 to {0} ", counterValue);
        }

        [OperationBehavior(TransactionScopeRequired = false)]
        public void SetCounter2(int counterValue)
        {
            Console.WriteLine("About to reset counter 2 to {0}", counterValue);

            using (Counters.Dalc.CountersDataAccess countersDataAccess = new Counters.Dalc.CountersDataAccess())
            {
                countersDataAccess.SetCounter2(counterValue);
            }
            Console.WriteLine("Reset counter 2 to {0}", counterValue);
        }

        [OperationBehavior(TransactionScopeRequired = false)]
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

    }
}
