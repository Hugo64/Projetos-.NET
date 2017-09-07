using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebServiceSETE.BdSete;

namespace WebServiceSETE.Model
{
    public class Servico
    {
        protected static int TB_Endereco(ST_Endereco Endereco)
        {
            using (BdSeteEntities bd = new BdSeteEntities())
            {
                try
                {
                    bd.ST_Endereco.Add(Endereco);
                    bd.SaveChanges();
                    return Endereco.id;
                }
                catch (Exception Ex)
                {
                    return 0;
                }
            }
        }

        protected static bool TB_Empresa(ST_Empresa Empresa)
        {
            using (BdSeteEntities bd = new BdSeteEntities())
            {
                try
                {
                    bd.ST_Empresa.Add(Empresa);
                    bd.SaveChanges();
                    return true;
                }
                catch(Exception Ex)
                {
                    return false;
                }
            }
        }

        protected static bool TB_Cliente(ST_Cliente Cliente)
        {
            using (BdSeteEntities bd = new BdSeteEntities())
            {
                try
                {
                    bd.ST_Cliente.Add(Cliente);
                    bd.SaveChanges();
                    return true;
                }
                catch (Exception Ex)
                {
                    return false;
                }
            }
        }

        protected static bool TB_Passagem(ST_Passagem Passagem)
        {
            using (BdSeteEntities bd = new BdSeteEntities())
            {
                try
                {
                    bd.ST_Passagem.Add(Passagem);
                    bd.SaveChanges();
                    return true;
                }
                catch (Exception Ex)
                {
                    return false;
                }
            }
        }

        protected static Passagem Buscar_Passagem_Por_Cliente(string Cpf)
        {
            using (BdSeteEntities bd = new BdSeteEntities())
            {
                try
                { 
                    var passagem = bd.ST_Passagem.FirstOrDefault(x => x.ST_Cliente.C_Cpf == Cpf);

                    return new Passagem()
                    {
                        //Dados da passagem
                        C_Poltrona = passagem.C_Poltrona,
                        C_Numeracao = passagem.C_Numeracao,
                        B_Cancelar = passagem.B_Cancelar,

                        //Endereço de destino da passagem
                        endereco = new Endereco()
                        {
                            C_Estado = passagem.ST_Endereco.C_Estado,
                            C_Cidade = passagem.ST_Endereco.C_Cidade,
                            C_Bairro = passagem.ST_Endereco.C_Bairro,
                            C_Rua = passagem.ST_Endereco.C_Rua,
                            C_Numero = passagem.ST_Endereco.C_Numero,
                            C_Referencia = passagem.ST_Endereco.C_Referencia
                        },

                        //Dados da empresa que forneceu a passagem
                        empresa = new Empresa()
                        {
                            C_Nome = passagem.ST_Empresa.C_Nome,
                            C_Cnpj = passagem.ST_Empresa.C_Cnpj,

                            endereco = new Endereco()
                            {
                                C_Estado = passagem.ST_Empresa.ST_Endereco.C_Estado,
                                C_Cidade = passagem.ST_Empresa.ST_Endereco.C_Cidade,
                                C_Bairro = passagem.ST_Empresa.ST_Endereco.C_Bairro,
                                C_Rua = passagem.ST_Empresa.ST_Endereco.C_Rua,
                                C_Numero = passagem.ST_Empresa.ST_Endereco.C_Numero,
                                C_Referencia = passagem.ST_Empresa.ST_Endereco.C_Referencia
                            }
                        },

                        //Dados do cliente da passagem
                        cliente = new Cliente()
                        {
                            C_Nome = passagem.ST_Cliente.C_Nome,
                            C_Cpf =  passagem.ST_Cliente.C_Cpf,
                            C_Identidade = passagem.ST_Cliente.C_Identidade,
                            C_Contato = passagem.ST_Cliente.C_Contato,
                            C_Identificacao = passagem.ST_Cliente.C_Identificacao,
                            C_Email =  passagem.ST_Cliente.C_Email,

                            endereco = new Endereco()
                            {
                                C_Estado = passagem.ST_Cliente.ST_Endereco.C_Estado,
                                C_Cidade = passagem.ST_Cliente.ST_Endereco.C_Cidade,
                                C_Bairro =  passagem.ST_Cliente.ST_Endereco.C_Bairro,
                                C_Rua = passagem.ST_Cliente.ST_Endereco.C_Rua,
                                C_Numero = passagem.ST_Cliente.ST_Endereco.C_Numero,
                                C_Referencia = passagem.ST_Cliente.ST_Endereco.C_Referencia
                            }
                        }
                    };
                }
                catch(Exception Ex)
                {
                    return null;
                }
            }
        }
    }
}