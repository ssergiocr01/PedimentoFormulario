using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Departamento utilizando Fluent API
    /// </summary>
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_DGSC_departamentos");

            // Clave primaria compuesta
            builder.HasKey(d => new { d.CodDepartamento, d.CodInstitucion });

            // Propiedades
            builder.Property(d => d.CodDepartamento)
                .HasColumnName("cod_departamento")
                .HasColumnType("numeric(6,0)")
                .IsRequired();

            builder.Property(d => d.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(d => d.NombreDepartamento)
                .HasColumnName("departamento")
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(d => d.Detalles)
                .HasColumnName("detalles")
                .HasMaxLength(3000);

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
            builder.HasOne(d => d.Institucion)
                .WithMany(i => i.Departamentos)
                .HasForeignKey(d => d.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.SolicitudesPedimento)
                .WithOne(s => s.Departamento)
                .HasForeignKey(s => new { s.CodDepartamento, s.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

