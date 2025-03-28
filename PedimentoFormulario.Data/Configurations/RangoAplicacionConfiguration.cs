using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad RangoAplicacion
    /// </summary>
    public class RangoAplicacionConfiguration : IEntityTypeConfiguration<RangoAplicacion>
    {
        public void Configure(EntityTypeBuilder<RangoAplicacion> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_clasificacion_rango_apliaccion");

            // Clave primaria compuesta
            builder.HasKey(r => new { r.CodClase, r.CodEspecialidad, r.CodSubEspecialidad });

            // Propiedades
            builder.Property(r => r.CodClase)
                .HasColumnName("cod_clase")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(r => r.CodEspecialidad)
                .HasColumnName("cod_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(r => r.CodSubEspecialidad)
                .HasColumnName("cod_sub_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(r => r.Rango)
                .HasColumnName("rango")
                .HasColumnType("text");

            builder.Property(r => r.Gaceta)
                .HasColumnName("gaceta")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(r => r.FGaceta)
                .HasColumnName("f_gaceta")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(r => r.Resolucion)
                .HasColumnName("resolucion")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.FRes)
                .HasColumnName("f_res")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(r => r.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(r => r.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.FechaMod)
                .HasColumnName("fechamod")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            // Relaciones
            builder.HasOne(r => r.Clase)
                .WithMany()
                .HasForeignKey(r => r.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Especialidad)
                .WithMany()
                .HasForeignKey(r => r.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.SubEspecialidad)
                .WithMany()
                .HasForeignKey(r => new { r.CodSubEspecialidad, r.CodEspecialidad })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

