using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Canton utilizando Fluent API
    /// </summary>
    public class CantonConfiguration : IEntityTypeConfiguration<Canton>
    {
        public void Configure(EntityTypeBuilder<Canton> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_DGSC_cantones");

            // Clave primaria compuesta
            builder.HasKey(c => new { c.CodCanton, c.CodProvincia });

            // Propiedades
            builder.Property(c => c.CodCanton)
                .HasColumnName("cod_canton")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(c => c.CodProvincia)
                .HasColumnName("cod_provincia")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(c => c.NombreCanton)
                .HasColumnName("canton")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(c => c.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(c => c.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(c => c.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasOne(c => c.Provincia)
                .WithMany(p => p.Cantones)
                .HasForeignKey(c => c.CodProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Distritos)
                .WithOne(d => d.Canton)
                .HasForeignKey(d => new { d.CodCanton, d.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SolicitudesPedimento)
                .WithOne(s => s.Canton)
                .HasForeignKey(s => new { s.CodCanton, s.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

