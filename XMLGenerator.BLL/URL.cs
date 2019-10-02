using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLGenerator.BLL
{
    internal class URL
    {
        internal string host;
        internal List<string> segments;
        internal Dictionary<string, string> parameters;
        internal URL()
        {
            segments = new List<string>();
            parameters = new Dictionary<string, string>();
        }

        internal void ParseURL(string line)
        {
            string hostAndParams = line.Split(new string[] { "://" }, StringSplitOptions.None)[1];
            List<string> uri = new List<string>();
            string parametersSubstring;
            uri.AddRange(hostAndParams.Split('/'));

            if (uri[uri.Count - 1].Contains("?"))
            {
                string[] result = uri[uri.Count - 1].Split('?');
                parametersSubstring = result[1];
                uri.RemoveAt(uri.Count - 1);
                uri.Add(result[0]);

                result = parametersSubstring.Split('&');
                foreach (var parameter in result)
                {
                    parameters.Add(parameter.Split('=')[0], parameter.Split('=')[1]);
                }
            }

            host = uri[0];
            for (int i = 1; i < uri.Count; i++)
            {
                segments.Add(uri[i]);
            }
        }
    }
}
