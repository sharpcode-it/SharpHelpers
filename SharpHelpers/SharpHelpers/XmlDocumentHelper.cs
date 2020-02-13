// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SharpCoding.SharpHelpers
{
    public static class XmlDocumentHelper
    {
        /// <summary>
        /// Return a XmlDocument from a XDocument
        /// </summary>
        /// <param name="xDocument"></param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            if (xDocument == null) throw new ArgumentNullException(nameof(xDocument));

            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        /// <summary>
        /// Return a XDocument from a XmlDocument
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            if (xmlDocument == null) throw new ArgumentNullException(nameof(xmlDocument));

            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }

        /// <summary>
        /// Return a XmlDocument from a XElement
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this XElement xElement)
        {
            if (xElement == null) throw new ArgumentNullException(nameof(xElement));

            var sb = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = false };
            using (var xw = XmlWriter.Create(sb, settings))
            {
                xElement.WriteTo(xw);
            }
            var doc = new XmlDocument();
            doc.LoadXml(sb.ToString());
            return doc;
        }
    }
}
