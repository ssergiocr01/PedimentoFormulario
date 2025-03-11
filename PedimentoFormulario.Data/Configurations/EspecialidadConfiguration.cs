using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con SubEspecialidades (colección)
            builder.HasMany(x => x.SubEspecialidades)
                .WithOne(s => s.Especialidad)
                .HasForeignKey(s => s.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Especialidad)
                .HasForeignKey(s => s.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.NombreEspecialidad);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreEspecialidad)
                .IsUnicode(false);

            builder.Property(x => x.Observaciones)
                .IsUnicode(false);

            builder.Property(x => x.Resolucion)
                .IsUnicode(false);

            builder.Property(x => x.Gaceta)
                .IsUnicode(false);

            builder.Property(x => x.Observ)
                .IsUnicode(false);

            // Configuración para el campo Activo que es nullable
            builder.Property(x => x.Activo)
                .HasDefaultValue(true);
        }
    }
}