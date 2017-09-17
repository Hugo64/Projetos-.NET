using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCisa.Repositorios;

namespace LCisa.Filtros
{
    [HandleError]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]

public class AutorizacaoDeAcesso : ActionFilterAttribute
{
         public override void OnActionExecuting(ActionExecutingContext FiltroDeContexto)
         {
                var Controller = FiltroDeContexto.ActionDescriptor.ControllerDescriptor.ControllerName;
                var Action = FiltroDeContexto.ActionDescriptor.ActionName;

                if (Controller != "Home" || Action != "Index")
               {
                    if (RepositorioSistema.VerificaSeOUsuarioEstaLogado() == null)
                   {
                        FiltroDeContexto.RequestContext.HttpContext.Response.Redirect ("/Home/Index?Url=" + FiltroDeContexto.HttpContext.Request.Url.LocalPath);
                   }
                    else
                    {
                        RepositorioSistema.dadosDoAutenticado(RepositorioSistema.VerificaSeOUsuarioEstaLogado().id);
                    }
               }
          }
     }
}
