using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configurations
{
    /// <summary>
    /// Configuración para la entidad SolicitudPedimentoPersonal
    /// </summary>
    public class SolicitudPedimentoPersonalConfiguration : IEntityTypeConfiguration<SolicitudPedimentoPersonal>
    {
        public void Configure(EntityTypeBuilder<SolicitudPedimentoPersonal> builder)
        {
            // Configuración de la tabla
            builder.ToTable("SAGTHE_RyS_pedimento_personal");

            // Clave primaria
            builder.HasKey(s => s.Pedimento);

            // Propiedades
            builder.Property(s => s.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(s => s.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(s => s.CodDependencia)
                .HasColumnName("cod_dependencia")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(s => s.NumPuesto)
                .HasColumnName("num_puesto")
                .HasColumnType("numeric(15,0)")
                .IsRequired();

            builder.Property(s => s.CodPresupuesto)
                .HasColumnName("cod_presupuesto")
                .HasMaxLength(20);

            builder.Property(s => s.CodEstrato)
                .HasColumnName("cod_estrato")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(s => s.CodClaseGen)
                .HasColumnName("cod_clase_gen")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(s => s.CodClase)
                .HasColumnName("cod_clase")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(s => s.CodEspecialidad)
                .HasColumnName("cod_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(s => s.CodSubEspecialidad)
                .HasColumnName("cod_sub_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(s => s.CodCargo)
                .HasColumnName("cod_cargo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(s => s.CodMotivo)
                .HasColumnName("cod_motivo")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(s => s.IntIdentificacion)
                .HasColumnName("int_identificacion")
                .HasMaxLength(20);

            builder.Property(s => s.IntNombre)
                .HasColumnName("int_nombre")
                .HasMaxLength(80);

            builder.Property(s => s.CodDepartamento)
                .HasColumnName("cod_departamento")
                .HasColumnType("numeric(6,0)")
                .IsRequired();

            builder.Property(s => s.CodProvincia)
                .HasColumnName("cod_provincia")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(s => s.CodCanton)
                .HasColumnName("cod_canton")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(s => s.CodDistrito)
                .HasColumnName("cod_distrito")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(s => s.Destacado)
                .HasColumnName("destacado")
                .HasColumnType("numeric(1,0)");

            builder.Property(s => s.EspecDestacado)
                .HasColumnName("espec_destacado")
                .HasColumnType("text");

            builder.Property(s => s.Traslado)
                .HasColumnName("traslado")
                .HasDefaultValue(false);

            builder.Property(s => s.EspecTraslado)
                .HasColumnName("espec_traslado")
                .HasColumnType("text");

            builder.Property(s => s.CodJornada)
                .HasColumnName("cod_jornada")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(s => s.CodHorario)
                .HasColumnName("cod_horario")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(s => s.Observaciones)
                .HasColumnName("observaciones")
                .HasColumnType("text");

            builder.Property(s => s.CodTipoResolucion)
                .HasColumnName("cod_tipo_resolucion")
                .HasColumnType("numeric(2,0)");

            builder.Property(s => s.DetallesResolucion)
                .HasColumnName("detalles_resolucion")
                .HasColumnType("text");

            builder.Property(s => s.Consecutivo)
                .HasColumnName("consecutivo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(s => s.Anno)
                .HasColumnName("anno")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(s => s.AnulaPed)
                .HasColumnName("anula_ped")
                .HasDefaultValue(false);

            builder.Property(s => s.NumPedimento)
                .HasColumnName("num_pedimento")
                .HasMaxLength(15);

            builder.Property(s => s.Detalles)
                .HasColumnName("detalles")
                .HasColumnType("text");

            builder.Property(s => s.ObservacionesPed)
                .HasColumnName("observaciones_ped")
                .HasColumnType("text");

            builder.Property(s => s.Temporal)
                .HasColumnName("temporal")
                .HasDefaultValue(true);

            builder.Property(s => s.ConsecTemporal)
                .HasColumnName("consec_temporal")
                .HasColumnType("numeric(5,0)");

            builder.Property(s => s.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.FechaReg)
                .HasColumnName("fechareg")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(s => s.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.FechaMod)
                .HasColumnName("fechamod")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(s => s.CodEstPedUlt)
                .HasColumnName("cod_est_ped_ult")
                .HasColumnType("numeric(2,0)");

            builder.Property(s => s.ReservaDiscapacidad)
                .HasColumnName("reserva_discapacidad")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(s => s.ObservacionesConcursoInt)
                .HasColumnName("observaciones_concurso_int")
                .HasColumnType("text");

            builder.Property(s => s.ReservaAfrodescendiente)
                .HasColumnName("reserva_afrodescendiente")
                .HasDefaultValue(false);

            // Relaciones
            builder.HasOne(s => s.Institucion)
                .WithMany()
                .HasForeignKey(s => s.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Dependencia)
                .WithMany()
                .HasForeignKey(s => new { s.CodDependencia, s.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Departamento)
                .WithMany()
                .HasForeignKey(s => new { s.CodDepartamento, s.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Estrato)
                .WithMany()
                .HasForeignKey(s => s.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ClaseGenerica)
                .WithMany()
                .HasForeignKey(s => new { s.CodClaseGen, s.CodEstrato })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Clase)
                .WithMany()
                .HasForeignKey(s => s.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Especialidad)
                .WithMany()
                .HasForeignKey(s => s.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.SubEspecialidad)
                .WithMany()
                .HasForeignKey(s => new { s.CodSubEspecialidad, s.CodEspecialidad })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Cargo)
                .WithMany()
                .HasForeignKey(s => s.CodCargo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Provincia)
                .WithMany()
                .HasForeignKey(s => s.CodProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Canton)
                .WithMany()
                .HasForeignKey(s => new { s.CodCanton, s.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Distrito)
                .WithMany()
                .HasForeignKey(s => new { s.CodDistrito, s.CodCanton, s.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Jornada)
                .WithMany()
                .HasForeignKey(s => s.CodJornada)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Horario)
                .WithMany()
                .HasForeignKey(s => s.CodHorario)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.MotivoVacante)
                .WithMany()
                .HasForeignKey(s => s.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.TipoResolucion)
                .WithMany()
                .HasForeignKey(s => s.CodTipoResolucion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con CaracterizacionPuesto (nueva)
            builder.HasMany(s => s.CaracterizacionesPuesto)
                .WithOne(c => c.SolicitudPedimento)
                .HasForeignKey(c => c.Pedimento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

