using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LCisa.Repositorios
{
    public class RepositorioCookies
    {
        public static void RegistraCookieAutenticacao(long idDoUsuario)
        {
            HttpCookie FunCookie = new HttpCookie("UserCookieAuthentication");
            FunCookie.Values["id"] = LCisa.Repositorios.RepositorioCriptografia.Criptografa(idDoUsuario.ToString());
            FunCookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(FunCookie);
        }
    }
}