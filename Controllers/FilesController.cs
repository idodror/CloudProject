using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudProject.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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


        [HttpGet]
        [Route("GetList/{id}")] //all image by id (user)
        public async Task<IEnumerable<ImageFile>> GetList(string id) {
            var hc = Helpers.CouchDBConnect.GetClient("files");

            //var response = await hc.GetAsync("/files/_all_docs?startkey=%22file:" + id +"%22");
            var response = await hc.GetAsync("/files/_all_docs?startkey=\"file:moris\"&include_docs=true");

            if (!response.IsSuccessStatusCode) {
                    return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);

            var filList = (IEnumerable<ImageFile>) JsonConvert.DeserializeObject(json.ToString(),typeof(IEnumerable<ImageFile>));
            
            return filList;
        }
    }
      
        
}            
