using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.IO;
using System.Text;
using System.Net;

namespace WebTools
{
    public class CustomWeb
    {
        public CustomWeb()
        {
            webClient = new WebClient();
            if (webClient != null)
            {
                Header_Reset();
            }
        }

        public string _Post(Uri uri, NameValueCollection data) => _Post(uri.ToString(), data);
        public string _Post(string uri, NameValueCollection data)
        {
            byte[] result = webClient.UploadValues(uri, "POST", data);
            string resource = Encoding.UTF8.GetString(result);
            if (resource[0] == '\n')
                resource.Remove(0, 1);
            return resource;
        }
        public string _Get(string uri) => webClient.DownloadString(new Uri(uri));
        public string _Get(Uri uri) => webClient.DownloadString(uri);

        public void AddHeader(string name, string value) => webClient.Headers.Add(name, value);
        public void Header_Reset()
        {
            webClient.Headers.Clear();
            webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12");
            webClient.Headers.Add("Accept", "*/*");
            webClient.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
            webClient.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
        }

        private WebClient webClient;
    }
}
