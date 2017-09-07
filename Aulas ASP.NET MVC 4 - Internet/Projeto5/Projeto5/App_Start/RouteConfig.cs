using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projeto5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Todas as Noticias",
                url: "Noticias/", // Quando a pessoa digitar "Noticias/" na url do browser, vai ir para "Home" -> "todasNoticias";
                defaults: new {Controller = "Home", Action = "todasNoticias"} // Mostrando as noticias desse parametro;
                );

            routes.MapRoute(
                name: "Categoria",
                url: "Noticias/{categoria}", // Enviando um parametro da categoria para action: "mostraCategoria" que recebe um parametro no "HomeController"; 
                defaults: new {Controller = "Home", Action = "mostraCategoria"} // Mostrando as noticias desse parametro;
                );

            routes.MapRoute(
                name: "Mostra Noticias",
                url: "Noticias/{Categoria}/{Titulo}-{NoticiaId}", // Mostrando a Categoria, Titulo e id da noticia que foi filtrada da action: "mostraNoticia" que recebe parametros no "HomeController";
                defaults: new { Controller = "Home", Action = "mostraNoticia"}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}