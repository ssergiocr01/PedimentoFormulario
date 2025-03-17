using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Dependencia utilizando Fluent API
    /// </summary>
    public class DependenciaConfiguration : IEntityTypeConfiguration<Dependencia>
    {
        public void Configure(EntityTypeBuilder<Dependencia> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_DGSC_dependencias");

            // Clave primaria compuesta
            builder.HasKey(d => new { d.CodDependencia, d.CodInstitucion });

            // Propiedades
            builder.Property(d => d.CodDependencia)
                .HasColumnName("cod_dependencia")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(d => d.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(d => d.NombreDependencia)
                .HasColumnName("dependencia")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(d => d.Detalles)
                .HasColumnName("detalles")
                .HasMaxLength(3000);

            builder.Property(d => d.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(d => d.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(d => d.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasOne(d => d.Institucion)
                .WithMany(i => i.Dependencias)
                .HasForeignKey(d => d.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.SolicitudesPedimento)
                .WithOne(s => s.Dependencia)
                .HasForeignKey(s => new { s.CodDependencia, s.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

