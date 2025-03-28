using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad CaracterizacionPuesto
    /// </summary>
    public class CaracterizacionPuestoConfiguration : IEntityTypeConfiguration<CaracterizacionPuesto>
    {
        public void Configure(EntityTypeBuilder<CaracterizacionPuesto> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_RyS_caracterizacion_del_puesto");

            // Clave primaria compuesta
            builder.HasKey(c => new { c.Pedimento, c.CodFactor });

            // Propiedades
            builder.Property(c => c.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.CodFactor)
                .HasColumnName("cod_factor")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(c => c.Escala)
                .HasColumnName("escala")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(c => c.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.FechaMod)
                .HasColumnName("fechamod")
                .HasColumnType("datetime")
                .IsRequired();

            // Relaciones
            builder.HasOne(c => c.Factor)
                .WithMany(f => f.Caracterizaciones)
                .HasForeignKey(c => c.CodFactor)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.SolicitudPedimento)
                .WithMany(s => s.CaracterizacionesPuesto)
                .HasForeignKey(c => c.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

