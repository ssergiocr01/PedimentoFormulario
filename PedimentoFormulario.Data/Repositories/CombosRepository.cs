using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Repositories
{
    /// <summary>
    /// Implementación del repositorio de combos para el formulario de pedimentos
    /// </summary>
    public class CombosRepository : ICombosRepository
    {
        private readonly PedimentoContext _context;
        private readonly ILogger<CombosRepository> _logger;

        /// <summary>
        /// Constructor del repositorio de combos
        /// </summary>
        /// <param name="context">Contexto de base de datos</param>
        /// <param name="logger">Logger para registrar eventos</param>
        public CombosRepository(PedimentoContext context, ILogger<CombosRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Ubicación Geográfica

        /// <inheritdoc/>
        public async Task<IEnumerable<Provincia>> GetProvinciasAsync()
        {
            try
            {
                return await _context.Provincias
                    .Where(p => p.Activo && p.CodProvincia != 99)
                    .OrderBy(p => p.NombreProvincia)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener provincias");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Canton>> GetCantonesByProvinciaAsync(decimal codProvincia)
        {
            try
            {
                return await _context.Cantones
                    .Where(c => c.CodProvincia == codProvincia && c.Activo && c.CodCanton != 99)
                    .OrderBy(c => c.NombreCanton)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener cantones para la provincia {CodProvincia}", codProvincia);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Distrito>> GetDistritosByCantonAsync(decimal codProvincia, decimal codCanton)
        {
            try
            {
                return await _context.Distritos
                    .Where(d => d.CodProvincia == codProvincia && d.CodCanton == codCanton && d.Activo && d.CodDistrito != 99)
                    .OrderBy(d => d.NombreDistrito)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener distritos para el cantón {CodCanton} de la provincia {CodProvincia}", codCanton, codProvincia);
                throw;
            }
        }

        #endregion

        #region Clasificación

        /// <inheritdoc/>
        public async Task<IEnumerable<Estrato>> GetEstratosAsync()
        {
            try
            {
                return await _context.Estratos
                    .Where(e => e.Activo && e.CodEstrato != 99)
                    .OrderBy(e => e.NombreEstrato)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estratos");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ClaseGenerica>> GetClasesGenericasByEstratoAsync(decimal codEstrato)
        {
            try
            {
                return await _context.ClasesGenericas
                    .Where(c => c.CodEstrato == codEstrato && c.Activo == true && c.CodClaseGen != 99)
                    .OrderBy(c => c.NombreGenerica)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener clases genéricas para el estrato {CodEstrato}", codEstrato);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Clase>> GetClasesByClaseGenericaAsync(decimal codEstrato, decimal codClaseGen)
        {
            try
            {
                return await _context.Clases
                    .Where(c => c.CodEstrato == codEstrato && c.CodClaseGen == codClaseGen && c.Activo)
                    .OrderBy(c => c.TituloDeLaClase)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener clases para la clase genérica {CodClaseGen} del estrato {CodEstrato}", codClaseGen, codEstrato);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<EspecialidadDto>> GetEspecialidadesAsync(string codClase = null)
        {
            try
            {
                // Si no se proporciona un código de clase, devolver todas las especialidades activas
                if (string.IsNullOrEmpty(codClase))
                {
                    return await _context.Especialidades
                        .Where(e => e.Activo == true)
                        .OrderBy(e => e.NombreEspecialidad)
                        .Select(e => new EspecialidadDto
                        {
                            CodEspecialidad = e.CodEspecialidad,
                            NombreEspecialidad = e.NombreEspecialidad,
                            Activo = e.Activo
                        })
                        .ToListAsync();
                }

                // Si se proporciona un código de clase, filtrar por las especialidades que aplican a esa clase
                return await _context.Especialidades
                    .Join(
                        _context.RangosAplicacion,
                        e => e.CodEspecialidad,
                        r => r.CodEspecialidad,
                        (e, r) => new { Especialidad = e, RangoAplicacion = r }
                    )
                    .Where(
                        er => er.RangoAplicacion.CodClase == codClase &&
                              er.Especialidad.Activo == true 
                    )
                    .Select(er => new EspecialidadDto
                    {
                        CodEspecialidad = er.Especialidad.CodEspecialidad,
                        NombreEspecialidad = er.Especialidad.NombreEspecialidad,
                        Activo = er.Especialidad.Activo
                    })
                    .Distinct()
                    .OrderBy(e => e.NombreEspecialidad)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener especialidades para la clase {CodClase}", codClase);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SubEspecialidad>> GetSubespecialidadesByEspecialidadAsync(decimal codEspecialidad)
        {
            try
            {
                return await _context.SubEspecialidades
                    .Where(s => s.CodEspecialidad == codEspecialidad && s.Activo == true && s.CodSubEspecialidad != 99)
                    .OrderBy(s => s.NombreSubespecialidad)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener subespecialidades para la especialidad {CodEspecialidad}", codEspecialidad);
                throw;
            }
        }

        #endregion

        #region Institucional

        /// <inheritdoc/>
        public async Task<IEnumerable<Institucion>> GetInstitucionesAsync()
        {
            try
            {
                return await _context.Instituciones
                    .Where(i => i.Activo && i.CodInstitucion != 99)
                    .OrderBy(i => i.NombreInstitucion)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener instituciones");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Dependencia>> GetDependenciasByInstitucionAsync(decimal codInstitucion)
        {
            try
            {
                return await _context.Dependencias
                    .Where(d => d.CodInstitucion == codInstitucion && d.Activo && d.CodDependencia != 99)
                    .OrderBy(d => d.NombreDependencia)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener dependencias para la institución {CodInstitucion}", codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Departamento>> GetDepartamentosByInstitucionAsync(decimal codInstitucion)
        {
            try
            {
                return await _context.Departamentos
                    .Where(d => d.CodInstitucion == codInstitucion && d.Activo && d.CodDepartamento != 99)
                    .OrderBy(d => d.NombreDepartamento)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener departamentos para la institución {CodInstitucion}", codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Cargo>> GetCargosByInstitucionAndClaseAsync(decimal codInstitucion, string codClase)
        {
            try
            {
                return await _context.Cargos
                    .Where(c => c.CodInstitucion == codInstitucion && c.CodClase == codClase && c.Estado && c.CodCargo != 99)
                    .OrderBy(c => c.NombreCargo)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener cargos para la institución {CodInstitucion} y clase {CodClase}", codInstitucion, codClase);
                throw;
            }
        }

        #endregion

        #region Jornada y Horario

        /// <inheritdoc/>
        public async Task<IEnumerable<Jornada>> GetJornadasAsync()
        {
            try
            {
                return await _context.Jornadas
                    .Where(j => j.Activo && j.CodJornada != 99)
                    .OrderBy(j => j.NombreJornada)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener jornadas");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Horario>> GetHorariosAsync()
        {
            try
            {
                return await _context.Horarios
                    .Where(h => h.Activo && h.CodHorario != 99)
                    .OrderBy(h => h.NombreHorario)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener horarios");
                throw;
            }
        }

        #endregion

        #region Motivos y Resoluciones

        /// <inheritdoc/>
        public async Task<IEnumerable<MotivoVacante>> GetMotivosVacanteAsync()
        {
            try
            {
                return await _context.MotivosVacante
                    .Where(m => m.Activo && m.CodMotivo != 99)
                    .OrderBy(m => m.NombreMotivo)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener motivos de vacante");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TipoResolucion>> GetTiposResolucionAsync()
        {
            try
            {
                return await _context.TiposResolucion
                    .Where(t => t.Activo && t.CodTipoResolucion != 99)
                    .OrderBy(t => t.NombreTipoResolucion)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener tipos de resolución");
                throw;
            }
        }

        #endregion
    }
}

