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
    public class SistemaController : Controller
    {

        public ActionResult Sistema()
        {
            //var Vendedor = MySQL.db.LCvendedor.ToList();
            //ViewBag.Fornecedores = new SelectList(MySQL.db.LCfornecedor, "id", "C_Marca");
            //return View(Vendedor);
            return View();
          
        }

        [HttpPost]
        public ActionResult AdicionaFuncionario(LCendereco E, LCdepartamento D, LCsistema S, LCfuncionario F, LCvendedor V)
        {
            Metodos M = new Metodos();

            if (M.adicionarFuncionario(E, D, S, F, V))
            {
                return RedirectToAction("Sistema");
            }
                return RedirectToAction("Sistema"); 
        }

        public ActionResult ExibiFuncionario(int Id)
        {
            if (RepositorioSistema.cargoAutenticado != null)
            {
                if (RepositorioSistema.cargoAutenticado == "RH")
                {
                    LCvendedor Vendedor = MySQL.db.LCvendedor.SingleOrDefault(x => x.id == Id);
                    return View(Vendedor);
                }
            }
                    return RedirectToAction("Sistema");
        }

        [HttpPost]
        public ActionResult AdicionaFornecedor(LCendereco E, LCfuncionario F, LCfornecedor FO)
        {
            Metodos M = new Metodos();

            if (M.adicionarFornecedor(E, F, FO))
            {
                return RedirectToAction("Sistema");
            }
                return RedirectToAction("Sistema");
        }

        [HttpPost]
        public ActionResult AdicionaProduto(LCproduto P) 
        {
            Metodos M = new Metodos();

            if (M.AdicionarProduto(P))
            {
                return RedirectToAction("Sistema");
            }
                return RedirectToAction("Sistema");
        }

        [HttpPost]
        public ActionResult AdicionarCompra(Produto P)
        {
            Carrinho C = new Carrinho();

            int Resultado = C.resgistrarProdutosCarrinho(P);

            if (Resultado == 1)
            {
                return RedirectToAction("Sistema");
            }
            else if (Resultado == 2)
            {
                return RedirectToAction("Sistema");
            }
            else
            {
                return RedirectToAction("Sistema");
            }

        }


        public ActionResult ExcluirCompra(int Id)
        {
            if (RepositorioSistema.cargoAutenticado == null)
            {
                if (RepositorioSistema.cargoAutenticado == "Vendedor")
                {
                    Carrinho C = new Carrinho();

                    if (C.excluirCompraCarrinho(Id))
                    {
                        return RedirectToAction("Sistema");
                    }
                }
            }
            return RedirectToAction("Sistema");
        }

        [HttpPost]
        public ActionResult finalizaCompra(int codigoDaCompra)
        {
            Carrinho C = new Carrinho();

            C.finalizandoCompra(codigoDaCompra);
            return RedirectToAction("Sistema");
        }

    }
}
