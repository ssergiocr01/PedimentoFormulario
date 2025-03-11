using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class ClaseGenericaConfiguration : IEntityTypeConfiguration<ClaseGenerica>
    {
        public void Configure(EntityTypeBuilder<ClaseGenerica> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con Estrato (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Estrato)
                .WithMany()
                .HasForeignKey(x => x.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Clases (colección)
            builder.HasMany(x => x.Clases)
                .WithOne(c => c.ClaseGenerica)
                .HasForeignKey(c => new { c.CodEstrato, c.CodClaseGen })
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.ClaseGenerica)
                .HasForeignKey(s => new { s.CodClaseGen, s.CodEstrato })
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.CodEstrato);
            builder.HasIndex(x => x.NombreGenerica);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreGenerica)
                .IsUnicode(false);

            builder.Property(x => x.Resolucion)
                .IsUnicode(false);

            builder.Property(x => x.Gaceta)
                .IsUnicode(false);

            // Configuración para el campo Activo que es nullable
            builder.Property(x => x.Activo)
                .HasDefaultValue(true); // Valor predeterminado
        }
    }
}