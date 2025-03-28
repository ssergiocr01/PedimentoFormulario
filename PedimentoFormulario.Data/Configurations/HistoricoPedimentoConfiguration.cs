using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad HistoricoPedimento
    /// </summary>
    public class HistoricoPedimentoConfiguration : IEntityTypeConfiguration<HistoricoPedimento>
    {
        public void Configure(EntityTypeBuilder<HistoricoPedimento> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_RyS_historico_pedimento");

            // Clave primaria compuesta
            builder.HasKey(h => new { h.IdHistorico, h.NumSolicitud, h.Pedimento });

            // Propiedades
            builder.Property(h => h.IdHistorico)
                .HasColumnName("id_historico")
                .HasColumnType("numeric(18,0)")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(h => h.NumSolicitud)
                .HasColumnName("num_solicitud")
                .HasColumnType("numeric(10,0)")
                .IsRequired();

            builder.Property(h => h.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(h => h.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(h => h.CodDependencia)
                .HasColumnName("cod_dependencia")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(h => h.NumPuesto)
                .HasColumnName("num_puesto")
                .HasColumnType("numeric(15,0)")
                .IsRequired();

            builder.Property(h => h.CodPresupuesto)
                .HasColumnName("cod_presupuesto")
                .HasColumnType("numeric(15,0)");

            builder.Property(h => h.CodEstrato)
                .HasColumnName("cod_estrato")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(h => h.CodClaseGen)
                .HasColumnName("cod_clase_gen")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(h => h.CodClase)
                .HasColumnName("cod_clase")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(h => h.CodEspecialidad)
                .HasColumnName("cod_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(h => h.CodSubEspecialidad)
                .HasColumnName("cod_sub_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(h => h.CodCargo)
                .HasColumnName("cod_cargo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(h => h.CodMotivo)
                .HasColumnName("cod_motivo")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(h => h.IntIdentificacion)
                .HasColumnName("int_identificacion")
                .HasMaxLength(20);

            builder.Property(h => h.IntNombre)
                .HasColumnName("int_nombre")
                .HasMaxLength(80);

            builder.Property(h => h.CodDepartamento)
                .HasColumnName("cod_departamento")
                .HasColumnType("numeric(6,0)")
                .IsRequired();

            builder.Property(h => h.CodProvincia)
                .HasColumnName("cod_provincia")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(h => h.CodCanton)
                .HasColumnName("cod_canton")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(h => h.CodDistrito)
                .HasColumnName("cod_distrito")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(h => h.Destacado)
                .HasColumnName("destacado")
                .HasColumnType("numeric(1,0)");

            builder.Property(h => h.EspecDestacado)
                .HasColumnName("espec_destacado")
                .HasColumnType("text");

            builder.Property(h => h.Traslado)
                .HasColumnName("traslado");

            builder.Property(h => h.EspecTraslado)
                .HasColumnName("espec_traslado")
                .HasColumnType("text");

            builder.Property(h => h.CodJornada)
                .HasColumnName("cod_jornada")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(h => h.CodHorario)
                .HasColumnName("cod_horario")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(h => h.Observaciones)
                .HasColumnName("observaciones")
                .HasColumnType("text");

            builder.Property(h => h.CodTipoResolucion)
                .HasColumnName("cod_tipo_resolucion")
                .HasColumnType("numeric(2,0)");

            builder.Property(h => h.DetallesResolucion)
                .HasColumnName("detalles_resolucion")
                .HasColumnType("text");

            builder.Property(h => h.Consecutivo)
                .HasColumnName("consecutivo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(h => h.Anno)
                .HasColumnName("anno")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(h => h.AnulaPed)
                .HasColumnName("anula_ped")
                .HasDefaultValue(false);

            builder.Property(h => h.NumPedimento)
                .HasColumnName("num_pedimento")
                .HasMaxLength(15);

            builder.Property(h => h.Detalles)
                .HasColumnName("detalles")
                .HasColumnType("text");

            builder.Property(h => h.ObservacionesPed)
                .HasColumnName("observaciones_ped")
                .HasColumnType("text");

            builder.Property(h => h.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(h => h.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(h => h.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(h => h.FechaMod)
                .HasColumnName("fechamod")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}

