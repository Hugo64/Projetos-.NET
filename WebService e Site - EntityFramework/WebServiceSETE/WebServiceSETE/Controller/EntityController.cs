using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceSETE.BdSete;
using WebServiceSETE.Model;

namespace WebServiceSETE.Controller
{
    public class EntityController : Servico
    {
        public static int AdicionarEndereco(Endereco endereco)
        {
            return TB_Endereco(new ST_Endereco()
            {
                C_Estado = endereco.C_Estado,
                C_Cidade = endereco.C_Cidade,
                C_Bairro = endereco.C_Bairro,
                C_Rua = endereco.C_Rua,
                C_Numero = endereco.C_Numero,
                C_Referencia = endereco.C_Referencia
            });
        }

        public static bool AdicionarEmpresa(Empresa empresa)
        {
            return TB_Empresa(new ST_Empresa()
            {
                C_Nome = empresa.C_Nome,
                C_Cnpj = empresa.C_Cnpj,
                fk_id_Endereco = empresa.endereco.id
            });
        }

        public static bool AdicionarCliente(Cliente cliente)
        {
            return TB_Cliente(new ST_Cliente()
                {
                    C_Nome = cliente.C_Nome,
                    C_Identidade = cliente.C_Identidade,
                    C_Cpf = cliente.C_Cpf,
                    C_Identificacao = cliente.C_Identificacao,
                    C_Contato = cliente.C_Contato,
                    C_Email = cliente.C_Email,
                    fk_id_Endereco = cliente.endereco.id
                });
        }

        public static bool AdicionarPassagem(Passagem passagem)
        {
            return TB_Passagem(new ST_Passagem()
            {
                C_Poltrona = passagem.C_Poltrona,
                C_Numeracao = passagem.C_Numeracao,
                B_Cancelar = passagem.B_Cancelar,
                fk_id_Empresa = passagem.empresa.id,
                fk_id_Endereco_Destino = passagem.endereco.id,
                fk_id_Cliente = passagem.cliente.id
            });
        }

        public static Passagem Buscar_Passagem_Do_Cliente(string Cpf)
        {
            return Buscar_Passagem_Por_Cliente(Cpf);
        }
    }
}