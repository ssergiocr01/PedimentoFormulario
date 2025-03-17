using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Horario utilizando Fluent API
    /// </summary>
    public class HorarioConfiguration : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_horarios");

            // Clave primaria
            builder.HasKey(h => h.CodHorario);

            // Propiedades
            builder.Property(h => h.CodHorario)
                .HasColumnName("cod_horario")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(h => h.NombreHorario)
                .HasColumnName("horario")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(h => h.Detalles)
                .HasColumnName("detalles")
                .HasMaxLength(145)
                .IsRequired();

            builder.Property(h => h.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(h => h.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20);

            builder.Property(h => h.FechaReg)
                .HasColumnName("fechareg");

            builder.Property(h => h.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20);

            builder.Property(h => h.FechaMod)
                .HasColumnName("fechamod");

            // Relaciones
            builder.HasMany(h => h.SolicitudesPedimento)
                .WithOne(s => s.Horario)
                .HasForeignKey(s => s.CodHorario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

