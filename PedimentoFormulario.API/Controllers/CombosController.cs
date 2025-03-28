using Microsoft.AspNetCore.Mvc;
using PedimentoFormulario.BLL.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;
using PedimentoFormulario.Modelos.Response;

namespace PedimentoFormulario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombosController : ControllerBase
    {
        private readonly ICombosService _combosService;
        private readonly ILogger<CombosController> _logger;

        public CombosController(ICombosService combosService, ILogger<CombosController> logger)
        {
            _combosService = combosService;
            _logger = logger;
        }

        #region Ubicación Geográfica

        [HttpGet("provincias")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProvinciaDto>>>> GetProvincias()
        {
            try
            {
                var provincias = await _combosService.GetProvinciasAsync();
                return Ok(ApiResponse<IEnumerable<ProvinciaDto>>.Ok(provincias));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de provincias");
                return StatusCode(500, ApiResponse<IEnumerable<ProvinciaDto>>.Error("Error al obtener provincias", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("provincias/{codProvincia}/cantones")]
        public async Task<ActionResult<ApiResponse<IEnumerable<CantonDto>>>> GetCantonesByProvincia(decimal codProvincia)
        {
            try
            {
                var cantones = await _combosService.GetCantonesByProvinciaAsync(codProvincia);
                return Ok(ApiResponse<IEnumerable<CantonDto>>.Ok(cantones));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de cantones para la provincia {CodProvincia}", codProvincia);
                return StatusCode(500, ApiResponse<IEnumerable<CantonDto>>.Error($"Error al obtener cantones para la provincia {codProvincia}", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("provincias/{codProvincia}/cantones/{codCanton}/distritos")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DistritoDto>>>> GetDistritosByCanton(decimal codProvincia, decimal codCanton)
        {
            try
            {
                var distritos = await _combosService.GetDistritosByCantonAsync(codProvincia, codCanton);
                return Ok(ApiResponse<IEnumerable<DistritoDto>>.Ok(distritos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de distritos para el cantón {CodCanton} de la provincia {CodProvincia}", codCanton, codProvincia);
                return StatusCode(500, ApiResponse<IEnumerable<DistritoDto>>.Error($"Error al obtener distritos para el cantón {codCanton} de la provincia {codProvincia}", "INTERNAL_ERROR"));
            }
        }

        #endregion

        #region Clasificación

        [HttpGet("estratos")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EstratoDto>>>> GetEstratos()
        {
            try
            {
                var estratos = await _combosService.GetEstratosAsync();
                return Ok(ApiResponse<IEnumerable<EstratoDto>>.Ok(estratos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de estratos");
                return StatusCode(500, ApiResponse<IEnumerable<EstratoDto>>.Error("Error al obtener estratos", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("estratos/{codEstrato}/clases-genericas")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ClaseGenericaDto>>>> GetClasesGenericasByEstrato(decimal codEstrato)
        {
            try
            {
                var clasesGenericas = await _combosService.GetClasesGenericasByEstratoAsync(codEstrato);
                return Ok(ApiResponse<IEnumerable<ClaseGenericaDto>>.Ok(clasesGenericas));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de clases genéricas para el estrato {CodEstrato}", codEstrato);
                return StatusCode(500, ApiResponse<IEnumerable<ClaseGenericaDto>>.Error($"Error al obtener clases genéricas para el estrato {codEstrato}", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("estratos/{codEstrato}/clases-genericas/{codClaseGen}/clases")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ClaseDto>>>> GetClasesByClaseGenerica(decimal codEstrato, decimal codClaseGen)
        {
            try
            {
                var clases = await _combosService.GetClasesByClaseGenericaAsync(codEstrato, codClaseGen);
                return Ok(ApiResponse<IEnumerable<ClaseDto>>.Ok(clases));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de clases para la clase genérica {CodClaseGen} del estrato {CodEstrato}", codClaseGen, codEstrato);
                return StatusCode(500, ApiResponse<IEnumerable<ClaseDto>>.Error($"Error al obtener clases para la clase genérica {codClaseGen} del estrato {codEstrato}", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Obtiene las especialidades activas, opcionalmente filtradas por clase
        /// </summary>
        /// <param name="codClase">Código de la clase (opcional)</param>
        /// <returns>Lista de DTOs de especialidades</returns>
        [HttpGet("especialidades")]
        public async Task<ActionResult<ApiResponse<IEnumerable<EspecialidadDto>>>> GetEspecialidades([FromQuery] string codClase = null!)
        {
            try
            {
                var especialidades = await _combosService.GetEspecialidadesAsync(codClase);
                return Ok(ApiResponse<IEnumerable<EspecialidadDto>>.Ok(especialidades));
            }
            catch (Exception ex)
            {
                string mensaje = string.IsNullOrEmpty(codClase)
                    ? "Error al obtener especialidades"
                    : $"Error al obtener especialidades para la clase {codClase}";

                _logger.LogError(ex, "Error al procesar la solicitud de especialidades. Clase: {CodClase}", codClase ?? "todas");
                return StatusCode(500, ApiResponse<IEnumerable<EspecialidadDto>>.Error(mensaje, "INTERNAL_ERROR"));
            }
        }

        [HttpGet("especialidades/{codEspecialidad}/subespecialidades")]
        public async Task<ActionResult<ApiResponse<IEnumerable<SubespecialidadDto>>>> GetSubespecialidadesByEspecialidad(decimal codEspecialidad)
        {
            try
            {
                var subespecialidades = await _combosService.GetSubespecialidadesByEspecialidadAsync(codEspecialidad);
                return Ok(ApiResponse<IEnumerable<SubespecialidadDto>>.Ok(subespecialidades));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de subespecialidades para la especialidad {CodEspecialidad}", codEspecialidad);
                return StatusCode(500, ApiResponse<IEnumerable<SubespecialidadDto>>.Error($"Error al obtener subespecialidades para la especialidad {codEspecialidad}", "INTERNAL_ERROR"));
            }
        }

        #endregion

        #region Institucional

        [HttpGet("instituciones")]
        public async Task<ActionResult<ApiResponse<IEnumerable<InstitucionDto>>>> GetInstituciones()
        {
            try
            {
                var instituciones = await _combosService.GetInstitucionesAsync();
                return Ok(ApiResponse<IEnumerable<InstitucionDto>>.Ok(instituciones));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de instituciones");
                return StatusCode(500, ApiResponse<IEnumerable<InstitucionDto>>.Error("Error al obtener instituciones", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("instituciones/{codInstitucion}/dependencias")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DependenciaDto>>>> GetDependenciasByInstitucion(decimal codInstitucion)
        {
            try
            {
                var dependencias = await _combosService.GetDependenciasByInstitucionAsync(codInstitucion);
                return Ok(ApiResponse<IEnumerable<DependenciaDto>>.Ok(dependencias));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de dependencias para la institución {CodInstitucion}", codInstitucion);
                return StatusCode(500, ApiResponse<IEnumerable<DependenciaDto>>.Error($"Error al obtener dependencias para la institución {codInstitucion}", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("instituciones/{codInstitucion}/departamentos")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DepartamentoDto>>>> GetDepartamentosByInstitucion(decimal codInstitucion)
        {
            try
            {
                var departamentos = await _combosService.GetDepartamentosByInstitucionAsync(codInstitucion);
                return Ok(ApiResponse<IEnumerable<DepartamentoDto>>.Ok(departamentos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de departamentos para la institución {CodInstitucion}", codInstitucion);
                return StatusCode(500, ApiResponse<IEnumerable<DepartamentoDto>>.Error($"Error al obtener departamentos para la institución {codInstitucion}", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("instituciones/{codInstitucion}/clases/{codClase}/cargos")]
        public async Task<ActionResult<ApiResponse<IEnumerable<CargoDto>>>> GetCargosByInstitucionAndClase(decimal codInstitucion, string codClase)
        {
            try
            {
                var cargos = await _combosService.GetCargosByInstitucionAndClaseAsync(codInstitucion, codClase);
                return Ok(ApiResponse<IEnumerable<CargoDto>>.Ok(cargos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de cargos para la institución {CodInstitucion} y clase {CodClase}", codInstitucion, codClase);
                return StatusCode(500, ApiResponse<IEnumerable<CargoDto>>.Error($"Error al obtener cargos para la institución {codInstitucion} y clase {codClase}", "INTERNAL_ERROR"));
            }
        }

        #endregion

        #region Jornada y Horario

        [HttpGet("jornadas")]
        public async Task<ActionResult<ApiResponse<IEnumerable<JornadaDto>>>> GetJornadas()
        {
            try
            {
                var jornadas = await _combosService.GetJornadasAsync();
                return Ok(ApiResponse<IEnumerable<JornadaDto>>.Ok(jornadas));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de jornadas");
                return StatusCode(500, ApiResponse<IEnumerable<JornadaDto>>.Error("Error al obtener jornadas", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("horarios")]
        public async Task<ActionResult<ApiResponse<IEnumerable<HorarioDto>>>> GetHorarios()
        {
            try
            {
                var horarios = await _combosService.GetHorariosAsync();
                return Ok(ApiResponse<IEnumerable<HorarioDto>>.Ok(horarios));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de horarios");
                return StatusCode(500, ApiResponse<IEnumerable<HorarioDto>>.Error("Error al obtener horarios", "INTERNAL_ERROR"));
            }
        }

        #endregion

        #region Motivos y Resoluciones

        [HttpGet("motivos-vacante")]
        public async Task<ActionResult<ApiResponse<IEnumerable<MotivoVacanteDto>>>> GetMotivosVacante()
        {
            try
            {
                var motivosVacante = await _combosService.GetMotivosVacanteAsync();
                return Ok(ApiResponse<IEnumerable<MotivoVacanteDto>>.Ok(motivosVacante));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de motivos de vacante");
                return StatusCode(500, ApiResponse<IEnumerable<MotivoVacanteDto>>.Error("Error al obtener motivos de vacante", "INTERNAL_ERROR"));
            }
        }

        [HttpGet("tipos-resolucion")]
        public async Task<ActionResult<ApiResponse<IEnumerable<TipoResolucionDto>>>> GetTiposResolucion()
        {
            try
            {
                var tiposResolucion = await _combosService.GetTiposResolucionAsync();
                return Ok(ApiResponse<IEnumerable<TipoResolucionDto>>.Ok(tiposResolucion));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de tipos de resolución");
                return StatusCode(500, ApiResponse<IEnumerable<TipoResolucionDto>>.Error("Error al obtener tipos de resolución", "INTERNAL_ERROR"));
            }
        }

        #endregion

        
    }
}

