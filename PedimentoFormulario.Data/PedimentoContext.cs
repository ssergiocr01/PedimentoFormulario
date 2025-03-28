using Microsoft.EntityFrameworkCore;
using PedimentoFormulario.Modelos.Entidades;
using System.Reflection;

namespace PedimentoFormulario.Data
{
    /// <summary>
    /// Contexto de base de datos para la aplicación de Pedimentos
    /// </summary>
    public class PedimentoContext : DbContext
    {
        public PedimentoContext(DbContextOptions<PedimentoContext> options) : base(options)
        {
        }

        #region DbSets

        // Catálogos
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Dependencia> Dependencias { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Canton> Cantones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<Estrato> Estratos { get; set; }
        public DbSet<ClaseGenerica> ClasesGenericas { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<SubEspecialidad> SubEspecialidades { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<MotivoVacante> MotivosVacante { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<TipoResolucion> TiposResolucion { get; set; }
        public DbSet<EstadoPedimento> EstadosPedimento { get; set; }
        public DbSet<FirmaPedimento> FirmasPedimento { get; set; }
        public DbSet<TareaPuesto> TareasPuesto { get; set; }

        // Entidades principales
        public DbSet<SolicitudPedimentoPersonal> SolicitudesPedimentoPersonal { get; set; }

        // Nuevas entidades
        public DbSet<CaracterizacionPuesto> CaracterizacionesPuesto { get; set; }
        public DbSet<FactorCaracterizacionPuesto> FactoresCaracterizacionPuesto { get; set; }
        public DbSet<HistoricoPedimento> HistoricosPedimento { get; set; }
        public DbSet<BitacoraPedimentoPersonal> BitacorasPedimentoPersonal { get; set; }
        public DbSet<HistoricoFirmasPedimento> HistoricosFirmasPedimento { get; set; }
        public DbSet<RangoAplicacion> RangosAplicacion { get; set; }
        public DbSet<RubroSalarial> RubrosSalariales { get; set; }
        public DbSet<RubroPedimento> RubrosPedimento { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar todas las configuraciones del ensamblado automáticamente
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}