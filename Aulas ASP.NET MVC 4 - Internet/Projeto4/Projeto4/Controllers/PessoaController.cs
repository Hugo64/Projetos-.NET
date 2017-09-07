using Projeto4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto4.Controllers
{
    public class PessoaController : Controller
    {

        public ActionResult Index() // Criando uma página para inserir dados;
        {
            var pessoa1 = new Pessoa(); // Instanciando a classe Pessoa;
            return View();
        }


        [HttpPost] // Ocultando no http o endereço de envio
        public ActionResult Index(Pessoa pessoa1) // Passando dados da página Index e validando na mesma página pelo javaScript
        {
            if (ModelState.IsValid) // Validando os dados que foram passado pelo parametro "Index(Pessoa pessoa1)
            {
                return View("Resultado", pessoa1); // Se os dados estiverem certos, vai ser redirecionado para a página "Resultado"
            }
            return View(pessoa1);
        }


        public ActionResult Resultado(Pessoa pessoa1) // Pagina resultado recebendo parametros da página Index (Validação)
        {
            return View(pessoa1); // Retornando os dados da pessoa.
        }
    }
}
