using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad RubroSalarial
    /// </summary>
    public class RubroSalarialConfiguration : IEntityTypeConfiguration<RubroSalarial>
    {
        public void Configure(EntityTypeBuilder<RubroSalarial> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGHTE_SALARIO_Rubros_Salariales");

            // Clave primaria compuesta
            builder.HasKey(r => new { r.CodRubroSalarial, r.CodInstitucion });

            // Propiedades
            builder.Property(r => r.CodRubroSalarial)
                .HasColumnName("cod_rubro_salarial")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(r => r.NombreRubroSalarial)
                .HasColumnName("rubro_salarial")
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(r => r.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(r => r.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(r => r.Detalles)
                .HasColumnName("detalles")
                .HasColumnType("text");

            builder.Property(r => r.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.FechaReg)
                .HasColumnName("fechareg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(r => r.FechaMod)
                .HasColumnName("fechamod")
                .HasMaxLength(20)
                .IsRequired();

            // Relaciones
            builder.HasOne(r => r.Institucion)
                .WithMany()
                .HasForeignKey(r => r.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

