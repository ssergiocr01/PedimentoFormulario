using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Distrito utilizando Fluent API
    /// </summary>
    public class DistritoConfiguration : IEntityTypeConfiguration<Distrito>
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_DGSC_distritos");

            // Clave primaria compuesta
            builder.HasKey(d => new { d.CodDistrito, d.CodCanton, d.CodProvincia });

            // Propiedades
            builder.Property(d => d.CodDistrito)
                .HasColumnName("cod_distrito")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(d => d.CodCanton)
                .HasColumnName("cod_canton")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(d => d.CodProvincia)
                .HasColumnName("cod_provincia")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(d => d.NombreDistrito)
                .HasColumnName("distrito")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(d => d.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(d => d.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasOne(d => d.Canton)
                .WithMany(c => c.Distritos)
                .HasForeignKey(d => new { d.CodCanton, d.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.SolicitudesPedimento)
                .WithOne(s => s.Distrito)
                .HasForeignKey(s => new { s.CodDistrito, s.CodCanton, s.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

