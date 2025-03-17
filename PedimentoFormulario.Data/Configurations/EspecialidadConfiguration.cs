using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad Especialidad utilizando Fluent API
    /// </summary>
    public class EspecialidadConfiguration : IEntityTypeConfiguration<Especialidad>
    {
        public void Configure(EntityTypeBuilder<Especialidad> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_clasificacion_especialidades");

            // Clave primaria
            builder.HasKey(e => e.CodEspecialidad);

            // Propiedades
            builder.Property(e => e.CodEspecialidad)
                .HasColumnName("cod_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(e => e.NombreEspecialidad)
                .HasColumnName("especialidad")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Observaciones)
                .HasColumnName("observaciones")
                .HasMaxLength(512);

            builder.Property(e => e.Resolucion)
                .HasColumnName("resolucion")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.FechaRes)
                .HasColumnName("fecha_res")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Gaceta)
                .HasColumnName("gaceta")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.FechaGaceta)
                .HasColumnName("fecha_gaceta")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.VinculoDocPfd)
                .HasColumnName("vinculo_doc_pfd")
                .HasMaxLength(250);

            builder.Property(e => e.Activo)
                .HasColumnName("activo");

            builder.Property(e => e.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20);

            builder.Property(e => e.FechaReg)
                .HasColumnName("fechareg");

            builder.Property(e => e.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FechaMod)
                .HasColumnName("fechamod");

            builder.Property(e => e.Observ)
                .HasColumnName("observ")
                .HasMaxLength(500);

            // Relaciones
            builder.HasMany(e => e.SubEspecialidades)
                .WithOne(s => s.Especialidad)
                .HasForeignKey(s => s.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.SolicitudesPedimento)
                .WithOne(s => s.Especialidad)
                .HasForeignKey(s => s.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

