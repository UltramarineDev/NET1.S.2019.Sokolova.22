using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XMLGenerator.BLL.Interface;
using XMLGenerator.DAL.Interface;
using Logger.Interface;

namespace XMLGenerator.BLL
{
    public class XMLConverter : IConverter
    {
        private readonly IDataReader dataReader;
        private readonly ILog log;

        public XMLConverter(IDataReader dataReader, ILog log)
        {
            this.dataReader = dataReader;
            this.log = log;
        }

        public XElement Convert()
        {

            List<string> urls = dataReader.GetData().ToList();

            List<XElement> xElements = new List<XElement>();
            foreach (var url in urls)
            {
                if (!Validate(url))
                {
                    log.Log(url);
                }
                else
                {
                    xElements.Add(ConvertURLToXML(url));
                }
            }

            return new XElement("urlAddresses", xElements);
        }

        private XElement ConvertURLToXML(string line)
        {
            URL uRL = new URL();
            uRL.ParseURL(line);
            List<XElement> urlAddressContent = new List<XElement>();
            urlAddressContent.Add(new XElement("host", new XAttribute("name", uRL.host)));
            if (uRL.segments.Count > 0)
            {
                List<XElement> uriSegments = new List<XElement>();

                foreach (var segment in uRL.segments)
                {
                    uriSegments.Add(new XElement("segment", segment));
                }

                urlAddressContent.Add(new XElement("uri", uriSegments));
            }

            if (uRL.parameters.Count > 0)
            {
                List<XElement> uriParameters = new List<XElement>();

                foreach (var parameter in uRL.parameters)
                {
                    uriParameters.Add(new XElement("parameter",
                        new XAttribute("key", parameter.Key),
                        new XAttribute("value", parameter.Value)));
                }

                urlAddressContent.Add(new XElement("uri", uriParameters));
            }

            return new XElement("urlAddress", urlAddressContent);
        }

        private bool Validate(string line)
        {
            try
            {
                Uri uri = new Uri(line);
                var scheme = uri.Scheme;
                var host = uri.Host;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
