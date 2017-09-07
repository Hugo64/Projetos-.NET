using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceSETE.Model
{
    public class Cliente
    {
        public int id { get; set; }
        public string C_Nome { get; set; }
        public string C_Identidade { get; set; }
        public string C_Cpf { get; set; }
        public string C_Identificacao { get; set; }
        public string C_Contato { get; set; }
        public string C_Email { get; set; }

        public Endereco endereco { get; set; }
    }
}