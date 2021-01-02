using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace API_ProAgroSeguros.Models
{
    public partial class proagrosegurosContext : DbContext
    {
        public proagrosegurosContext()
        {
        }

        public proagrosegurosContext(DbContextOptions<proagrosegurosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatEstado> CatEstados { get; set; }
        public virtual DbSet<CatGeorreferencia> CatGeorreferencias { get; set; }
        public virtual DbSet<CatUsuario> CatUsuarios { get; set; }
        public virtual DbSet<CatUsuarioEstado> CatUsuarioEstados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-K3BL506;Initial catalog=proagroseguros; user id=sa; password=Dt1h@lO");
                var config = ConfigurationManager.ConnectionStrings["connectionDB"];
                optionsBuilder.UseSqlServer(config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CatEstado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__CAT_ESTA__62EA894ADB24755E");

                entity.ToTable("CAT_ESTADO");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.Acronimo).HasMaxLength(10);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<CatGeorreferencia>(entity =>
            {
                entity.HasKey(e => e.IdGeorreferencias)
                    .HasName("PK__CAT_GEOR__A48E0F8A6975D735");

                entity.ToTable("CAT_GEORREFERENCIAS");

                entity.Property(e => e.IdGeorreferencias).HasColumnName("idGeorreferencias");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.CatGeorreferencia)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__CAT_GEORR__idEst__2D27B809");
            });

            modelBuilder.Entity<CatUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__CAT_USUA__645723A672864E7D");

                entity.ToTable("CAT_USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('abcde')");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.Property(e => e.Rfc)
                    .HasMaxLength(50)
                    .HasColumnName("RFC");
            });

            modelBuilder.Entity<CatUsuarioEstado>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioEstado)
                    .HasName("PK__CAT_USUA__B35D26E1DB4585D6");

                entity.ToTable("CAT_USUARIO_ESTADO");

                entity.Property(e => e.IdUsuarioEstado).HasColumnName("idUsuarioEstado");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.CatUsuarioEstados)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK__CAT_USUAR__idEst__2A4B4B5E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.CatUsuarioEstados)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__CAT_USUAR__idUsu__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
