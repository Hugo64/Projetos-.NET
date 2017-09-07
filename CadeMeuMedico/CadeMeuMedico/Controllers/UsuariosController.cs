using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using CadeMeuMedico.Repositorios;

namespace CadeMeuMedico.Controllers
{
    public class UsuariosController : BaseController
    {
        //
        // GET: /Usuarios/

        public ActionResult AutenticacaoDeUsuario()
        {
            return View();
        }

        [HttpGet]
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (RepositorioUsuarios.AutenticarUsuario(Login, Senha))
            {
                return Json(new
                {
                    Ok = true,
                    Mensagem = "Usuário autenticado. Redirecionando..."
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    Ok = false,
                    Mensagem = "Usuário não encontrado. Tente novamente."
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
