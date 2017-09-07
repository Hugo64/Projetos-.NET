using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceSETE.Model
{
    public class Endereco
    {
        public int id { get; set; }
        public string C_Estado { get; set; }
        public string C_Cidade { get; set; }
        public string C_Bairro { get; set; }
        public string C_Rua { get; set; }
        public string C_Numero { get; set; }
        public string C_Referencia { get; set; }
    }
}