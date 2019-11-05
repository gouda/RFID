
using SWE.RFID.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RFID.SAL.Utilities
{
    public  class WebServiceManager:IWebServiceManager
    {
        private static HttpClient client = new HttpClient();

        private static string WebServiceURL
        {
            get
            {
                return "http://nabdal-002-site3.itempurl.com/";
            }
        }

        public  string GetService(string URL,string accessToken,bool needAuth=true)
        {
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(WebServiceURL+URL);
            httpWReq.Method = "GET";
            if (needAuth)
            {

            httpWReq.Headers.Add("Authorization", "Basic "+ accessToken);

            }


            string result = null;
            using (WebResponse response =
                httpWReq.GetResponseAsync().Result)
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public  string PostService(string URL, string postData, string accessToken, string[] routeParameters, bool needAuth = true)
        {
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(WebServiceURL +string.Format( URL, routeParameters));

            byte[] data = Encoding.UTF8.GetBytes(postData);

            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/json; charset=utf-8";
            if (needAuth)
            {

                httpWReq.Headers.Add("Authorization", "Basic " + accessToken);

            }


            using (Stream stream = httpWReq.GetRequestStreamAsync().Result)
            {
                stream.Write(data, 0, data.Length);
            }

            string result = null;
            using (WebResponse response = httpWReq.GetResponseAsync().Result)
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream,Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

       
    }
}
