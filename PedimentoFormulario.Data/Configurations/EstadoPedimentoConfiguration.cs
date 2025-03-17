using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad EstadoPedimento utilizando Fluent API
    /// </summary>
    public class EstadoPedimentoConfiguration : IEntityTypeConfiguration<EstadoPedimento>
    {
        public void Configure(EntityTypeBuilder<EstadoPedimento> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_estados_pedimento");

            // Clave primaria compuesta
            builder.HasKey(e => new { e.NumEstado, e.CodEstado, e.Pedimento });

            // Propiedades
            builder.Property(e => e.NumEstado)
                .HasColumnName("num_estado")
                .HasColumnType("numeric(10,0)")
                .IsRequired();

            builder.Property(e => e.CodEstado)
                .HasColumnName("cod_estado")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(e => e.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Observaciones)
                .HasColumnName("observaciones")
                .HasMaxLength(3000);

            builder.Property(e => e.Anexo)
                .HasColumnName("anexo")
                .HasMaxLength(512);

            builder.Property(e => e.Activo)
                .HasColumnName("activo");

            builder.Property(e => e.FechaRige)
                .HasColumnName("fecha_rige");

            builder.Property(e => e.FechaVence)
                .HasColumnName("fecha_vence");

            builder.Property(e => e.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20);

            builder.Property(e => e.FechaReg)
                .HasColumnName("fechareg");

            builder.Property(e => e.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20);

            builder.Property(e => e.FechaMod)
                .HasColumnName("fechamod");

            // Relaciones
            builder.HasOne(e => e.EstadoParaPedimento)
                .WithMany(e => e.EstadosPedimento)
                .HasForeignKey(e => e.CodEstado)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SolicitudPedimento)
                .WithMany(s => s.EstadosPedimento)
                .HasForeignKey(e => e.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

