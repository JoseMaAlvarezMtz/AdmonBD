using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdmonBD.Models
{
    public partial class AdmonContext : DbContext
    {
        public AdmonContext()
        {
        }

        public AdmonContext(DbContextOptions<AdmonContext> options)
            : base(options)
        {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ClaveMateria>(entity =>
            {
                entity.HasKey(e => e.IdClavemateria);

                entity.Property(e => e.IdClavemateria).HasColumnName("Id_clavemateria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreClave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_clave");
            });

            modelBuilder.Entity<Dia>(entity =>
            {
                entity.HasKey(e => e.IdDia);

                entity.Property(e => e.IdDia).HasColumnName("Id_dia");

                entity.Property(e => e.ClaveDia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Clave_dia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Distribucion>(entity =>
            {
                entity.HasKey(e => e.IdDistribucion);

                entity.Property(e => e.IdDistribucion).HasColumnName("Id_distribucion");

                entity.Property(e => e.IdClavemateria).HasColumnName("Id_clavemateria");

                entity.Property(e => e.IdDia).HasColumnName("Id_dia");

                entity.Property(e => e.IdGrupo).HasColumnName("Id_grupo");

                entity.Property(e => e.IdHora).HasColumnName("Id_hora");

                entity.Property(e => e.IdMateria).HasColumnName("Id_materia");

                entity.Property(e => e.IdPlan).HasColumnName("Id_plan");

                entity.Property(e => e.IdSalon).HasColumnName("Id_salon");

                entity.HasOne(d => d.IdClavemateriaNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.IdClavemateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_ClaveMateria");

                entity.HasOne(d => d.IdDiaNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.IdDia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_Dia");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_Grupo");

                entity.HasOne(d => d.IdHoraNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.IdHora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_Hora");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_Materia");

                entity.HasOne(d => d.IdPlanNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.IdPlan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_Plan");

                entity.HasOne(d => d.IdSalonNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.IdSalon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_Salon");

                entity.HasOne(d => d.SemestreNavigation)
                    .WithMany(p => p.Distribucion)
                    .HasForeignKey(d => d.Semestre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Distribucion_Semestre");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.Property(e => e.IdGrupo).HasColumnName("Id_grupo");

                entity.Property(e => e.NumeroGrupo).HasColumnName("Numero_grupo");
            });

            modelBuilder.Entity<Hora>(entity =>
            {
                entity.HasKey(e => e.IdHora);

                entity.Property(e => e.IdHora).HasColumnName("Id_hora");

                entity.Property(e => e.HoraFin).HasColumnName("Hora_fin");

                entity.Property(e => e.HoraInicio).HasColumnName("Hora_inicio");

                entity.Property(e => e.NombreHora)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Hora");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.IdMateria);

                entity.Property(e => e.IdMateria).HasColumnName("Id_materia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreMateria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_materia");
            });

            modelBuilder.Entity<PlanEstudios>(entity =>
            {
                entity.HasKey(e => e.IdPlan)
                    .HasName("PK_Plan");

                entity.Property(e => e.IdPlan).HasColumnName("Id_plan");

                entity.Property(e => e.ClavePlan).HasColumnName("Clave_plan");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Salon>(entity =>
            {
                entity.HasKey(e => e.IdSalon);

                entity.Property(e => e.IdSalon).HasColumnName("Id_salon");

                entity.Property(e => e.NombreSalon)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_salon");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semestre>(entity =>
            {
                entity.HasKey(e => e.Semestre1);

                entity.Property(e => e.Semestre1)
                    .ValueGeneratedNever()
                    .HasColumnName("Semestre");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
