using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Institucion utilizando Fluent API
    /// </summary>
    public class InstitucionConfiguration : IEntityTypeConfiguration<Institucion>
    {
        public void Configure(EntityTypeBuilder<Institucion> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_DGSC_Instituciones");

            // Clave primaria
            builder.HasKey(i => i.CodInstitucion);

            // Propiedades
            builder.Property(i => i.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(i => i.NombreInstitucion)
                .HasColumnName("institucion")
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(i => i.Sigla)
                .HasColumnName("sigla")
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(i => i.Reclutamiento)
                .HasColumnName("reclutamiento")
                .IsRequired();

            builder.Property(i => i.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(i => i.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(i => i.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(i => i.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(i => i.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasMany(i => i.Dependencias)
                .WithOne(d => d.Institucion)
                .HasForeignKey(d => d.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.Departamentos)
                .WithOne(d => d.Institucion)
                .HasForeignKey(d => d.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.SolicitudesPedimento)
                .WithOne(s => s.Institucion)
                .HasForeignKey(s => s.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.SolicitudesAPedimento)
                .WithOne(s => s.Institucion)
                .HasForeignKey(s => s.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

