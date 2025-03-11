using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class SolicitudPedimentoPersonalConfiguration : IEntityTypeConfiguration<SolicitudPedimentoPersonal>
    {
        public void Configure(EntityTypeBuilder<SolicitudPedimentoPersonal> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuraciones de relaciones complejas

            // Relaciones institucionales
            builder.HasOne(x => x.Dependencia)
                .WithMany(d => d.SolicitudesPedimento)
                .HasForeignKey(x => new { x.CodDependencia, x.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Departamento)
                .WithMany(d => d.SolicitudesPedimento)
                .HasForeignKey(x => new { x.CodDepartamento, x.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones de clasificación
            builder.HasOne(x => x.ClaseGenerica)
                .WithMany(c => c.SolicitudesPedimento)
                .HasForeignKey(x => new { x.CodClaseGen, x.CodEstrato })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SubEspecialidad)
                .WithMany(s => s.SolicitudesPedimento)
                .HasForeignKey(x => new { x.CodSubEspecialidad, x.CodEspecialidad })
                .OnDelete(DeleteBehavior.Restrict);

            // Relaciones de división territorial
            builder.HasOne(x => x.Canton)
                .WithMany(c => c.SolicitudesPedimento)
                .HasForeignKey(x => new { x.CodCanton, x.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Distrito)
                .WithMany(d => d.SolicitudesPedimento)
                .HasForeignKey(x => new { x.CodDistrito, x.CodCanton, x.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de colecciones
            builder.HasMany(x => x.FirmasPedimento)
                .WithOne(f => f.SolicitudPedimento)
                .HasForeignKey(f => f.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.EstadosPedimento)
                .WithOne(e => e.SolicitudPedimento)
                .HasForeignKey(e => e.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TareasPuesto)
                .WithOne(t => t.SolicitudPedimento)
                .HasForeignKey(t => t.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => new { x.CodInstitucion, x.CodDependencia });
            builder.HasIndex(x => x.NumPuesto);
            builder.HasIndex(x => x.CodClase);
            builder.HasIndex(x => x.CodEspecialidad);
            builder.HasIndex(x => x.CodCargo);
            builder.HasIndex(x => x.CodMotivo);
            builder.HasIndex(x => new { x.CodProvincia, x.CodCanton, x.CodDistrito });
            builder.HasIndex(x => x.CodJornada);
            builder.HasIndex(x => x.CodHorario);
            builder.HasIndex(x => x.Anno);
            builder.HasIndex(x => x.Consecutivo);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.IntNombre)
                .IsUnicode(false);

            builder.Property(x => x.EspecDestacado)
                .IsUnicode(false);

            builder.Property(x => x.EspecTraslado)
                .IsUnicode(false);

            builder.Property(x => x.Observaciones)
                .IsUnicode(false);

            builder.Property(x => x.DetallesResolucion)
                .IsUnicode(false);

            builder.Property(x => x.Detalles)
                .IsUnicode(false);

            builder.Property(x => x.ObservacionesPed)
                .IsUnicode(false);

            builder.Property(x => x.ObservacionesConcursoInt)
                .IsUnicode(false);
        }
    }
}