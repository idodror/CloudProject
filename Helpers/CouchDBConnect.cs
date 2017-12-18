using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CloudProject.Models;

namespace CloudProject.Helpers
{
    public static class CouchDBConnect
    {
        //need open the sahre database for cloud project and change the host link
        private static string host = "https://6cab7482-dcc2-4811-b663-92b745fadf34-bluemix:01b8806a1d786493af5411b2ec8deed4759a0bd0dc7de2013a8090a99caa2ab2@6cab7482-dcc2-4811-b663-92b745fadf34-bluemix.cloudant.com/{0}";
        public static HttpClient GetClient(string db) {
            var hc = new HttpClient();
            hc.BaseAddress = new Uri(string.Format(host,db));
            hc.DefaultRequestHeaders.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine(hc.DefaultRequestHeaders);
            return hc;
        }
    }
}