using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class InstitucionConfiguration : IEntityTypeConfiguration<Institucion>
    {
        public void Configure(EntityTypeBuilder<Institucion> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con Dependencias (colección)
            builder.HasMany(x => x.Dependencias)
                .WithOne(d => d.Institucion)
                .HasForeignKey(d => d.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Departamentos (colección)
            builder.HasMany(x => x.Departamentos)
                .WithOne(d => d.Institucion)
                .HasForeignKey(d => d.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Institucion)
                .HasForeignKey(s => s.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.NombreInstitucion);
            builder.HasIndex(x => x.Sigla);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreInstitucion)
                .IsUnicode(false);

            builder.Property(x => x.Sigla)
                .IsUnicode(false);
        }
    }
}