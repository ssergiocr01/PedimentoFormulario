using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class SubEspecialidadConfiguration : IEntityTypeConfiguration<SubEspecialidad>
    {
        public void Configure(EntityTypeBuilder<SubEspecialidad> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con Especialidad (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Especialidad)
                .WithMany(e => e.SubEspecialidades)
                .HasForeignKey(x => x.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.SubEspecialidad)
                .HasForeignKey(s => new { s.CodSubEspecialidad, s.CodEspecialidad })
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.CodEspecialidad);
            builder.HasIndex(x => x.NombreSubespecialidad);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreSubespecialidad)
                .IsUnicode(false);

            builder.Property(x => x.Observaciones)
                .IsUnicode(false);

            builder.Property(x => x.Resolucion)
                .IsUnicode(false);

            builder.Property(x => x.Gaceta)
                .IsUnicode(false);

            builder.Property(x => x.Nota)
                .IsUnicode(false);

            // Configuración para el campo Activo que es nullable
            builder.Property(x => x.Activo)
                .HasDefaultValue(true);

            // Configuración para campos de auditoría que son nullables
            builder.Property(x => x.FechaReg)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}