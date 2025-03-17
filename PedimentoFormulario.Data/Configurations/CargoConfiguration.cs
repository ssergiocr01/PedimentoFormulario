using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Cargo utilizando Fluent API
    /// </summary>
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_clasificacion_cargos");

            // Clave primaria
            builder.HasKey(c => c.CodCargo);

            // Propiedades
            builder.Property(c => c.CodCargo)
                .HasColumnName("cod_cargo")
                .HasColumnType("numeric(5,0)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CodManual)
                .HasColumnName("cod_manual")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(c => c.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(c => c.CodClase)
                .HasColumnName("cod_clase")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.NombreCargo)
                .HasColumnName("nombre_cargo")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.VinculoDocPdf)
                .HasColumnName("vinculo_doc_pdf")
                .HasMaxLength(100);

            builder.Property(c => c.Estado)
                .HasColumnName("estado")
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
            builder.HasOne(c => c.Clase)
                .WithMany(c => c.Cargos)
                .HasForeignKey(c => c.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Institucion)
                .WithMany()
                .HasForeignKey(c => c.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ManualDeCargos)
                .WithMany(m => m.Cargos)
                .HasForeignKey(c => new { c.CodManual, c.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.SolicitudesPedimento)
                .WithOne(s => s.Cargo)
                .HasForeignKey(s => s.CodCargo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

