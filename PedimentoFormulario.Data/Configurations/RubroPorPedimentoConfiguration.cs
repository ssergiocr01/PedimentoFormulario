using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad RubroPorPedimento
    /// </summary>
    public class RubroPorPedimentoConfiguration : IEntityTypeConfiguration<RubroPedimento>
    {
        public void Configure(EntityTypeBuilder<RubroPedimento> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_RyS_rubros_x_pedimento");

            // Clave primaria compuesta
            builder.HasKey(r => new { r.CodRubroSalarial, r.CodInstitucion, r.Pedimento });

            // Propiedades
            builder.Property(r => r.CodRubroSalarial)
                .HasColumnName("cod_rubro_salaria")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(r => r.Detalles)
                .HasColumnName("detalles")
                .HasMaxLength(3000);

            builder.Property(r => r.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(r => r.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.FechaMod)
                .HasColumnName("fechamod")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(r => r.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(r => r.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            // Relaciones
            builder.HasOne(r => r.RubroSalarial)
                .WithMany()
                .HasForeignKey(r => new { r.CodRubroSalarial, r.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.SolicitudPedimento)
                .WithMany()
                .HasForeignKey(r => r.Pedimento)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}