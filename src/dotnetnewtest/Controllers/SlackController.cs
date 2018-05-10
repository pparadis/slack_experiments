using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dotnetnewtest.Controllers
{
    public class SlackController : Controller
    {
        public static HttpClient httpClient = new HttpClient(new LoggingHandler(new HttpClientHandler()));

        public IConfiguration Configuration { get; set; }
        public SlackController(IConfiguration services)
        {
            Configuration = services;
        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<string> Post()
        {
            Console.WriteLine("Access Token is " + Configuration["SlackClientId"]);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Configuration["AccessToken"]);
            
            var response =  await httpClient.PostAsync($"https://slack.com/api/chat.postEphemeral?channel=%23pascal&text={WebUtility.UrlEncode(DateTime.Now.ToString())}&user=U7LJ3CQ2G&pretty=1", null);            
            return await Task.FromResult("Guid.NewGuid().ToString()");
        }

        [HttpPost]
        [Route("[controller]/interactive")]
        public async Task<string> Interactive()
        {
            return await Task.FromResult( Guid.NewGuid().ToString() + " - " + Guid.NewGuid().ToString());
        }

        [HttpPost]
        [Route("[controller]/interactive/options")]
        public async Task<string> InteractiveOptions()
        {
            return await Task.FromResult( Guid.NewGuid().ToString() + " - " + Guid.NewGuid().ToString());
        }
    }
}
