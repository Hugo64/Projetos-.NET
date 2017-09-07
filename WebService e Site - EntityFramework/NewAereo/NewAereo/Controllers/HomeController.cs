using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAereo.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference.WebServiceSoapClient client = new ServiceReference.WebServiceSoapClient();
        // GET: Home
        public ActionResult Index()
        {
            return View(client.PassagemDoCliente("074.740.485-23"));
        }
    }
}