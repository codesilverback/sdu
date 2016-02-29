using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.ModelBinding;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Owin;
using Sdu.Data.Models;
using Sdu.Data.Repositories;


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

            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            container.Register(
             Component.For<IRepository<Person>>().ImplementedBy<CommaDelimitedDataRepository<Person>>()
         );
            GlobalConfiguration.Configuration.DependencyResolver = new Dependencies.DependencyResolver(container.Kernel);
         

        }

        public static void Register(HttpConfiguration config)
        {      // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }

    }
}