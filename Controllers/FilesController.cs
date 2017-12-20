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
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        [HttpPost]
        [Route("UploadFile")]
        public async Task<int> UploadFile([FromBody]ImageFile file) {
            ImageFileNoRev fileNoRev = new ImageFileNoRev(file);
            var response = await Helpers.CouchDBConnect.PostToDB(fileNoRev, "files");
            
            Console.WriteLine(response);
            return 1;
        }

        [HttpGet]
        [Route("DownloadFile/{id}")]
        public async Task<ImageFile> DownloadFile(string id) {
            var hc = Helpers.CouchDBConnect.GetClient("files");
            var response = await hc.GetAsync("/files/id:" + id);

            if (!response.IsSuccessStatusCode) {
                return null;
            }

            var file = (ImageFile) JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), typeof(ImageFile));
            
            return file;
        }
    }
}