using LinkASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Buritirama> noticiasBuritirama;

        public HomeController()
        {
            noticiasBuritirama = new Buritirama().listaBuritirama().OrderByDescending(x => x.Data);
        }

        public ActionResult Index()
        {
            var primeirasNoticias = noticiasBuritirama.Take(3);
            var todasCategorias = noticiasBuritirama.Select(x => x.Categoria).Distinct().ToList();
            ViewBag.Categorias = todasCategorias;
            return View(primeirasNoticias);
        }

        public ActionResult mostraTitulo(string categoria)
        {
            var recebeCategoria = noticiasBuritirama.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();
            ViewBag.Categorias = categoria;
            return View(recebeCategoria);
        }

        public ActionResult mostraTexto(int NoticiaId, string Categoria, string Titulo)
        {
            return View(noticiasBuritirama.FirstOrDefault(x => x.NoticiaId == NoticiaId));
        }

        public ActionResult todosTitulos()
        {
            return View(noticiasBuritirama);
        }
    }
}
