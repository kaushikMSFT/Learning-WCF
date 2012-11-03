// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net

using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace SimpleTransactionScope
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Operation1();
                Operation2();

                scope.Complete();
            }


            Console.WriteLine();
            Console.ReadLine();

        }

        private static void Operation1()
        {
            Console.WriteLine("Operation1() executing in transaction {0}", Transaction.Current.TransactionInformation.LocalIdentifier);
        }

        private static void Operation2()
        {
            Console.WriteLine("Operation2() executing in transaction {0}", Transaction.Current.TransactionInformation.LocalIdentifier);
        }


    }
}
