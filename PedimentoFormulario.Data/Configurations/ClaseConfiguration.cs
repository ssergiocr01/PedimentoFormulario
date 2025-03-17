using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Clase utilizando Fluent API
    /// </summary>
    public class ClaseConfiguration : IEntityTypeConfiguration<Clase>
    {
        public void Configure(EntityTypeBuilder<Clase> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_clasificacion_clase");

            // Clave primaria
            builder.HasKey(c => c.CodClase);

            // Propiedades
            builder.Property(c => c.CodClase)
                .HasColumnName("cod_clase")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.CodEstrato)
                .HasColumnName("cod_estrato")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(c => c.CodClaseGen)
                .HasColumnName("cod_clase_gen")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(c => c.CodClasIa)
                .HasColumnName("cod_clas_ia")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(c => c.Grupo)
                .HasColumnName("grupo")
                .HasColumnType("numeric(18,0)")
                .IsRequired();

            builder.Property(c => c.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(c => c.TituloDeLaClase)
                .HasColumnName("titulo_de_la_clase")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.NivelSalarial)
                .HasColumnName("nivel_salarial")
                .HasColumnType("numeric(3,0)");

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

            builder.Property(c => c.VinculoDocPdf)
                .HasColumnName("vinculo_doc_pdf")
                .HasMaxLength(250);

            builder.Property(c => c.Activo)
                .HasColumnName("activo")
                .IsRequired();

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
            builder.HasOne(c => c.ClaseGenerica)
                .WithMany(cg => cg.Clases)
                .HasForeignKey(c => new { c.CodClaseGen, c.CodEstrato })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Institucion)
                .WithMany()
                .HasForeignKey(c => c.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Cargos)
                .WithOne(c => c.Clase)
                .HasForeignKey(c => c.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SolicitudesPedimento)
                .WithOne(s => s.Clase)
                .HasForeignKey(s => s.CodClase)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

