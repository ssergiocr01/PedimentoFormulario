using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class SolicitudAPedimentoConfiguration : IEntityTypeConfiguration<SolicitudAPedimento>
    {
        public void Configure(EntityTypeBuilder<SolicitudAPedimento> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con SolicitudPedimento (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.SolicitudPedimento)
                .WithMany()
                .HasForeignKey(x => x.Pedimento)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Institucion (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Institucion)
                .WithMany()
                .HasForeignKey(x => x.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con MotivoVacante (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.MotivoVacante)
                .WithMany(m => m.SolicitudesAPedimento)
                .HasForeignKey(x => x.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.Pedimento);
            builder.HasIndex(x => x.CodInstitucion);
            builder.HasIndex(x => x.CodMotivo);
            builder.HasIndex(x => x.CodEstado);
            builder.HasIndex(x => x.FechaFin);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.Justificacion)
                .IsUnicode(false);
        }
    }
}