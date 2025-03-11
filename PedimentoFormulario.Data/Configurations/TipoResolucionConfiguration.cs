using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class TipoResolucionConfiguration : IEntityTypeConfiguration<TipoResolucion>
    {
        public void Configure(EntityTypeBuilder<TipoResolucion> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.TipoResolucion)
                .HasForeignKey(s => s.CodTipoResolucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.NombreTipoResolucion);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreTipoResolucion)
                .IsUnicode(false);

            // Configuración para campos de auditoría que son nullables
            builder.Property(x => x.FechaReg)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}