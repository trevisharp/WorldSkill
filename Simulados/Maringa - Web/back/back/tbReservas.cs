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
    
    public partial class tbReservas
    {
        public int id { get; set; }
        public Nullable<int> id_veiculo { get; set; }
        public Nullable<System.DateTime> data_saida { get; set; }
        public Nullable<System.DateTime> data_retorno { get; set; }
        public string destino { get; set; }
        public string condutor { get; set; }
        public Nullable<int> id_departamento { get; set; }
        public string motivo { get; set; }
    
        public virtual tbDepartamento tbDepartamento { get; set; }
        public virtual tbVeiculos tbVeiculos { get; set; }
    }
}
