using RefactionMe.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RefactionMe.Api.Controllers
{

    [RoutePrefix("test")]
    public class TestController : WebApiControllerBase
    {

        [Route]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            

            return request.CreateResponse(HttpStatusCode.OK); 
        }

    }
}
