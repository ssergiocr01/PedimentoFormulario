using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class DependenciaConfiguration : IEntityTypeConfiguration<Dependencia>
    {
        public void Configure(EntityTypeBuilder<Dependencia> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con Institucion (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Institucion)
                .WithMany()
                .HasForeignKey(x => x.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Dependencia)
                .HasForeignKey(s => new { s.CodDependencia, s.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.CodInstitucion);
            builder.HasIndex(x => x.NombreDependencia);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreDependencia)
                .IsUnicode(false);

            builder.Property(x => x.Detalles)
                .IsUnicode(false);
        }
    }
}