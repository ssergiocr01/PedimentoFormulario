using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class MotivoVacanteConfiguration : IEntityTypeConfiguration<MotivoVacante>
    {
        public void Configure(EntityTypeBuilder<MotivoVacante> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.MotivoVacante)
                .HasForeignKey(s => s.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesAPedimento (colección)
            builder.HasMany(x => x.SolicitudesAPedimento)
                .WithOne(s => s.MotivoVacante)
                .HasForeignKey(s => s.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.NombreMotivo);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreMotivo)
                .IsUnicode(false);

            builder.Property(x => x.Detalles)
                .IsUnicode(false);

            // Configuración para campos de auditoría que son nullables
            builder.Property(x => x.FechaReg)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}