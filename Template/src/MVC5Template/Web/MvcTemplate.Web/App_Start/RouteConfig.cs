using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTemplate.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "PhonesRoute",
                url: "Phones/Details/{model}",
                defaults: new {controller = "Phones", action = "Details"}
            );

            routes.MapRoute(
                name: "NewList",
                url: "News/{page}",
                defaults: new { controller = "Home" , action = "NewsList", page = UrlParameter.Optional},
                constraints: new { page = "[0-9]*",  IsChrome = new IsChromeUserAgentRouteConstraint()}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class IsChromeUserAgentRouteConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext,
            Route route, string parameterName, 
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            return httpContext.Request.UserAgent.ToLower().Contains("chrome");
        }
    }
}
