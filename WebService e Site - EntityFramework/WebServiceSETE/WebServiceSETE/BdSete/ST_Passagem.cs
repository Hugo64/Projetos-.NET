//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceSETE.BdSete
{
    using System;
    using System.Collections.Generic;
    
    public partial class ST_Passagem
    {
        public int id { get; set; }
        public string C_Poltrona { get; set; }
        public string C_Numeracao { get; set; }
        public Nullable<byte> B_Cancelar { get; set; }
        public int fk_id_Empresa { get; set; }
        public int fk_id_Endereco_Destino { get; set; }
        public int fk_id_Cliente { get; set; }
    
        public virtual ST_Cliente ST_Cliente { get; set; }
        public virtual ST_Empresa ST_Empresa { get; set; }
        public virtual ST_Endereco ST_Endereco { get; set; }
    }
}
