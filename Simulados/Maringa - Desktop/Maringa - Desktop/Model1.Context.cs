﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Maringa___Desktop
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class provaMEntities : DbContext
    {
        public provaMEntities()
            : base("name=provaMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<tbCEP> tbCEP { get; set; }
        public DbSet<tbConsumo> tbConsumo { get; set; }
        public DbSet<tbIMC> tbIMC { get; set; }
        public DbSet<tbTempetura> tbTempetura { get; set; }
    }
}
