// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ContentTypes;
using System.Xml.Schema;
using System.Xml;
using System.IO;

namespace GigManager
{
    [XmlSchemaProvider("GetSchema")]
    public class LinkItemSerializer: IXmlSerializable
    {

        static string ns = "http://www.thatindigogirl.com/samples/2006/06";

        private LinkItem m_linkItem;

        public LinkItem LinkItem
        {
            get { return m_linkItem; }
            set { m_linkItem = value; }
        }

        public LinkItemSerializer()
        {
        }

        public LinkItemSerializer(LinkItem item)
        {
            this.m_linkItem = item;
        }

        public static XmlQualifiedName GetSchema(XmlSchemaSet schemaSet)
        {

            string schemaString = String.Format("<xs:schema xmlns:tns='{0}' xmlns:xs='http://www.w3.org/2001/XMLSchema' targetNamespace='{0}' elementFormDefault='qualified' attributeFormDefault='unqualified'><xs:complexType name='LinkItem'><xs:sequence><xs:element name='Id' type='xs:string' nillable='false'/><xs:element name='Title' type='xs:string' nillable='false'/><xs:element name='Description' type='xs:string' nillable='false'/><xs:element name='DateStart' type='xs:dateTime' nillable='false'/><xs:element name='DateEnd' type='xs:dateTime' nillable='true' minOccurs='0'/><xs:element name='Url' type='xs:string' nillable='false' minOccurs='0'/></xs:sequence></xs:complexType></xs:schema>", ns);

            XmlSchema schema = XmlSchema.Read(new StringReader(schemaString), null);
            schemaSet.XmlResolver = new XmlUrlResolver();
            schemaSet.Add(schema);

            return new XmlQualifiedName("LinkItem", ns);
        }

        #region IXmlSerializable Members

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            throw new NotImplementedException("IXmlSerializable.GetSchema() is not implemented. Use static GetSchema() instead.");

        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {

            LinkItem item = new LinkItem();

            while (reader.IsStartElement())
            {
                reader.MoveToContent();
                reader.Read();

                if (reader.IsStartElement("Id"))
                {
                    reader.MoveToContent();
                    item.Id = int.Parse(reader.ReadString());
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Id element was expected.");

                if (reader.IsStartElement("Title"))
                {
                    reader.MoveToContent();
                    item.Title = reader.ReadString();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Title element was expected.");

                if (reader.IsStartElement("Description"))
                {
                    reader.MoveToContent();
                    item.Description = reader.ReadString();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Description element was expected.");

                if (reader.IsStartElement("DateStart"))
                {
                    reader.MoveToContent();
                    reader.Read();
                    item.DateStart = reader.ReadContentAsDateTime();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: DateStart element was expected.");

                if (reader.IsStartElement("DateEnd"))
                {
                    reader.MoveToContent();
                    reader.Read();
                    item.DateEnd = reader.ReadContentAsDateTime();
                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                // optional

                if (reader.IsStartElement("Url"))
                {
                    reader.MoveToContent();
                    item.Url = reader.ReadString();

                    reader.MoveToContent();
                    reader.ReadEndElement();
                }
                else
                    throw new XmlException("ExpectedElementMissing: Url element was expected.");

                reader.MoveToContent();
                reader.ReadEndElement();
            }


            this.m_linkItem = item;
        }

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {

            writer.WriteStartElement("Id", ns);
            writer.WriteValue(m_linkItem.Id);
            writer.WriteEndElement();

            writer.WriteElementString("Title", ns, m_linkItem.Title);
            writer.WriteElementString("Description", ns, m_linkItem.Description);

            writer.WriteStartElement("DateStart", ns);
            writer.WriteValue(m_linkItem.DateStart);
            writer.WriteEndElement();

            writer.WriteStartElement("DateEnd", ns);
            writer.WriteValue(m_linkItem.DateEnd);
            writer.WriteEndElement();

            writer.WriteElementString("Url", ns, m_linkItem.Url);

        }

        #endregion
    }
}
