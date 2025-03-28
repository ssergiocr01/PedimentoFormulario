using AutoMapper;
using Microsoft.Extensions.Logging;
using PedimentoFormulario.BLL.Interfaces;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Modelos.DTOs;

namespace PedimentoFormulario.BLL.Servicios
{
    /// <summary>
    /// Implementación del servicio de combos para el formulario de pedimentos
    /// </summary>
    public class CombosService : ICombosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CombosService> _logger;

        /// <summary>
        /// Constructor del servicio de combos
        /// </summary>
        /// <param name="unitOfWork">Unidad de trabajo para acceso a datos</param>
        /// <param name="mapper">Instancia de AutoMapper</param>
        /// <param name="logger">Logger para registrar eventos</param>
        public CombosService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CombosService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Ubicación Geográfica

        /// <inheritdoc/>
        public async Task<IEnumerable<ProvinciaDto>> GetProvinciasAsync()
        {
            try
            {
                var provincias = await _unitOfWork.Combos.GetProvinciasAsync();
                return _mapper.Map<IEnumerable<ProvinciaDto>>(provincias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener provincias");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CantonDto>> GetCantonesByProvinciaAsync(decimal codProvincia)
        {
            try
            {
                var cantones = await _unitOfWork.Combos.GetCantonesByProvinciaAsync(codProvincia);
                return _mapper.Map<IEnumerable<CantonDto>>(cantones);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener cantones para la provincia {CodProvincia}", codProvincia);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<DistritoDto>> GetDistritosByCantonAsync(decimal codProvincia, decimal codCanton)
        {
            try
            {
                var distritos = await _unitOfWork.Combos.GetDistritosByCantonAsync(codProvincia, codCanton);
                return _mapper.Map<IEnumerable<DistritoDto>>(distritos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener distritos para el cantón {CodCanton} de la provincia {CodProvincia}", codCanton, codProvincia);
                throw;
            }
        }

        #endregion

        #region Clasificación

        /// <inheritdoc/>
        public async Task<IEnumerable<EstratoDto>> GetEstratosAsync()
        {
            try
            {
                var estratos = await _unitOfWork.Combos.GetEstratosAsync();
                return _mapper.Map<IEnumerable<EstratoDto>>(estratos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener estratos");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ClaseGenericaDto>> GetClasesGenericasByEstratoAsync(decimal codEstrato)
        {
            try
            {
                var clasesGenericas = await _unitOfWork.Combos.GetClasesGenericasByEstratoAsync(codEstrato);
                return _mapper.Map<IEnumerable<ClaseGenericaDto>>(clasesGenericas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener clases genéricas para el estrato {CodEstrato}", codEstrato);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ClaseDto>> GetClasesByClaseGenericaAsync(decimal codEstrato, decimal codClaseGen)
        {
            try
            {
                var clases = await _unitOfWork.Combos.GetClasesByClaseGenericaAsync(codEstrato, codClaseGen);
                return _mapper.Map<IEnumerable<ClaseDto>>(clases);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener clases para la clase genérica {CodClaseGen} del estrato {CodEstrato}", codClaseGen, codEstrato);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<EspecialidadDto>> GetEspecialidadesAsync(string codClase = null!)
        {
            try
            {
                return await _unitOfWork.Combos.GetEspecialidadesAsync(codClase);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener especialidades para la clase {CodClase}", codClase ?? "todas");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<SubespecialidadDto>> GetSubespecialidadesByEspecialidadAsync(decimal codEspecialidad)
        {
            try
            {
                var subespecialidades = await _unitOfWork.Combos.GetSubespecialidadesByEspecialidadAsync(codEspecialidad);
                return _mapper.Map<IEnumerable<SubespecialidadDto>>(subespecialidades);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener subespecialidades para la especialidad {CodEspecialidad}", codEspecialidad);
                throw;
            }
        }

        #endregion

        #region Institucional

        /// <inheritdoc/>
        public async Task<IEnumerable<InstitucionDto>> GetInstitucionesAsync()
        {
            try
            {
                var instituciones = await _unitOfWork.Combos.GetInstitucionesAsync();
                return _mapper.Map<IEnumerable<InstitucionDto>>(instituciones);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener instituciones");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<DependenciaDto>> GetDependenciasByInstitucionAsync(decimal codInstitucion)
        {
            try
            {
                var dependencias = await _unitOfWork.Combos.GetDependenciasByInstitucionAsync(codInstitucion);
                return _mapper.Map<IEnumerable<DependenciaDto>>(dependencias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener dependencias para la institución {CodInstitucion}", codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<DepartamentoDto>> GetDepartamentosByInstitucionAsync(decimal codInstitucion)
        {
            try
            {
                var departamentos = await _unitOfWork.Combos.GetDepartamentosByInstitucionAsync(codInstitucion);
                return _mapper.Map<IEnumerable<DepartamentoDto>>(departamentos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener departamentos para la institución {CodInstitucion}", codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CargoDto>> GetCargosByInstitucionAndClaseAsync(decimal codInstitucion, string codClase)
        {
            try
            {
                var cargos = await _unitOfWork.Combos.GetCargosByInstitucionAndClaseAsync(codInstitucion, codClase);
                return _mapper.Map<IEnumerable<CargoDto>>(cargos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener cargos para la institución {CodInstitucion} y clase {CodClase}", codInstitucion, codClase);
                throw;
            }
        }

        #endregion

        #region Jornada y Horario

        /// <inheritdoc/>
        public async Task<IEnumerable<JornadaDto>> GetJornadasAsync()
        {
            try
            {
                var jornadas = await _unitOfWork.Combos.GetJornadasAsync();
                return _mapper.Map<IEnumerable<JornadaDto>>(jornadas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener jornadas");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<HorarioDto>> GetHorariosAsync()
        {
            try
            {
                var horarios = await _unitOfWork.Combos.GetHorariosAsync();
                return _mapper.Map<IEnumerable<HorarioDto>>(horarios);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener horarios");
                throw;
            }
        }

        #endregion

        #region Motivos y Resoluciones

        /// <inheritdoc/>
        public async Task<IEnumerable<MotivoVacanteDto>> GetMotivosVacanteAsync()
        {
            try
            {
                var motivosVacante = await _unitOfWork.Combos.GetMotivosVacanteAsync();
                return _mapper.Map<IEnumerable<MotivoVacanteDto>>(motivosVacante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener motivos de vacante");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TipoResolucionDto>> GetTiposResolucionAsync()
        {
            try
            {
                var tiposResolucion = await _unitOfWork.Combos.GetTiposResolucionAsync();
                return _mapper.Map<IEnumerable<TipoResolucionDto>>(tiposResolucion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servicio al obtener tipos de resolución");
                throw;
            }
        }

        #endregion

    }
}

