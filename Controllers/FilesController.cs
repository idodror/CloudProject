using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudProject.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace CloudProject.Controllers
{
    public class FilesController : Controller
    {
        [HttpPost]
        [Route("/UploadFile")]
        public async Task<int> UploadFile([FromBody]MyFileObject file) {

            var hc = Helpers.CouchDBConnect.GetClient("files"); //need create db by named: "files"
            string json = JsonConvert.SerializeObject(file);
            HttpContent htc = new StringContent(json,System.Text.Encoding.UTF8,"application/json");
            var response = await hc.PostAsync("",htc); //hc.PostAsync("files",htc)????
            
            Console.WriteLine(response); //Debug
            return 1;
        }

        [HttpGet]
        [Route("/DownloadFile")]
        public async Task<MyFileObject> DownloadFile([FromBody]MyFileObject file) {
            var hc = Helpers.CouchDBConnect.GetClient("files");
            var response = await hc.GetAsync("files/"+file.ID);
            if (response.IsSuccessStatusCode) {
                MyFileObject newFile = new MyFileObject();
                newFile.ID=file.ID;
                newFile.TypeFile=file.TypeFile;
                newFile.NameFile=file.NameFile;
                newFile.ByteFile=file.ByteFile;
                
                return newFile;
            }
            
            return null;
        }
    }
}