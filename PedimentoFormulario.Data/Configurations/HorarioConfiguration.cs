using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class HorarioConfiguration : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Horario)
                .HasForeignKey(s => s.CodHorario)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.NombreHorario);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreHorario)
                .IsUnicode(false);

            builder.Property(x => x.Detalles)
                .IsUnicode(false);

            // Configuración para campos de auditoría que son nullables
            builder.Property(x => x.FechaReg)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}