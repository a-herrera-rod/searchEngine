using System;
using System.Text;
using System.IO;
using System.Net;

namespace searchfight
{
    class HttpProvider
    {
        private WebRequest request;
        private Stream dataStream;

        private string Status;

        public HttpProvider(string url)
        {
            request = WebRequest.Create(url);            
        }

        public HttpProvider(string url, string accessKey)
        {
            request = WebRequest.Create(url);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
        }

        public string GetResponse()
        {

            WebResponse response = request.GetResponse();

            this.Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}
