//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DistribucionDeMateriasEntities : DbContext
    {
        public DistribucionDeMateriasEntities()
            : base("name=DistribucionDeMateriasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClaveMateria> ClaveMateria { get; set; }
        public virtual DbSet<Dia> Dia { get; set; }
        public virtual DbSet<Distribucion> Distribucion { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }
        public virtual DbSet<Hora> Hora { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<PlanEstudios> PlanEstudios { get; set; }
        public virtual DbSet<Salon> Salon { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
