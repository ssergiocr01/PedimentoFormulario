using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad ClaseGenerica utilizando Fluent API
    /// </summary>
    public class ClaseGenericaConfiguration : IEntityTypeConfiguration<ClaseGenerica>
    {
        public void Configure(EntityTypeBuilder<ClaseGenerica> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_clasificacion_clase_generica");

            // Clave primaria compuesta
            builder.HasKey(c => new { c.CodClaseGen, c.CodEstrato });

            // Propiedades
            builder.Property(c => c.CodEstrato)
                .HasColumnName("cod_estrato")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(c => c.CodClaseGen)
                .HasColumnName("cod_clase_gen")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(c => c.NombreGenerica)
                .HasColumnName("nombre_generica")
                .HasMaxLength(100);

            builder.Property(c => c.Resolucion)
                .HasColumnName("resolucion")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.FechaRes)
                .HasColumnName("fecha_res")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.Gaceta)
                .HasColumnName("gaceta")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.FechaGaceta)
                .HasColumnName("fecha_gaceta")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.VinculoDocPfd)
                .HasColumnName("vinculo_doc_pfd")
                .HasMaxLength(200);

            builder.Property(c => c.Activo)
                .HasColumnName("activo");

            builder.Property(c => c.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(c => c.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasOne(c => c.Estrato)
                .WithMany(e => e.ClasesGenericas)
                .HasForeignKey(c => c.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Clases)
                .WithOne(c => c.ClaseGenerica)
                .HasForeignKey(c => new { c.CodClaseGen, c.CodEstrato })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SolicitudesPedimento)
                .WithOne(s => s.ClaseGenerica)
                .HasForeignKey(s => new { s.CodClaseGen, s.CodEstrato })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

