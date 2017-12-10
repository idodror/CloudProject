using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CloudProject.Controllers
{
    public class FilesController : Controller
    {
        [HttpPost]
        [Route("/UploadFile")]
        public IEnumerable<String> UploadFile([FromBody] Object value) {
            return new string[] { "hello", "world" };
        }

        [HttpGet]
        [Route("/Test")]
        public IEnumerable<String> bla() {
            return new String[] {"hello", "world"};
        }
    }
}