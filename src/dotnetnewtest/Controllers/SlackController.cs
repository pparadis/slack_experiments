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
    public class SlackController : Controller
    {
        public static HttpClient httpClient { get; set; }

        public IConfiguration Configuration { get; set; }
        public SlackController(IConfiguration services)
        {
            Configuration = services;
        }

        [HttpPost]
        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
