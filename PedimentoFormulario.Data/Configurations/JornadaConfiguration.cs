using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Jornada utilizando Fluent API
    /// </summary>
    public class JornadaConfiguration : IEntityTypeConfiguration<Jornada>
    {
        public void Configure(EntityTypeBuilder<Jornada> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_jornadas");

            // Clave primaria
            builder.HasKey(j => j.CodJornada);

            // Propiedades
            builder.Property(j => j.CodJornada)
                .HasColumnName("cod_jornada")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(j => j.NombreJornada)
                .HasColumnName("jornada")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(j => j.Detalles)
                .HasColumnName("detalles")
                .HasMaxLength(3000);

            builder.Property(j => j.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(j => j.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20);

            builder.Property(j => j.FechaReg)
                .HasColumnName("fechareg");

            builder.Property(j => j.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20);

            builder.Property(j => j.FechaMod)
                .HasColumnName("fechamod");

            // Relaciones
            builder.HasMany(j => j.SolicitudesPedimento)
                .WithOne(s => s.Jornada)
                .HasForeignKey(s => s.CodJornada)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

