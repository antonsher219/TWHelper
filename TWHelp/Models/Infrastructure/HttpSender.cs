using System;
using System.IO;
using System.Net;
using System.Text;

namespace TWHelp.Models.Infrastructure
{
    public class HttpSender
    {
        public static string SendHttpRequest(Uri uri, string httpMethod, string requestJsonBody = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            httpWebRequest.Method = httpMethod;
            httpWebRequest.Timeout = 120000;

            //for post/put methods etc.
            if (requestJsonBody != null)
            {
                httpWebRequest.ContentType = "application/json";

                using (var reqStream = httpWebRequest.GetRequestStream())
                using (var sw = new StreamWriter(reqStream, Encoding.UTF8))
                {
                    sw.Write(requestJsonBody);
                }
            }

            var webResponse = httpWebRequest.GetResponse();

            using (var webStream = webResponse.GetResponseStream())
            using (var responseReader = new StreamReader(webStream))
            {
                return responseReader.ReadToEnd();
            }
        }
    }
}
