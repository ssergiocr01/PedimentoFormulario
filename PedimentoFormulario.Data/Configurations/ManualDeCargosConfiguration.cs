using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad ManualDeCargos utilizando Fluent API
    /// </summary>
    public class ManualDeCargosConfiguration : IEntityTypeConfiguration<ManualDeCargos>
    {
        public void Configure(EntityTypeBuilder<ManualDeCargos> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_clasificacion_manuales_de_cargos");

            // Clave primaria compuesta
            builder.HasKey(m => new { m.CodManual, m.CodInstitucion });

            // Propiedades
            builder.Property(m => m.CodManual)
                .HasColumnName("cod_manual")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(m => m.Manual)
                .HasColumnName("manual")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(m => m.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(m => m.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(m => m.FechaCreacion)
                .HasColumnName("fecha_creacion")
                .IsRequired();

            builder.Property(m => m.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(m => m.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(m => m.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(m => m.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasOne(m => m.Institucion)
                .WithMany()
                .HasForeignKey(m => m.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.Cargos)
                .WithOne(c => c.ManualDeCargos)
                .HasForeignKey(c => new { c.CodManual, c.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

