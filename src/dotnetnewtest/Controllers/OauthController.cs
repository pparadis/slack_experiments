using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dotnetnewtest.Controllers
{
    [Route("[controller]")]
    public class OauthController : Controller
    {
        public static HttpClient httpClient = new HttpClient();

        public IConfiguration Configuration { get; set; }
        public OauthController(IConfiguration services)
        {
            Configuration = services;
        }

        [HttpGet]
        public async Task<string> Get(string code)
        {
            var res = await httpClient.GetAsync($"https://slack.com/api/oauth.access?code={code}&client_id={Configuration["SlackClientId"]}&client_secret={Configuration["SlackClientSecret"]}");
            return await res.Content.ReadAsStringAsync();
        }
    }
}
