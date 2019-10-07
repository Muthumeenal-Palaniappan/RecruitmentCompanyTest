using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using ArrayCalcServiceWebAPI.Models;
using BusinessLayer;

namespace ArrayCalcServiceWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Unity Container
            var container = new UnityContainer();
            container.RegisterType<IArrayCalcRepoService, ArrayCalcRepoService>();
            config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}",
            new { id = RouteParameter.Optional });
        }
    }
}
