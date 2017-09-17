using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LCisa.App_Data;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Web.Security;

namespace LCisa.Models
{
    public class Metodos : MySQL
    {

        public bool adicionarFuncionario(LCendereco E, LCdepartamento D, LCsistema S, LCfuncionario F, LCvendedor V)
        {
            if (verificarFuncionarioEFornecedor(F.C_Cpf))
            {
                return false;
            }
            else
            {
                try
                {
                    db.LCendereco.Add(E);
                    db.SaveChanges();

                    db.LCdepartamento.Add(D);
                    db.SaveChanges();

                    var senhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(S.C_Senha, "sha1");
                    S.C_Senha = senhaCriptografada;

                    db.LCsistema.Add(S);
                    db.SaveChanges();

                    F.LCendereco_id = E.id;
                    F.LCdepartamento_id = D.id;
                    F.LCsistema_id = S.id;

                    db.LCfuncionario.Add(F);
                    db.SaveChanges();

                    if (V.I_Bonificacao != 0)
                    {
                        V.LCfuncionario_id = F.id;

                        db.LCvendedor.Add(V);
                        db.SaveChanges();
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public bool adicionarFornecedor(LCendereco E, LCfuncionario F, LCfornecedor FO)
        {
            LCdepartamento D = new LCdepartamento();
            LCsistema S = new LCsistema();

            if (verificarFuncionarioEFornecedor(F.C_Cpf))
            {
                return false;
            }
            else
            {
                try
                { 
                    db.LCendereco.Add(E);
                    db.SaveChanges();

                    db.LCdepartamento.Add(D);
                    db.SaveChanges();

                    db.LCsistema.Add(S);
                    db.SaveChanges();

                    F.LCendereco_id = E.id;
                    F.LCdepartamento_id = D.id;
                    F.LCsistema_id = S.id;

                    db.LCfuncionario.Add(F);
                    db.SaveChanges();

                    FO.LCfuncionario_id = F.id;

                    db.LCfornecedor.Add(FO);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private bool verificarFuncionarioEFornecedor(string Cpf)
        {
            var Funcionario = db.LCfuncionario.FirstOrDefault(x => x.C_Cpf == Cpf);
            if (Funcionario != null)
            {
                return true;
            }
            return false;
        }

        public bool AdicionarProduto(LCproduto P)
        {
            if (verificarProduto(P.I_CodBarra))
            {
                return false;
            }
            else
            {
                try
                {
                    db.LCproduto.Add(P);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private bool verificarProduto(int Codigo)
        {
            var Produto = db.LCproduto.FirstOrDefault(x => x.I_CodBarra == Codigo);
            if (Produto != null)
            {
                return true;
            }
                return false;
        }

    }
}
