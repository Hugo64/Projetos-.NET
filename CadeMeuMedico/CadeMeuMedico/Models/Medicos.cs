//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CadeMeuMedico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medicos
    {
        public int id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        public bool antendePorConvenio { get; set; }
        public bool temClinica { get; set; }
        public string webSiteBlog { get; set; }
        public int Cidades_id { get; set; }
        public int Especialidades_id { get; set; }
    
        public virtual Cidades Cidades { get; set; }
        public virtual Especialidades Especialidades { get; set; }
    }
}