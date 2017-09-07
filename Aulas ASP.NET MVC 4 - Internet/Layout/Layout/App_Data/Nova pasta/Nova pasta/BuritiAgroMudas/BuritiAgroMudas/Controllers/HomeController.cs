using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuritiAgroMudas.Models;

namespace BuritiAgroMudas.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            if (Session["conte"] == null)
            {
                Session["conte"] = 0;
            }
            else
            {
                ViewBag.QuantidadeProduto = Session["conte"];
            }

            return View();
        }

        public ActionResult Venda_Jardim()
        {
            if (Session["conte"] == null)
            {
                Session["conte"] = 0;
            }
            else
            {
                ViewBag.QuantidadeProduto = Session["conte"];
            }

            return View();
        }

        public ActionResult Venda_Frutiferas()
        {
            if (Session["conte"] == null)
            {
                Session["conte"] = 0;
            }
            else
            {
                ViewBag.QuantidadeProduto = Session["conte"];
            }

            return View();
        }

        public ActionResult Venda_Fertilizantes()
        {
            if (Session["conte"] == null)
            {
                Session["conte"] = 0;
            }
            else
            {
                ViewBag.QuantidadeProduto = Session["conte"];
            }

            return View();
        }

        public ActionResult Venda_Sementes()
        {
            if (Session["conte"] == null)
            {
                Session["conte"] = 0;
            }
            else
            {
                ViewBag.QuantidadeProduto = Session["conte"];
            }

            return View();
        }

        public ActionResult Carrinho()
        {
            Carrinho carrinho = new Carrinho();
            var produtos = carrinho.exibirProdutos().ToList();
            ViewBag.ValorTodosProdutos = carrinho.valorTodosProdutos();
            return View(produtos);
        }

        [HttpPost]
        public ActionResult Carrinho(string descricao, int quantidadeP)
        {
            Carrinho carrinho = new Carrinho();
            carrinho.descricao = descricao;
            carrinho.quantidade = quantidadeP;

            if (carrinho.addProdutos(carrinho))
            {
                Session["conte"] = Convert.ToString(carrinho.exibirProdutos().Count);
                return Json(Session["conte"], JsonRequestBehavior.AllowGet);
            }
            else
            {
                Session["conte"] = Convert.ToString(carrinho.exibirProdutos().Count);
                return Json(Session["conte"], JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CarrinhoRefresh()
        {
            Carrinho carrinho = new Carrinho();
            var produtos = carrinho.exibirProdutos().ToList();
            ViewBag.ValorTodosProdutos = carrinho.valorTodosProdutos();
            return View(produtos);
        }


        [HttpPost]
        public void excluirProduto(string descricao)
        {
            Carrinho carrinho = new Carrinho();
            carrinho.excluirProduto(descricao);
            Session["conte"] = carrinho.exibirProdutos().Count;
        }

        [HttpPost]
        public void opcaoQuantidade(string descricao, int quantidade, string opcao)
        {
            Carrinho carrinho = new Carrinho();
            carrinho.aumentarQuantidade(descricao, quantidade, opcao);
        }


        public ActionResult quantidadeMudas(string id)
        {
            Carrinho carrinho = new Carrinho();
            var produtos = carrinho.exibirProdutos().FirstOrDefault(x => x.id == id);
            return View(produtos);
        }
    }
}
