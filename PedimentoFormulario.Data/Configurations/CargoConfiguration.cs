using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            // No necesitamos configurar la tabla, clave primaria, ni propiedades básicas
            // ya que están definidas con Data Annotations en la entidad

            // Configuración de relaciones

            // Relación con Clase (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Clase)
                .WithMany()
                .HasForeignKey(x => x.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con Institucion (ya definida con [ForeignKey] pero configuramos comportamiento)
            builder.HasOne(x => x.Institucion)
                .WithMany()
                .HasForeignKey(x => x.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con ManualCargo (no definida con Data Annotations)
            // Nota: Esta relación está comentada en la entidad, la incluyo como ejemplo
            // pero debería implementarse cuando exista la entidad ManualCargo
            /*
            builder.HasOne<ManualCargo>()
                .WithMany()
                .HasForeignKey(x => new { x.CodManual, x.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);
            */

            // Relación con SolicitudesPedimento (colección)
            builder.HasMany(x => x.SolicitudesPedimento)
                .WithOne(s => s.Cargo)
                .HasForeignKey(s => s.CodCargo)
                .OnDelete(DeleteBehavior.Restrict);

            // Índices para mejorar el rendimiento
            builder.HasIndex(x => x.CodClase);
            builder.HasIndex(x => x.CodInstitucion);
            builder.HasIndex(x => x.CodManual);
            builder.HasIndex(x => x.NombreCargo)
                .HasDatabaseName("IX_Cargo_NombreCargo");

            // Configuración adicional para la propiedad NombreCargo
            builder.Property(x => x.NombreCargo)
                .IsUnicode(false); // Configurar como no Unicode para optimizar almacenamiento
        }
    }
}