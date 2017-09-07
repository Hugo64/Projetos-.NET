using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceSETE.Model
{
    public class Empresa
    {
        public int id { get; set; }
        public string C_Nome { get; set; }
        public string C_Cnpj { get; set; }

        public Endereco endereco { get; set; }
    }
}