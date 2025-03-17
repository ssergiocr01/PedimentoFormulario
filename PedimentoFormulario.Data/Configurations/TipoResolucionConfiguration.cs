using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad TipoResolucion utilizando Fluent API
    /// </summary>
    public class TipoResolucionConfiguration : IEntityTypeConfiguration<TipoResolucion>
    {
        public void Configure(EntityTypeBuilder<TipoResolucion> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_tipos_resolucion_pedimentos");

            // Clave primaria
            builder.HasKey(t => t.CodTipoResolucion);

            // Propiedades
            builder.Property(t => t.CodTipoResolucion)
                .HasColumnName("cod_tipo_resolucion")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(t => t.NombreTipoResolucion)
                .HasColumnName("tipo_resolucion")
                .HasMaxLength(75)
                .IsRequired();

            builder.Property(t => t.Activo)
                .HasColumnName("activo")
                .IsRequired();

            builder.Property(t => t.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20);

            builder.Property(t => t.FechaReg)
                .HasColumnName("fechareg");

            builder.Property(t => t.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20);

            builder.Property(t => t.FechaMod)
                .HasColumnName("fechamod");

            // Relaciones
            builder.HasMany(t => t.SolicitudesPedimento)
                .WithOne(s => s.TipoResolucion)
                .HasForeignKey(s => s.CodTipoResolucion)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

