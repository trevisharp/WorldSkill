//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace back
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbDepartamento
    {
        public tbDepartamento()
        {
            this.tbReservas = new HashSet<tbReservas>();
            this.tbUsuarios = new HashSet<tbUsuarios>();
        }
    
        public int id { get; set; }
        public string nome { get; set; }
    
        public virtual ICollection<tbReservas> tbReservas { get; set; }
        public virtual ICollection<tbUsuarios> tbUsuarios { get; set; }
    }
}
