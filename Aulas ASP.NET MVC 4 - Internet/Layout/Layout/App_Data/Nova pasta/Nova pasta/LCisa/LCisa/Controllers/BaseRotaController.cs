using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCisa.Filtros;

namespace LCisa.Controllers
{
    [AutorizacaoDeAcesso]
    public class BaseRotaController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}
