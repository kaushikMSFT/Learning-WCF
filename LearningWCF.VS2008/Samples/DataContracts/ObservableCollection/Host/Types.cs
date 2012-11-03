// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
   
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.ObjectModel;

namespace Host
{
    [CollectionDataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class ThingCollection: ObservableCollection<Thing>
    {
    }


    [DataContract(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class Thing
    {
        [DataMember]
        public string Name;

        [DataMember]
        public string Description;
    }
}
