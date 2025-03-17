using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Provincia utilizando Fluent API
    /// </summary>
    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_DGSC_provincias");

            // Clave primaria
            builder.HasKey(p => p.CodProvincia);

            // Propiedades
            builder.Property(p => p.CodProvincia)
                .HasColumnName("cod_provincia")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(p => p.NombreProvincia)
                .HasColumnName("provincia")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(p => p.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(p => p.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(p => p.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasMany(p => p.Cantones)
                .WithOne(c => c.Provincia)
                .HasForeignKey(c => c.CodProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.SolicitudesPedimento)
                .WithOne(s => s.Provincia)
                .HasForeignKey(s => s.CodProvincia)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

