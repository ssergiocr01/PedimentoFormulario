using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad SolicitudAPedimento utilizando Fluent API
    /// </summary>
    public class SolicitudAPedimentoConfiguration : IEntityTypeConfiguration<SolicitudAPedimento>
    {
        public void Configure(EntityTypeBuilder<SolicitudAPedimento> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_solicitud_a_pedimento");

            // Clave primaria compuesta
            builder.HasKey(s => new { s.NumSolicitud, s.Pedimento, s.CodInstitucion });

            // Propiedades
            builder.Property(s => s.NumSolicitud)
                .HasColumnName("num_solicitud")
                .HasColumnType("numeric(10,0)")
                .IsRequired();

            builder.Property(s => s.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(s => s.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(18,0)")
                .IsRequired();

            builder.Property(s => s.CodTipoSolicitud)
                .HasColumnName("cod_tipo_solicitud")
                .HasColumnType("numeric(18,0)")
                .IsRequired();

            builder.Property(s => s.CodMotivo)
                .HasColumnName("cod_motivo")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(s => s.Justificacion)
                .HasColumnName("justificacion")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(s => s.Anexo)
                .HasColumnName("anexo")
                .HasColumnType("image");

            builder.Property(s => s.FechaFin)
                .HasColumnName("fecha_fin");

            builder.Property(s => s.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(s => s.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20);

            builder.Property(s => s.CodEstado)
                .HasColumnName("cod_estado")
                .HasColumnType("numeric(18,0)")
                .IsRequired();

            builder.Property(s => s.FechaMod)
                .HasColumnName("fechamod");

            // Relaciones
            builder.HasOne(s => s.Institucion)
                .WithMany(i => i.SolicitudesAPedimento)
                .HasForeignKey(s => s.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.MotivoVacante)
                .WithMany(m => m.SolicitudesAPedimento)
                .HasForeignKey(s => s.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.SolicitudPedimento)
                .WithMany()
                .HasForeignKey(s => s.Pedimento)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

