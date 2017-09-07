using Projeto5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto5.Controllers
{
    public class HomeController : Controller
    {                                         // Nome da variavel "todasAsNoticias";
        private readonly IEnumerable<Noticia> todasAsNoticias; // "Instanciando a "ArrayList" da classe "Noticia";

        public HomeController() // Método construtor do Home, 
        {
            // todasAsNoticias recebe todasAsNoticias ordenada de trás para frente pela data;
            todasAsNoticias = new Noticia().todasAsNoticias().OrderByDescending(x => x.Data);
        }

        public ActionResult Index() // Página principal "Index"
        {
            // ".Take" == Pegando as primeiras 3 noticias da "ArrayList";
            var ultimasNoticias = todasAsNoticias.Take(3);

            // Pegando apenas as categorias... "Distinct().ToList()" == Categorias diferentes (para não trazer duplicatas), toda a lista;
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList(); 

            // Passando todas essas categorias para a View ->
            ViewBag.Categorias = todasAsCategorias;

            // Retornando para View as ultimasNoticias;
            return View(ultimasNoticias);
        }

        public ActionResult todasNoticias()
        {
            return View(todasAsNoticias); // Passando todas as noticias da "ArrayList" para a página "mostraNoticias" ;
        }

        public ActionResult mostraNoticia(int NoticiaId, string Titulo, string Categoria) // "Titulo" e "Categoria" será para gerar um URL amigavel;
        {
            // Seleciona para mim, nesta lista de noticias, a noticia cujo noticiaId (classe Noticia) seja igual a noticiaId do parametro;
            return View(todasAsNoticias.FirstOrDefault(x => x.noticiaId == NoticiaId)); // Noticia filtrada pelo id
        }

        public ActionResult mostraCategoria(string categoria) // recebendo um categoria como parametro;
        {
            // Buscando no "ArrayList" todas noticias que tem essa categoria e filtra ele;
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList(); // Recebendo um categoria;

            // Guardando a categoria dentro da ViewBag.Categoria para mostrar na View;
            ViewBag.Categoria = categoria;

            return View(categoriaEspecifica); // Jogando todas as noticias que pertence a essa categoria que foi passada no parametro;
        }

    }
}
