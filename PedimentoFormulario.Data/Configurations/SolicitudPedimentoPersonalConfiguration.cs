using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Configuration
{
    /// <summary>
    /// Configuración de la entidad SolicitudPedimentoPersonal utilizando Fluent API
    /// </summary>
    public class SolicitudPedimentoPersonalConfiguration : IEntityTypeConfiguration<SolicitudPedimentoPersonal>
    {
        public void Configure(EntityTypeBuilder<SolicitudPedimentoPersonal> builder)
        {
            // Tabla
            builder.ToTable("SAGTHE_RyS_pedimento_personal");

            // Clave primaria
            builder.HasKey(p => p.Pedimento);

            // Propiedades
            builder.Property(p => p.Pedimento)
                .HasColumnName("pedimento")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.CodInstitucion)
                .HasColumnName("cod_institucion")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(p => p.CodDependencia)
                .HasColumnName("cod_dependencia")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(p => p.NumPuesto)
                .HasColumnName("num_puesto")
                .HasColumnType("numeric(15,0)")
                .IsRequired();

            builder.Property(p => p.CodPresupuesto)
                .HasColumnName("cod_presupuesto")
                .HasMaxLength(20);

            builder.Property(p => p.CodEstrato)
                .HasColumnName("cod_estrato")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(p => p.CodClaseGen)
                .HasColumnName("cod_clase_gen")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(p => p.CodClase)
                .HasColumnName("cod_clase")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.CodEspecialidad)
                .HasColumnName("cod_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(p => p.CodSubEspecialidad)
                .HasColumnName("cod_sub_especialidad")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(p => p.CodCargo)
                .HasColumnName("cod_cargo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(p => p.CodMotivo)
                .HasColumnName("cod_motivo")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(p => p.IntIdentificacion)
                .HasColumnName("int_identificacion")
                .HasMaxLength(20);

            builder.Property(p => p.IntNombre)
                .HasColumnName("int_nombre")
                .HasMaxLength(80);

            builder.Property(p => p.CodDepartamento)
                .HasColumnName("cod_departamento")
                .HasColumnType("numeric(6,0)")
                .IsRequired();

            builder.Property(p => p.CodProvincia)
                .HasColumnName("cod_provincia")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(p => p.CodCanton)
                .HasColumnName("cod_canton")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(p => p.CodDistrito)
                .HasColumnName("cod_distrito")
                .HasColumnType("numeric(3,0)")
                .IsRequired();

            builder.Property(p => p.Destacado)
                .HasColumnName("destacado")
                .HasColumnType("numeric(1,0)");

            builder.Property(p => p.EspecDestacado)
                .HasColumnName("espec_destacado")
                .HasColumnType("text");

            builder.Property(p => p.Traslado)
                .HasColumnName("traslado");

            builder.Property(p => p.EspecTraslado)
                .HasColumnName("espec_traslado")
                .HasColumnType("text");

            builder.Property(p => p.CodJornada)
                .HasColumnName("cod_jornada")
                .HasColumnType("numeric(2,0)")
                .IsRequired();

            builder.Property(p => p.CodHorario)
                .HasColumnName("cod_horario")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(p => p.Observaciones)
                .HasColumnName("observaciones")
                .HasColumnType("text");

            builder.Property(p => p.CodTipoResolucion)
                .HasColumnName("cod_tipo_resolucion")
                .HasColumnType("numeric(2,0)");

            builder.Property(p => p.DetallesResolucion)
                .HasColumnName("detalles_resolucion")
                .HasColumnType("text");

            builder.Property(p => p.Consecutivo)
                .HasColumnName("consecutivo")
                .HasColumnType("numeric(5,0)")
                .IsRequired();

            builder.Property(p => p.Anno)
                .HasColumnName("anno")
                .HasColumnType("numeric(4,0)")
                .IsRequired();

            builder.Property(p => p.AnulaPed)
                .HasColumnName("anula_ped");

            builder.Property(p => p.NumPedimento)
                .HasColumnName("num_pedimento")
                .HasMaxLength(15);

            builder.Property(p => p.Detalles)
                .HasColumnName("detalles")
                .HasColumnType("text");

            builder.Property(p => p.ObservacionesPed)
                .HasColumnName("observaciones_ped")
                .HasColumnType("text");

            builder.Property(p => p.Temporal)
                .HasColumnName("temporal");

            builder.Property(p => p.ConsecTemporal)
                .HasColumnName("consec_temporal")
                .HasColumnType("numeric(5,0)");

            builder.Property(p => p.UsuarioMod)
                .HasColumnName("usuariomod")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.FechaReg)
                .HasColumnName("fechareg")
                .IsRequired();

            builder.Property(p => p.UsuarioReg)
                .HasColumnName("usuarioreg")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.FechaMod)
                .HasColumnName("fechamod")
                .IsRequired();

            builder.Property(p => p.CodEstPedUlt)
                .HasColumnName("cod_est_ped_ult")
                .HasColumnType("numeric(2,0)");

            builder.Property(p => p.ReservaDiscapacidad)
                .HasColumnName("reserva_discapacidad")
                .IsRequired();

            builder.Property(p => p.ObservacionesConcursoInt)
                .HasColumnName("observaciones_concurso_int")
                .HasColumnType("text");

            builder.Property(p => p.ReservaAfrodescendiente)
                .HasColumnName("reserva_afrodescendiente");

            // Relaciones
            builder.HasOne(p => p.Institucion)
                .WithMany(i => i.SolicitudesPedimento)
                .HasForeignKey(p => p.CodInstitucion)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Dependencia)
                .WithMany(d => d.SolicitudesPedimento)
                .HasForeignKey(p => new { p.CodDependencia, p.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Departamento)
                .WithMany(d => d.SolicitudesPedimento)
                .HasForeignKey(p => new { p.CodDepartamento, p.CodInstitucion })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Estrato)
                .WithMany(e => e.SolicitudesPedimento)
                .HasForeignKey(p => p.CodEstrato)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ClaseGenerica)
                .WithMany(c => c.SolicitudesPedimento)
                .HasForeignKey(p => new { p.CodClaseGen, p.CodEstrato })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Clase)
                .WithMany(c => c.SolicitudesPedimento)
                .HasForeignKey(p => p.CodClase)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Especialidad)
                .WithMany(e => e.SolicitudesPedimento)
                .HasForeignKey(p => p.CodEspecialidad)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.SubEspecialidad)
                .WithMany(s => s.SolicitudesPedimento)
                .HasForeignKey(p => new { p.CodSubEspecialidad, p.CodEspecialidad })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Cargo)
                .WithMany(c => c.SolicitudesPedimento)
                .HasForeignKey(p => p.CodCargo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Provincia)
                .WithMany(p => p.SolicitudesPedimento)
                .HasForeignKey(p => p.CodProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Canton)
                .WithMany(c => c.SolicitudesPedimento)
                .HasForeignKey(p => new { p.CodCanton, p.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Distrito)
                .WithMany(d => d.SolicitudesPedimento)
                .HasForeignKey(p => new { p.CodDistrito, p.CodCanton, p.CodProvincia })
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Jornada)
                .WithMany(j => j.SolicitudesPedimento)
                .HasForeignKey(p => p.CodJornada)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Horario)
                .WithMany(h => h.SolicitudesPedimento)
                .HasForeignKey(p => p.CodHorario)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.MotivoVacante)
                .WithMany(m => m.SolicitudesPedimento)
                .HasForeignKey(p => p.CodMotivo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.TipoResolucion)
                .WithMany(t => t.SolicitudesPedimento)
                .HasForeignKey(p => p.CodTipoResolucion)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

