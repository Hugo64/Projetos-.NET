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
    
    public partial class LCsistema
    {
        public LCsistema()
        {
            this.C_Login = "\"NULL\"";
            this.C_Senha = "\"NULL\"";
            this.L_Bloqueado = 0;
            this.LCfuncionario = new HashSet<LCfuncionario>();
        }
    
        public short id { get; set; }
        public string C_Login { get; set; }
        public string C_Senha { get; set; }
        public Nullable<int> L_Bloqueado { get; set; }
    
        public virtual ICollection<LCfuncionario> LCfuncionario { get; set; }
    }
}
