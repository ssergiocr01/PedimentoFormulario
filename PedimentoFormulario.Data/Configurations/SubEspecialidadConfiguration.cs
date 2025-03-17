using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad SubEspecialidad utilizando Fluent API
    /// </summary>
    public class SubEspecialidadConfiguration : IEntityTypeConfiguration<SubEspecialidad>
    {
        public void Configure(EntityTypeBuilder<SubEspecialidad> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_clasificacion_sub_especialidad");

            // Clave primaria compuesta
            builder.HasKey(s => new { s.CodSubEspecialidad, s.CodEspecialidad });

            // Propiedades
            builder.Property(s => s.CodSubEspecialidad)
                .HasColumnName("cod_sub_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(s => s.CodEspecialidad)
                .HasColumnName("cod_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(s => s.NombreSubespecialidad)
                .HasColumnName("subespecialidad")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(s => s.Observaciones)
                .HasColumnName("observaciones")
                .HasMaxLength(350);

            builder.Property(s => s.Resolucion)
                .HasColumnName("resolucion")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(s => s.FechaRes)
                .HasColumnName("fecha_res")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(s => s.Gaceta)
                .HasColumnName("gaceta")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(s => s.FechaGaceta)
                .HasColumnName("fehca_gaceta") // Nota: hay un error ortográfico en el nombre de la columna
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(s => s.VinculoDocPfd)
                .HasColumnName("vinculo_doc_pfd")
                .HasMaxLength(500);

            builder.Property(s => s.Activo)
                .HasColumnName("activo");

            builder.Property(s => s.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.FechaReg)
                .HasColumnName("fechareg");

            builder.Property(s => s.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.FechaMod)
                .HasColumnName("fechamod");

            builder.Property(s => s.Nota)
                .HasColumnName("nota")
                .HasMaxLength(500);

            // Relaciones
            builder.HasOne(s => s.Especialidad)
                .WithMany(e => e.SubEspecialidades)
                .HasForeignKey(s => s.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.SolicitudesPedimento)
                .WithOne(sp => sp.SubEspecialidad)
                .HasForeignKey(sp => new { sp.CodSubEspecialidad, sp.CodEspecialidad })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

