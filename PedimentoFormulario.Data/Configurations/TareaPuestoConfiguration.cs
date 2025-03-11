using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class TareaPuestoConfiguration : IEntityTypeConfiguration<TareaPuesto>
    {
        public void Configure(EntityTypeBuilder<TareaPuesto> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con SolicitudPedimento (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.SolicitudPedimento)
                .WithMany(s => s.TareasPuesto)
                .HasForeignKey(x => x.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.Pedimento);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.Tarea)
                .IsUnicode(false);

            builder.Property(x => x.DetalleTarea)
                .IsUnicode(false);

            builder.Property(x => x.Frecuencia)
                .IsUnicode(false);

            // Configuración para campos de auditoría que son nullables
            builder.Property(x => x.FechaReg)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}