using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using CloudProject.Models;

namespace CloudProject.Helpers
{
    public static class CouchDBConnect
    {
<<<<<<< HEAD
        //need open the sahre database for cloud project and change the host link
        private static string host = "https://6cab7482-dcc2-4811-b663-92b745fadf34-bluemix:01b8806a1d786493af5411b2ec8deed4759a0bd0dc7de2013a8090a99caa2ab2@6cab7482-dcc2-4811-b663-92b745fadf34-bluemix.cloudant.com/{0}";
        public static HttpClient GetClient(string db) {
            var hc = new HttpClient();
            hc.BaseAddress = new Uri(string.Format(host,db));
            hc.DefaultRequestHeaders.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine(hc.DefaultRequestHeaders);
=======
        private static string host = "https://0677dc4a-00da-46cd-97db-f627e643765e-bluemix:137c1cea45ee9a1ee20523e99f21c3086ebd7f37392def5e1bb3a4a1ffc9dc9c@0677dc4a-00da-46cd-97db-f627e643765e-bluemix.cloudant.com/{0}";
    
        public static HttpClient GetClient(string db) {
            var hc = new HttpClient();
            hc.BaseAddress = new Uri(string.Format(host, db));
            hc.DefaultRequestHeaders.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
>>>>>>> e04c8236616c6e27777fbbb28d8da3471dd179f2
            return hc;
        }
    }
}