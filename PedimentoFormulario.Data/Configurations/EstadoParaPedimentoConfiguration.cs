using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class EstadoParaPedimentoConfiguration : IEntityTypeConfiguration<EstadoParaPedimento>
    {
        public void Configure(EntityTypeBuilder<EstadoParaPedimento> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con EstadosPedimento (colección)
            builder.HasMany(x => x.EstadosPedimento)
                .WithOne(e => e.EstadoParaPedimento)
                .HasForeignKey(e => e.CodEstado)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.NombreEstado);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreEstado)
                .IsUnicode(false);

            builder.Property(x => x.Descripcion)
                .IsUnicode(false);
        }
    }
}