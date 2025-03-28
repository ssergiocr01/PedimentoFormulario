using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad HistoricoFirmasPedimento
    /// </summary>
    public class HistoricoFirmasPedimentoConfiguration : IEntityTypeConfiguration<HistoricoFirmasPedimento>
    {
        public void Configure(EntityTypeBuilder<HistoricoFirmasPedimento> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_RyS_historico_firmas_pedimento");

            // Clave primaria
            builder.HasKey(h => h.CodHistorico);

            // Propiedades
            builder.Property(h => h.CodHistorico)
                .HasColumnName("cod_historico")
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(h => h.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(h => h.CodFirma)
                .HasColumnName("cod_firma")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(h => h.TipoFirma)
                .HasColumnName("tipo_firma")
                .HasColumnType("numeric(1,0)")
                .IsRequired();

            builder.Property(h => h.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(60);

            builder.Property(h => h.Observaciones)
                .HasColumnName("observaciones")
                .HasColumnType("text");

            builder.Property(h => h.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(h => h.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(h => h.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(h => h.FechaMod)
                .HasColumnName("fechamod")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}

