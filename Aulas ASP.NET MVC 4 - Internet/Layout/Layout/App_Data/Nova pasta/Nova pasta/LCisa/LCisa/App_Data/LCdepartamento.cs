//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LCisa.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class LCdepartamento
    {
        public LCdepartamento()
        {
            this.C_Cargo = "\"NULL\"";
            this.C_Carteira = "\"NULL\"";
            this.I_Salario = 0D;
            this.LCfuncionario = new HashSet<LCfuncionario>();
        }
    
        public short id { get; set; }
        public string C_Cargo { get; set; }
        public string C_Carteira { get; set; }
        public Nullable<double> I_Salario { get; set; }
    
        public virtual ICollection<LCfuncionario> LCfuncionario { get; set; }
    }
}
