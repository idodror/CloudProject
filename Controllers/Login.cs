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
    public class Login : Controller
    {
        static Dictionary<string, Token> ActiveLogins = new Dictionary<string, Token>();
        static List<User> Users = new List<User>();

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("ValidateSession/{tokenId}")]
        public async Task<Boolean> ValidateSession([FromQuery] string tokenId) {
            var hc = Helpers.CouchDBConnect.GetClient("users");
            var response = await hc.GetAsync("/users/" + tokenId);
            if (!response.IsSuccessStatusCode) {
                return false;
            }

            var token = (Token) JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), typeof(Token));
                       
            if (token.create.AddSeconds(token.ttl).CompareTo(DateTime.Now) > 0) {
                 return true;               
            }
            
            return false;
        }

        // POST api/values
        [HttpPost]
        public async Task<dynamic> Post([FromBody] User u)
        {
            var hc = Helpers.CouchDBConnect.GetClient("users");
            var response = await hc.GetAsync("users/" + u._id);
            if (response.IsSuccessStatusCode) {
                User user = (User)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync(), typeof(User));
                if (user.password.Equals(u.password)) {
                    Token t = new Token();
                    t._id = u._id + ":token" + Guid.NewGuid();
                    t.create = DateTime.Now;
                    t.ttl = 600;

                    HttpContent htc = new StringContent(
                        JsonConvert.SerializeObject(t),
                        System.Text.Encoding.UTF8,
                        "application/json"
                    );

                    await hc.PostAsync("users", htc);
                    return t;
                }
            }

            return -1;
        }

        async Task<Boolean> DoesUserExist(User u) {
            var hc = Helpers.CouchDBConnect.GetClient("users");
            var response = await hc.GetAsync("users/" + u._id);
            if (response.IsSuccessStatusCode) {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<int> CreateUser([FromBody] User u) {
            var doesExist = await DoesUserExist(u);
            if (doesExist) {
                return -1;
            }
            var hc = Helpers.CouchDBConnect.GetClient("users");
            string json = JsonConvert.SerializeObject(u);
            HttpContent htc = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await hc.PostAsync("", htc);
            
            Console.WriteLine(response);
            return 1;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}