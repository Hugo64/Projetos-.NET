using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceSETE.Model
{
    public class Passagem
    {
        public int id { get; set; }
        public string C_Poltrona { get; set; }
        public string C_Numeracao { get; set; }
        public Nullable<byte> B_Cancelar { get; set; }

        public Cliente cliente { get; set; }
        public Empresa empresa { get; set; }
        public Endereco endereco { get; set; }
    }
}