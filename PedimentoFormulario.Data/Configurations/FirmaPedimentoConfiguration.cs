using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class FirmaPedimentoConfiguration : IEntityTypeConfiguration<FirmaPedimento>
    {
        public void Configure(EntityTypeBuilder<FirmaPedimento> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con SolicitudPedimento (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.SolicitudPedimento)
                .WithMany(s => s.FirmasPedimento)
                .HasForeignKey(x => x.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.Pedimento);
            builder.HasIndex(x => x.TipoFirma);
            builder.HasIndex(x => x.Nombre);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.Nombre)
                .IsUnicode(false);

            builder.Property(x => x.Observaciones)
                .IsUnicode(false);
        }
    }
}