using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace StockAnalyzer.Web.Api.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult GetUrlString(string url)
        {
            WebClient webClient = new WebClient();
            string resource = webClient.DownloadString(url);
            return Ok(resource);
        }

    }
}
