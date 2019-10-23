using System;
using System.IO;
using System.Net;
using System.Text;

namespace ElasticSearch
{
    class CustomHttpSender
    {
        public static string SendHttpRequest(Uri uri, string httpMethod, string requestJsonBody = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = httpMethod;
            httpWebRequest.Timeout = 35000;

            //for post/put methods etc.
            if (requestJsonBody != null)
            {
                httpWebRequest.ContentType = "application/json";

                using (Stream reqStream = httpWebRequest.GetRequestStream())
                using (var sw = new StreamWriter(reqStream, Encoding.UTF8))
                {
                    sw.Write(requestJsonBody);
                }
            }

            using (WebResponse webResponse = httpWebRequest.GetResponse())
            using (Stream webStream = webResponse.GetResponseStream())
            using (var responseReader = new StreamReader(webStream))
            {
                return responseReader.ReadToEnd();
            }
        }
    }
}
