using Microsoft.EntityFrameworkCore;
using PedimentoFormulario.Modelos.Entidades;
using System.Reflection;

namespace PedimentoFormulario.Data
{
    public class PedimentoContext : DbContext
    {
        public PedimentoContext(DbContextOptions<PedimentoContext> options) : base(options)
        {
        }

        // DbSets para las entidades principales
        public DbSet<SolicitudPedimentoPersonal> SolicitudesPedimentoPersonal { get; set; }
        public DbSet<TareaPuesto> TareasPuesto { get; set; }
        public DbSet<FirmaPedimento> FirmasPedimento { get; set; }
        public DbSet<EstadoPedimento> EstadosPedimento { get; set; }
        public DbSet<EstadoParaPedimento> EstadosParaPedimentos { get; set; }
        public DbSet<SolicitudAPedimento> SolicitudesAPedimentos { get; set; }

        // DbSets para catálogos de clasificación
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<SubEspecialidad> SubEspecialidades { get; set; }
        public DbSet<ClaseGenerica> ClasesGenericas { get; set; }

        // DbSets para división territorial        
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Canton> Cantones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }       

        // DbSets para jornadas y horarios
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<Horario> Horarios { get; set; }

        // DbSets para cargos y estratos
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Estrato> Estratos { get; set; }

        // DbSets para instituciones, departamentos y dependencias
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Dependencia> Dependencias { get; set; }

        // DbSets para tipos de resoluciones y motivos vacantes
        
        public DbSet<TipoResolucion> TiposResolucion { get; set; }
        public DbSet<MotivoVacante> MotivosVacantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar todas las configuraciones de entidades automáticamente
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}