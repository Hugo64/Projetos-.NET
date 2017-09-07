using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceSETE.Model;
using WebServiceSETE.Controller;
using WebServiceSETE.BdSete;

namespace WebServiceSETE
{
    /// <summary>
    /// Descrição resumida de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public int InserirEndereco(Endereco endereco)
        {
            return EntityController.AdicionarEndereco(endereco);
        }

        [WebMethod]
        public bool InserirEmpresa(Empresa empresa)
        {
            return EntityController.AdicionarEmpresa(empresa);
        }

        [WebMethod]
        public bool InserirCliente(Cliente cliente)
        {
            return EntityController.AdicionarCliente(cliente);
        }

        [WebMethod]
        public bool InserirPassagem(Passagem passagem)
        {
            return EntityController.AdicionarPassagem(passagem);
        }

        [WebMethod]
        public Passagem PassagemDoCliente(string Cpf)
        {
            return EntityController.Buscar_Passagem_Do_Cliente(Cpf);
        }
    }
}
