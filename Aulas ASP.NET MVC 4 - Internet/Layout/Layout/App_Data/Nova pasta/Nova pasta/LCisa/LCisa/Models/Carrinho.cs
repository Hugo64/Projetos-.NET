using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LCisa.App_Data;
using LCisa.Repositorios;

namespace LCisa.Models
{
    public class Carrinho : MySQL
    {
        public static double Total           { get; set; }
        private static int   autoIncrement;

        public static List<Produto> carrinhoProdutos = new List<Produto>();
        private List<int> Ids = new List<int>(); 

        public int resgistrarProdutosCarrinho(Produto P)
        {
            var Produto = db.LCproduto.FirstOrDefault(x => x.I_CodBarra == P.codBarra);
            if (Produto != null)
            {
                if (Produto.I_Quantidade >= P.Quantidade)
                {
                    autoIncrement++;
                    P.Id = autoIncrement;
                    P.Valor = Produto.I_Valor;
                    P.valorTotal = (P.Valor * P.Quantidade);
                    P.Descricao = Produto.C_Descricao;
                    Total += P.valorTotal;
                    carrinhoProdutos.Add(P);
                }
                else
                {
                    return 1;
                }
            }
            return 2;
        }

        public bool excluirCompraCarrinho(int Id)
        {
            for (int i = 0; i < carrinhoProdutos.Count; i++)
            {
                if (Id == carrinhoProdutos[i].Id)
                {
                    Total -= carrinhoProdutos[i].valorTotal;
                    carrinhoProdutos.Remove(carrinhoProdutos[i]);
                    return true;
                }
            }
            return false;
        } 

        public void finalizandoCompra(int codigoDacompra)
        {
            Inicio:
            for (int i = 0; i < carrinhoProdutos.Count; i++)
            {
                var clienteCadastrado = db.LCcliente.FirstOrDefault(x => x.I_CodigoDaCompra == codigoDacompra);
                if (clienteCadastrado != null)
                {
                    finalizaCompra(clienteCadastrado.id, carrinhoProdutos[i].Id);
                }
                else
                {
                    LCcliente Cliente = new LCcliente();
                    Cliente.I_CodigoDaCompra = codigoDacompra;
                    db.LCcliente.Add(Cliente);
                    db.SaveChanges();
                    goto Inicio;
                }
            }
            for (int j = 0; j < carrinhoProdutos.Count; j++)
            {
                Ids.Add(carrinhoProdutos[j].Id);
            }
            for (int h = 0; h < Ids.Count; h++)
            {
                excluirCompraCarrinho(Ids[h]);
            }
        }

        private void finalizaCompra(short idDoCliente, int idDoProdutoCarrinho)
        {
            for (int i = 0; i < carrinhoProdutos.Count; i++)
            {
                if (idDoProdutoCarrinho == carrinhoProdutos[i].Id)
                {
                    int codBarra = carrinhoProdutos[i].codBarra;
                    var Produto = db.LCproduto.FirstOrDefault(x => x.I_CodBarra == codBarra);

                    var dataRegistrado = DateTime.Now;

                    LCvenda Venda = new LCvenda();
                    Venda.D_datVenda = dataRegistrado;
                    Venda.Quantidade = carrinhoProdutos[i].Quantidade;
                    Venda.LCproduto_id = Produto.id;
                    Venda.LCcliente_id = idDoCliente;
                    Venda.LCvendedor_id = RepositorioSistema.idAutenticado;
                    db.LCvenda.Add(Venda);
                    db.SaveChanges();

                    Produto.I_Quantidade -= carrinhoProdutos[i].Quantidade;
                    db.Entry(Produto).State = System.Data.EntityState.Modified;
                    db.SaveChanges();

                    var Vendedor = db.LCvendedor.FirstOrDefault(x => x.id == RepositorioSistema.idAutenticado);
                    Vendedor.I_Comissao += (((Produto.I_Valor * Venda.Quantidade) / 100) * Vendedor.I_Bonificacao);
                    db.Entry(Vendedor).State = System.Data.EntityState.Modified;
                    db.SaveChanges();

                    break;
                }
            }
        }
    }

    public class Produto
    {
        public int      Id         { get; set; }
        public int      codBarra   { get; set; }
        public string   Descricao  { get; set; }
        public int      Quantidade { get; set; }
        public double   Valor      { get; set; }
        public double   valorTotal { get; set; }
    }

}