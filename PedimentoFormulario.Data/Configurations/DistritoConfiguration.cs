using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class DistritoConfiguration : IEntityTypeConfiguration<Distrito>
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con Canton (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Canton)
                .WithMany(c => c.Distritos)
                .HasForeignKey(x => new { x.CodCanton, x.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Distrito)
                .HasForeignKey(s => new { s.CodDistrito, s.CodCanton, s.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => new { x.CodCanton, x.CodProvincia });
            builder.HasIndex(x => x.NombreDistrito);

            // Configuración adicional para optimizar almacenamiento
            builder.Property(x => x.NombreDistrito)
                .IsUnicode(false);
        }
    }
}