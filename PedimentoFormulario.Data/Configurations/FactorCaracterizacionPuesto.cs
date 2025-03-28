using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad FactorCaracterizacionPuesto
    /// </summary>
    public class FactorCaracterizacionPuestoConfiguration : IEntityTypeConfiguration<FactorCaracterizacionPuesto>
    {
        public void Configure(EntityTypeBuilder<FactorCaracterizacionPuesto> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_RyS_factores_caract_puesto");

            // Clave primaria
            builder.HasKey(f => f.CodFactor);

            // Propiedades
            builder.Property(f => f.CodFactor)
                .HasColumnName("cod_factor")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(f => f.Factor)
                .HasColumnName("factor")
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(f => f.EscalaMinima)
                .HasColumnName("escala_minima")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(f => f.EscalaMaxima)
                .HasColumnName("escala_maxima")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(f => f.CodFactorSup)
                .HasColumnName("cod_factor_sup")
                .HasColumnType("numeric(3,0)");

            builder.Property(f => f.Nivel)
                .HasColumnName("nivel")
                .HasColumnType("numeric(1,0)")
                .IsRequired();

            builder.Property(f => f.N1)
                .HasColumnName("n1")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(f => f.N2)
                .HasColumnName("n2")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(f => f.N3)
                .HasColumnName("n3")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(f => f.N4)
                .HasColumnName("n4")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(f => f.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(f => f.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(f => f.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(f => f.FechaMod)
                .HasColumnName("fechamod")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}

