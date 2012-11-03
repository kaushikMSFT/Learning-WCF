// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Client
{
    class CallbackType: IHelloIndigoServiceCallback
    {
        #region IHelloIndigoServiceCallback Members

        public void HelloIndigoCallback(string message)
        {
              Console.WriteLine("HelloIndigoCallback on thread {0} - one-way", Thread.CurrentThread.GetHashCode());
        }

        public void HelloIndigoCallback2(string message)
        {
               Console.WriteLine("HelloIndigoCallback2 on thread {0} - not one-way", Thread.CurrentThread.GetHashCode());
        }

        #endregion
    }
}
