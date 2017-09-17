using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LCisa.Repositorios;
using LCisa.Models;
using LCisa.App_Data;

namespace LCisa.Controllers
{
    public class HomeController : BaseRotaController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LCsistema Sistema)
        {
            if (RepositorioSistema.Autenticacao(Sistema.C_Login, Sistema.C_Senha))
            {
                return RedirectToAction("Sistema", "Sistema");
            }
                return RedirectToAction("Index");
        }
    }
}
