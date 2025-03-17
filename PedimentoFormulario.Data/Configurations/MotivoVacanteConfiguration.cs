using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad MotivoVacante utilizando Fluent API
    /// </summary>
    public class MotivoVacanteConfiguration : IEntityTypeConfiguration<MotivoVacante>
    {
        public void Configure(EntityTypeBuilder<MotivoVacante> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_motivos_vacante");

            // Clave primaria
            builder.HasKey(m => m.CodMotivo);

            // Propiedades
            builder.Property(m => m.CodMotivo)
                .HasColumnName("cod_motivo")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(m => m.NombreMotivo)
                .HasColumnName("motivo")
                .HasMaxLength(35)
                .IsRequired();

            builder.Property(m => m.Detalles)
                .HasColumnName("detalles")
                .HasMaxLength(3000);

            builder.Property(m => m.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(m => m.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20);

            builder.Property(m => m.FechaReg)
                .HasColumnName("fechareg");

            builder.Property(m => m.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20);

            builder.Property(m => m.FechaMod)
                .HasColumnName("fechamod");

            // Relaciones
            builder.HasMany(m => m.SolicitudesPedimento)
                .WithOne(s => s.MotivoVacante)
                .HasForeignKey(s => s.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.SolicitudesAPedimento)
                .WithOne(s => s.MotivoVacante)
                .HasForeignKey(s => s.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

