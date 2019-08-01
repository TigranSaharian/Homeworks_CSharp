using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace RestClient
{
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class RestClient
    {
        public string endPoint { get; set; }
        public HttpVerb httpMethod { get; set; }

        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = HttpVerb.GET;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationExeption("Error code: " + response.StatusCode.ToString());
                }

                //Process the response stream....(could be JSON, XML or HTML etc...)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }//end of StreamReader
                    }
                }//End of using ResponseStream

            }
            return strResponseValue;
        }
    }

    [Serializable]
    internal class ApplicationExeption : Exception
    {
        private object p;

        public ApplicationExeption()
        {
        }

        public ApplicationExeption(object p)
        {
            this.p = p;
        }

        public ApplicationExeption(string message) : base(message)
        {
        }

        public ApplicationExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApplicationExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}
