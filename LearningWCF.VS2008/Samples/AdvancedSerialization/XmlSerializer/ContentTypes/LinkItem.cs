// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ContentTypes
{

    [XmlRoot(Namespace = "http://schemas.thatindigogirl.com/samples/2006/06")]
    public class LinkItem
    {

        private long m_id;
        private string m_title;
        private string m_description;
        private DateTime m_dateStart;
        private DateTime m_dateEnd;
        private string m_url;

        [XmlElement(DataType = "date", IsNullable = false, Order = 3)]
        public DateTime DateStart
        {
            get { return m_dateStart; }
            set { m_dateStart = value; }
        }

        [XmlElement(DataType = "date", IsNullable = false, Order = 4)]
        //[XmlIgnore]
        public DateTime DateEnd
        {
            get { return m_dateEnd; }
            set { m_dateEnd = value; }
        }

        [XmlElement(IsNullable = false, Order = 5)]
        public string Url
        {
            get { return m_url; }
            set { m_url = value; }
        }

        [XmlElement(IsNullable = false, Order = 0)]
        public long Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [XmlElement(IsNullable = false, Order = 1)]
        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        [XmlElement(IsNullable = false, Order = 2)]
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
    }
}
