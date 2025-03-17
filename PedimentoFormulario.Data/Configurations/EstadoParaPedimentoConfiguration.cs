using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad EstadoParaPedimento utilizando Fluent API
    /// </summary>
    public class EstadoParaPedimentoConfiguration : IEntityTypeConfiguration<EstadoParaPedimento>
    {
        public void Configure(EntityTypeBuilder<EstadoParaPedimento> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_estados_para_pedimentos");

            // Clave primaria
            builder.HasKey(e => e.CodEstado);

            // Propiedades
            builder.Property(e => e.CodEstado)
                .HasColumnName("cod_estado")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(e => e.NombreEstado)
                .HasColumnName("estado")
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(e => e.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(3000);

            builder.Property(e => e.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(e => e.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(e => e.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            // Relaciones
            builder.HasMany(e => e.EstadosPedimento)
                .WithOne(ep => ep.EstadoParaPedimento)
                .HasForeignKey(ep => ep.CodEstado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

