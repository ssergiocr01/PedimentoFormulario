using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class ClaseConfiguration : IEntityTypeConfiguration<Clase>
    {
        public void Configure(EntityTypeBuilder<Clase> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con ClaseGenerica (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.ClaseGenerica)
                .WithMany()
                .HasForeignKey(x => new { x.CodEstrato, x.CodClaseGen })
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Institucion (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Institucion)
                .WithMany()
                .HasForeignKey(x => x.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Clase)
                .HasForeignKey(s => s.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Cargos (colección)
            builder.HasMany(x => x.Cargos)
                .WithOne(c => c.Clase)
                .HasForeignKey(c => c.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.CodEstrato);
            builder.HasIndex(x => x.CodClaseGen);
            builder.HasIndex(x => x.CodInstitucion);
            builder.HasIndex(x => x.TituloDeLaClase);
            builder.HasIndex(x => x.Grupo);
            builder.HasIndex(x => x.NivelSalarial);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.TituloDeLaClase)
                .IsUnicode(false);

            builder.Property(x => x.Resolucion)
                .IsUnicode(false);

            builder.Property(x => x.Gaceta)
                .IsUnicode(false);
        }
    }
}