using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class EstratoConfiguration : IEntityTypeConfiguration<Estrato>
    {
        public void Configure(EntityTypeBuilder<Estrato> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con ClasesGenericas (colección)
            builder.HasMany(x => x.ClasesGenericas)
                .WithOne(c => c.Estrato)
                .HasForeignKey(c => c.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Estrato)
                .HasForeignKey(s => s.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.NombreEstrato);
            builder.HasIndex(x => x.FechaGaceta);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreEstrato)
                .IsUnicode(false);

            builder.Property(x => x.DescEstratos)
                .IsUnicode(false);

            builder.Property(x => x.Resolucion)
                .IsUnicode(false);

            builder.Property(x => x.Gaceta)
                .IsUnicode(false);

            builder.Property(x => x.VinculoDocPfd)
                .IsUnicode(false);
        }
    }
}