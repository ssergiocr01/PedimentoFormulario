using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad BitacoraPedimentoPersonal
    /// </summary>
    public class BitacoraPedimentoPersonalConfiguration : IEntityTypeConfiguration<BitacoraPedimentoPersonal>
    {
        public void Configure(EntityTypeBuilder<BitacoraPedimentoPersonal> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_RyS_bitacora_pedimento_personal");

            // Clave primaria compuesta (no tiene una clave primaria explícita en la definición de la tabla)
            // Usamos una combinación de campos que deberían ser únicos
            builder.HasKey(b => new { b.Pedimento, b.FechaReg });

            // Propiedades
            builder.Property(b => b.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(b => b.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(b => b.CodDependencia)
                .HasColumnName("cod_dependencia")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(b => b.NumPuesto)
                .HasColumnName("num_puesto")
                .HasColumnType("numeric(15,0)")
                .IsRequired();

            builder.Property(b => b.CodPresupuesto)
                .HasColumnName("cod_presupuesto")
                .HasMaxLength(20);

            builder.Property(b => b.CodEstrato)
                .HasColumnName("cod_estrato")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(b => b.CodClaseGen)
                .HasColumnName("cod_clase_gen")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(b => b.CodClase)
                .HasColumnName("cod_clase")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(b => b.CodEspecialidad)
                .HasColumnName("cod_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(b => b.CodSubEspecialidad)
                .HasColumnName("cod_sub_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(b => b.CodCargo)
                .HasColumnName("cod_cargo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(b => b.CodMotivo)
                .HasColumnName("cod_motivo")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(b => b.IntIdentificacion)
                .HasColumnName("int_identificacion")
                .HasMaxLength(20);

            builder.Property(b => b.IntNombre)
                .HasColumnName("int_nombre")
                .HasMaxLength(80);

            builder.Property(b => b.CodDepartamento)
                .HasColumnName("cod_departamento")
                .HasColumnType("numeric(6,0)")
                .IsRequired();

            builder.Property(b => b.CodProvincia)
                .HasColumnName("cod_provincia")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(b => b.CodCanton)
                .HasColumnName("cod_canton")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(b => b.CodDistrito)
                .HasColumnName("cod_distrito")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(b => b.Destacado)
                .HasColumnName("destacado")
                .HasColumnType("numeric(1,0)");

            builder.Property(b => b.EspecDestacado)
                .HasColumnName("espec_destacado")
                .HasColumnType("text");

            builder.Property(b => b.Traslado)
                .HasColumnName("traslado")
                .HasDefaultValue(false);

            builder.Property(b => b.EspecTraslado)
                .HasColumnName("espec_traslado")
                .HasColumnType("text");

            builder.Property(b => b.CodJornada)
                .HasColumnName("cod_jornada")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(b => b.CodHorario)
                .HasColumnName("cod_horario")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(b => b.Observaciones)
                .HasColumnName("observaciones")
                .HasColumnType("text");

            builder.Property(b => b.CodTipoResolucion)
                .HasColumnName("cod_tipo_resolucion")
                .HasColumnType("numeric(2,0)");

            builder.Property(b => b.DetallesResolucion)
                .HasColumnName("detalles_resolucion")
                .HasColumnType("text");

            builder.Property(b => b.Consecutivo)
                .HasColumnName("consecutivo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(b => b.Anno)
                .HasColumnName("anno")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(b => b.AnulaPed)
                .HasColumnName("anula_ped")
                .HasDefaultValue(false);

            builder.Property(b => b.NumPedimento)
                .HasColumnName("num_pedimento")
                .HasMaxLength(15);

            builder.Property(b => b.Detalles)
                .HasColumnName("detalles")
                .HasColumnType("text");

            builder.Property(b => b.ObservacionesPed)
                .HasColumnName("observaciones_ped")
                .HasColumnType("text");

            builder.Property(b => b.Temporal)
                .HasColumnName("temporal")
                .HasDefaultValue(true);

            builder.Property(b => b.ConsecTemporal)
                .HasColumnName("consec_temporal")
                .HasColumnType("numeric(5,0)");

            builder.Property(b => b.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(b => b.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(b => b.CodEstPedUlt)
                .HasColumnName("cod_est_ped_ult")
                .HasColumnType("numeric(2,0)")
                .HasDefaultValue(1m);

            builder.Property(b => b.ReservaDiscapacidad)
                .HasColumnName("reserva_discapacidad")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(b => b.ObservacionesConcursoInt)
                .HasColumnName("observaciones_concurso_int")
                .HasColumnType("text");

            builder.Property(b => b.DescripcionBitacora)
                .HasColumnName("descripcion_bitacora")
                .HasColumnType("text");
        }
    }
}

