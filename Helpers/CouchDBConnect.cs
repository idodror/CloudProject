using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using userService.Models;

namespace userService.Helpers
{
    public static class CouchDBConnect
    {
        private static string host = "https://0677dc4a-00da-46cd-97db-f627e643765e-bluemix:137c1cea45ee9a1ee20523e99f21c3086ebd7f37392def5e1bb3a4a1ffc9dc9c@0677dc4a-00da-46cd-97db-f627e643765e-bluemix.cloudant.com/{0}";
    
        public static HttpClient GetClient(string db) {
            var hc = new HttpClient();
            hc.BaseAddress = new Uri(string.Format(host, db));
            hc.DefaultRequestHeaders.Clear();
            hc.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return hc;
        }
    }
}