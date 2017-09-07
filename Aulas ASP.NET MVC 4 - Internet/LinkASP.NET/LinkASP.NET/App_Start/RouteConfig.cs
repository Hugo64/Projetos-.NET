using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LinkASP.NET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Olá Buritirama!",
                url: "Buritirama/",
                defaults: new {Controller = "Home", Action = "todosTitulos" }
                );

            routes.MapRoute(
                name: "Mostra Noticias",
                url:"Buritirama/{categoria}",
                defaults: new {Controller = "Home", Action = "mostraTitulo" }
                );

            routes.MapRoute(
                name: "Noticias",
                url: "Buritirama/{categoria}/{Titulo}-{NoticiaId}",
                defaults: new {Controller = "Home", Action = "mostraTexto" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}