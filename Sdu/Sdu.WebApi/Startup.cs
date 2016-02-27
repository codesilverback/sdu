using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Owin;


[assembly: OwinStartup(typeof(Sdu.WebApi.Startup))]

namespace Sdu.WebApi
{
     public class Startup
    {


        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            Register(httpConfiguration);
            appBuilder.UseWebApi(httpConfiguration);
        }

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Gender",
                routeTemplate: "Gender",
                defaults: new { controller = "Records", action = "Gender" }
                );
        }

    }
}