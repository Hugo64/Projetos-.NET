using Projeto3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto3.Controllers
{
    public class HomeController : Controller
    {
 
        public ActionResult Index()
        {
            var Pessoa = new Pessoa
            {
                Codigo = 1,
                Nome = "Hugo Vidal",
                Email = "@HugoVidal"
                
            };
            return View(Pessoa);
        }

        public ActionResult Lista(Pessoa pessoa1)
        {
            return View(pessoa1);
        }

    }
}
