using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad FirmaPedimento utilizando Fluent API
    /// </summary>
    public class FirmaPedimentoConfiguration : IEntityTypeConfiguration<FirmaPedimento>
    {
        public void Configure(EntityTypeBuilder<FirmaPedimento> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_firmas_pedimento");

            // Clave primaria compuesta
            builder.HasKey(f => new { f.Pedimento, f.CodFirma, f.TipoFirma });

            // Propiedades
            builder.Property(f => f.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(f => f.CodFirma)
                .HasColumnName("cod_firma")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.TipoFirma)
                .HasColumnName("tipo_firma")
                .HasColumnType("numeric(1,0)")
                .IsRequired();

            builder.Property(f => f.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(50);

            builder.Property(f => f.Observaciones)
                .HasColumnName("observaciones")
                .HasColumnType("text");

            builder.Property(f => f.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(f => f.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasOne(f => f.SolicitudPedimento)
                .WithMany(s => s.FirmasPedimento)
                .HasForeignKey(f => f.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

