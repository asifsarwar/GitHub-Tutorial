using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestApi.Controller
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Get(string url)
        {
            return Json<Result>(new Result { value1 = "Asif", value2 = "Sarwar", value3 = "dg" });
            //WebClient webClient = new WebClient();
            //string resource = webClient.DownloadString(url);
            //return Ok(resource);
        }
    }
    public class Result
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
    }
}
