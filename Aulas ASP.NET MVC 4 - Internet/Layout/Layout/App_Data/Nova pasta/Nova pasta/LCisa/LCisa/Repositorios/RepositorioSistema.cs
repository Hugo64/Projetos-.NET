using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using LCisa.App_Data;

namespace LCisa.Repositorios
{
    public class RepositorioSistema
    {
        public static short idAutenticado { get; set; }
        public static string cargoAutenticado { get; set; }

        public static bool Autenticacao(string Login, string Senha)
        {
            var senhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");

            try
            {
                using (EntidadeLojaCisa db = new EntidadeLojaCisa())
                {
                    var Autenticado = db.LCsistema.Where(x => x.C_Login == Login && x.C_Senha == senhaCriptografada).SingleOrDefault();

                    if (Autenticado == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(Autenticado.id);
                        dadosDoAutenticado(Autenticado.id);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void dadosDoAutenticado(short Id) 
        {
            using (EntidadeLojaCisa db = new EntidadeLojaCisa())
            {
                var Funcionario = db.LCfuncionario.SingleOrDefault(x => x.LCsistema_id == Id);

                if (Funcionario.LCdepartamento.C_Cargo == "Vendedor")
                {
                    var Vendedor = db.LCvendedor.SingleOrDefault(x => x.LCfuncionario_id == Funcionario.id);
                    idAutenticado = Vendedor.id;
                    cargoAutenticado = Vendedor.LCfuncionario.LCdepartamento.C_Cargo;
                }
                else if (Funcionario.LCdepartamento.C_Cargo == "RH")
                {
                    idAutenticado = Funcionario.id;
                    cargoAutenticado = Funcionario.LCdepartamento.C_Cargo;
                }
            }
        }

        
        public static LCsistema VerificaSeOUsuarioEstaLogado()
        {
            
            var Autenticado = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (Autenticado == null)
            {
                return null;
            }
            else 
            {
                long iDUsuario = Convert.ToInt64(RepositorioCriptografia.Descriptografar(Autenticado.Values["id"])); 

                var autenticadoRetornado = RecuperaAutenticadoPorID(iDUsuario);
                return autenticadoRetornado;
            }
        }


        public static LCsistema RecuperaAutenticadoPorID(long idAutenticado)
        {
            try
            {
                using (EntidadeLojaCisa db = new EntidadeLojaCisa())
                {
                    var Autenticado = db.LCsistema.Where(x => x.id == idAutenticado).SingleOrDefault();
                    return Autenticado;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}