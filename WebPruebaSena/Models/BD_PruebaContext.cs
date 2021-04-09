using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebPruebaSena.Models
{
    public partial class BD_PruebaContext : DbContext
    {
        public BD_PruebaContext()
        {
        }

        public BD_PruebaContext(DbContextOptions<BD_PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=BD_Prueba; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.ToTable("roles");

                entity.Property(e => e.RolId)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("rol_id");

                entity.Property(e => e.RolDescripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("rol_descripcion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("usuario_id");

                entity.Property(e => e.UsuarioApellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario_apellidos");

                entity.Property(e => e.UsuarioContrasena)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("usuario_contrasena");

                entity.Property(e => e.UsuarioDireccion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario_direccion");

                entity.Property(e => e.UsuarioEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("usuario_email");

                entity.Property(e => e.UsuarioNombres)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario_nombres");

                entity.Property(e => e.UsuarioRol)
                    .HasColumnType("numeric(5, 0)")
                    .HasColumnName("usuario_rol");

                entity.Property(e => e.UsuarioTelefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario_telefono");

                entity.Property(e => e.UsuarioTipoId)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("usuario_tipo_id")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
