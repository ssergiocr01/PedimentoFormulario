using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class CantonConfiguration : IEntityTypeConfiguration<Canton>
    {
        public void Configure(EntityTypeBuilder<Canton> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con Provincia (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Provincia)
                .WithMany(p => p.Cantones)
                .HasForeignKey(x => x.CodProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Distritos (colección)
            builder.HasMany(x => x.Distritos)
                .WithOne(d => d.Canton)
                .HasForeignKey(d => new { d.CodCanton, d.CodProvincia })
                .OnDelete(DeleteBehavior.Cascade);

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Canton)
                .HasForeignKey(s => new { s.CodCanton, s.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.CodProvincia);
            builder.HasIndex(x => x.NombreCanton);

            // Configuración adicional para la propiedad NombreCanton
            // Esto es opcional, ya que ya está configurado con Data Annotations
            // pero podemos agregar configuraciones adicionales como:
            builder.Property(x => x.NombreCanton)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS"); // Ejemplo: configurar collation
        }
    }
}