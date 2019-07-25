using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.Models
{
    public partial class TestContext : DbContext
    {
        //public TestContext()
        //{
        //}

        //public TestContext(DbContextOptions<TestContext> options)
        //    : base(options)
        //{
        //}

        //public virtual DbSet<Accion> Accion { get; set; }
        //public virtual DbSet<Actividad> Actividad { get; set; }
        //public virtual DbSet<Role> Role { get; set; }
        //public virtual DbSet<Usuario> Usuario { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-QFOKER8;Database=Test;Trusted_Connection=True;");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Accion>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.Nombre)
        //            .HasMaxLength(40)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<Actividad>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.Fecha)
        //            .HasColumnName("fecha")
        //            .HasColumnType("datetime");

        //        entity.Property(e => e.IdAccion).HasColumnName("idAccion");

        //        entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

        //        entity.Property(e => e.IdUsuarioAdmin).HasColumnName("idUsuarioAdmin");

        //        entity.HasOne(d => d.IdAccionNavigation)
        //            .WithMany(p => p.Actividad)
        //            .HasForeignKey(d => d.IdAccion)
        //            .HasConstraintName("FK__Actividad__idAcc__2C3393D0");

        //        entity.HasOne(d => d.IdUsuarioAdminNavigation)
        //            .WithMany(p => p.Actividad)
        //            .HasForeignKey(d => d.IdUsuarioAdmin)
        //            .HasConstraintName("FK__Actividad__idUsu__2B3F6F97");
        //    });

        //    modelBuilder.Entity<Role>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);

        //        entity.Property(e => e.Id).HasColumnName("idRole");

        //        entity.Property(e => e.Nombre)
        //            .HasMaxLength(40)
        //            .IsUnicode(false);
        //    });

        //    modelBuilder.Entity<Usuario>(entity =>
        //    {
        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.Apellido)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Direccion)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.IdRole).HasColumnName("idRole");

        //        entity.Property(e => e.Nombre)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Password)
        //            .HasMaxLength(250)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Telefono)
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Usuario1)
        //            .HasColumnName("Usuario")
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.HasOne(d => d.IdRoleNavigation)
        //            .WithMany(p => p.Usuario)
        //            .HasForeignKey(d => d.IdRole)
        //            .HasConstraintName("FK__Usuario__idRole__25869641");
        //    });
        //}
    }
}
