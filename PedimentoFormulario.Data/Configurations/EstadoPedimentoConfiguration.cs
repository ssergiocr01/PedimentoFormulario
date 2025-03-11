using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class EstadoPedimentoConfiguration : IEntityTypeConfiguration<EstadoPedimento>
    {
        public void Configure(EntityTypeBuilder<EstadoPedimento> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con EstadoParaPedimento (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.EstadoParaPedimento)
                .WithMany(e => e.EstadosPedimento)
                .HasForeignKey(x => x.CodEstado)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudPedimento (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.SolicitudPedimento)
                .WithMany(s => s.EstadosPedimento)
                .HasForeignKey(x => x.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.CodEstado);
            builder.HasIndex(x => x.Pedimento);
            builder.HasIndex(x => x.FechaRige);
            builder.HasIndex(x => x.FechaVence);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.Observaciones)
                .IsUnicode(false);

            builder.Property(x => x.Anexo)
                .IsUnicode(false);

            // Configuración para el campo Activo que es nullable
            builder.Property(x => x.Activo)
                .HasDefaultValue(true);
        }
    }
}