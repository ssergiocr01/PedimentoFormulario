using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Estrato utilizando Fluent API
    /// </summary>
    public class EstratoConfiguration : IEntityTypeConfiguration<Estrato>
    {
        public void Configure(EntityTypeBuilder<Estrato> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_clasificacion_estratos");

            // Clave primaria
            builder.HasKey(e => e.CodEstrato);

            // Propiedades
            builder.Property(e => e.CodEstrato)
                .HasColumnName("cod_estrato")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(e => e.NombreEstrato)
                .HasColumnName("nombre_estrato")
                .HasMaxLength(100);

            builder.Property(e => e.DescEstratos)
                .HasColumnName("desc_estratos")
                .HasMaxLength(600);

            builder.Property(e => e.Resolucion)
                .HasColumnName("resolucion")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.FechaRes)
                .HasColumnName("fecha_res");

            builder.Property(e => e.Gaceta)
                .HasColumnName("gaceta")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.FechaGaceta)
                .HasColumnName("fecha_gaceta")
                .IsRequired();

            builder.Property(e => e.VinculoDocPfd)
                .HasColumnName("vinculo_doc_pfd")
                .HasMaxLength(200);

            builder.Property(e => e.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(e => e.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(e => e.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasMany(e => e.ClasesGenericas)
                .WithOne(c => c.Estrato)
                .HasForeignKey(c => c.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.SolicitudesPedimento)
                .WithOne(s => s.Estrato)
                .HasForeignKey(s => s.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

