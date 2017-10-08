﻿using RefactionMe.Api.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace RefactionMe
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = GlobalConfiguration.Configuration;
            WebApiConfig.Register(config);
            Bootstrapper.Run();
            GlobalConfiguration.Configuration.EnsureInitialized();

            //GlobalConfiguration.Configure(WebApiConfig.Register);


        }
    }
}
