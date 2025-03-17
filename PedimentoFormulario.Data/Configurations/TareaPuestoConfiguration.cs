using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad TareaPuesto utilizando Fluent API
    /// </summary>
    public class TareaPuestoConfiguration : IEntityTypeConfiguration<TareaPuesto>
    {
        public void Configure(EntityTypeBuilder<TareaPuesto> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_tareas_puesto");

            // Clave primaria compuesta
            builder.HasKey(t => new { t.Pedimento, t.CodTarea });

            // Propiedades
            builder.Property(t => t.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(t => t.CodTarea)
                .HasColumnName("cod_tarea")
                .HasColumnType("numeric(18,0)")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Tarea)
                .HasColumnName("tarea")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(t => t.DetalleTarea)
                .HasColumnName("detalle_tarea")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(t => t.Frecuencia)
                .HasColumnName("frecuencia")
                .HasMaxLength(1)
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
            builder.HasOne(t => t.SolicitudPedimento)
                .WithMany(s => s.TareasPuesto)
                .HasForeignKey(t => t.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

