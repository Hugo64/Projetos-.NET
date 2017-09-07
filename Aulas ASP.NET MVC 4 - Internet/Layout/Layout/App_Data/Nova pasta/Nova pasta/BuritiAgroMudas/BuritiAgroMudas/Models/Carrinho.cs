using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;

namespace BuritiAgroMudas.Models
{
    public class Carrinho
    {
        HttpContext Sessao = HttpContext.Current;

        public string id { get; set; }
        public string descricao { get; set; }
        public double preco { get; set; }
        public int quantidade { get; set; }
        public double valorTotal { get; set; }
        List<Carrinho> produtos = new List<Carrinho>();

        public bool addProdutos(Carrinho p)
        {
            if (Sessao.Session["listaProdutos"] == null)
            {
                p.id = buscarProduto(p.descricao).id;
                p.preco = buscarProduto(p.descricao).preco;
                p.valorTotal = p.preco;
                produtos.Add(p);
                Sessao.Session.Add("listaProdutos", produtos);
                return true;
            }
            else
            {
                List<Carrinho> listaProdutos = (List<Carrinho>)Sessao.Session["listaProdutos"];
                var produto = listaProdutos.FirstOrDefault(x => x.descricao == p.descricao);
                if (produto == null)
                {
                    p.id = buscarProduto(p.descricao).id;
                    p.preco = buscarProduto(p.descricao).preco;
                    p.valorTotal = p.preco;
                    listaProdutos.Add(p);
                    Sessao.Session.Add("listaProdutos", listaProdutos);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void excluirProduto(string descricao)
        {
            List<Carrinho> listaProdutos = (List<Carrinho>)Sessao.Session["listaProdutos"];
            var produto = listaProdutos.FirstOrDefault(x => x.descricao == descricao);
            listaProdutos.Remove(produto);
            Sessao.Session.Add("listaProdutos", listaProdutos);
        }

        public List<Carrinho> exibirProdutos()
        {
            List<Carrinho> listaProdutos1 = (List<Carrinho>)Sessao.Session["listaProdutos"];
            if (listaProdutos1 == null)
            {
                Sessao.Session.Add("listaProdutos", produtos);
                List<Carrinho> listaProdutos2 = (List<Carrinho>)Sessao.Session["listaProdutos"];
                return listaProdutos2;
            }
            else
            {
                return listaProdutos1;
            }
        }

        public Carrinho aumentarQuantidade(string descricao, int quantidade, string opcao)
        {
            List<Carrinho> listaProdutos = (List<Carrinho>)Sessao.Session["listaProdutos"];
            var produto = listaProdutos.FirstOrDefault(x => x.descricao == descricao);

            if (opcao == "+")
            {
                produto.quantidade += quantidade;
            }
            else if (opcao == "-")
            {
                if (produto.quantidade != 1)
                    produto.quantidade -= quantidade;
            }
            else if (opcao == "quantidadeDefinida")
            {
                produto.quantidade = quantidade;
            }
            produto.valorTotal = (produto.preco * produto.quantidade);
            Sessao.Session.Add("listaProdutos", listaProdutos);
            return produto;
        }

        public string valorTodosProdutos()
        {
            List<Carrinho> listaProdutos = (List<Carrinho>)Sessao.Session["listaProdutos"];
            double valorTotalProdutos = listaProdutos.Sum(x => x.valorTotal);
            return valorTotalProdutos.ToString("0.00");
        }

        private Carrinho buscarProduto(string descricao)
        {
            Conexao conexao = new Conexao();
            conexao.abrirConexao();
            conexao.Comando.Connection = conexao.Conectado;
            conexao.Comando.CommandText = "select id, D_Preco from Produto_Preco where C_Descricao = @C_Descricao";
            conexao.Comando.Parameters.Clear();
            conexao.Comando.Parameters.Add("C_Descricao", MySqlDbType.VarChar);
            conexao.Comando.Parameters["@C_Descricao"].Value = descricao;
            conexao.Reader = conexao.Comando.ExecuteReader();
            if (conexao.Reader.HasRows)
            {
                conexao.Reader.Read();
                Carrinho carrinho = new Carrinho();
                carrinho.preco = Convert.ToDouble(conexao.Reader["D_Preco"].ToString());
                carrinho.id = conexao.Reader["id"].ToString();
                return carrinho;
            }
            conexao.Reader.Close();
            conexao.fecharConexao();
            return null;
        }
    }
}