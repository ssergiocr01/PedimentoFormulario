using Dapper;
using Microsoft.AspNetCore.Mvc;
using PedimentoFormulario.BLL.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Parametros;
using PedimentoFormulario.Modelos.Response;

namespace PedimentoFormulario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedimentosController : ControllerBase
    {
        private readonly IPedimentoService _pedimentoService; private readonly ILogger<PedimentosController> _logger;

        public PedimentosController(IPedimentoService pedimentoService, ILogger<PedimentosController> logger)
        {
            _pedimentoService = pedimentoService;
            _logger = logger;
        }

        /// <summary>
        /// Consulta pedimentos de personal según los criterios especificados
        /// </summary>
        /// <param name="pedimento">Código del pedimento específico a consultar (opcional)</param>
        /// <param name="codInstitucion">Código de la institución a filtrar (0=todas)</param>
        /// <returns>Lista de pedimentos que cumplen con los criterios de búsqueda</returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PedimentoPersonalDto>>>> ConsultarPedimentos(
            [FromQuery] string pedimento = "",
            [FromQuery] decimal codInstitucion = 0)
        {
            try
            {
                var parametros = new ConsultaPedimentoParams
                {
                    Pedimento = pedimento,
                    CodInstitucion = codInstitucion
                };

                var pedimentos = await _pedimentoService.ConsultarPedimentosAsync(parametros);
                return Ok(ApiResponse<IEnumerable<PedimentoPersonalDto>>.Ok(pedimentos));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de consulta de pedimentos");
                return StatusCode(500, ApiResponse<IEnumerable<PedimentoPersonalDto>>.Error("Error al consultar pedimentos", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Consulta un pedimento específico por su código de pedimento
        /// </summary>
        /// <param name="codigoPedimento">Código del pedimento</param>
        /// <returns>Pedimento solicitado</returns>
        [HttpGet("{codigoPedimento}")]
        public async Task<ActionResult<ApiResponse<PedimentoPersonalDto>>> ConsultarPedimentoPorCodigo(
            string codigoPedimento)
        {
            try
            {
                var parametros = new ConsultaPedimentoParams
                {
                    Pedimento = codigoPedimento,
                    CodInstitucion = 0 // Todas las instituciones
                };

                var pedimentos = await _pedimentoService.ConsultarPedimentosAsync(parametros);
                var pedimento = pedimentos.AsList().Count > 0 ? pedimentos.AsList()[0] : null;

                if (pedimento == null)
                    return NotFound(ApiResponse<PedimentoPersonalDto>.Error($"No se encontró el pedimento con código {codigoPedimento}", "NOT_FOUND"));

                return Ok(ApiResponse<PedimentoPersonalDto>.Ok(pedimento));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de consulta de pedimento por código: {CodigoPedimento}", codigoPedimento);
                return StatusCode(500, ApiResponse<PedimentoPersonalDto>.Error($"Error al consultar el pedimento con código {codigoPedimento}", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Agrega un nuevo pedimento de personal
        /// </summary>
        /// <param name="pedimento">Datos del pedimento a agregar</param>
        /// <returns>Código del pedimento generado</returns>
        [HttpPost]
        public async Task<ActionResult<ApiResponse<string>>> AgregarPedimento([FromBody] InsertarPedimentoPersonalDto pedimento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ApiResponse<string>.Error("Datos de pedimento inválidos", "INVALID_DATA"));
                }

                var codigoPedimento = await _pedimentoService.AgregarPedimentoAsync(pedimento);

                return Ok(ApiResponse<string>.Ok(codigoPedimento, "Pedimento agregado exitosamente"));
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Error de validación al agregar pedimento: {Message}", ex.Message);
                return BadRequest(ApiResponse<string>.Error(ex.Message, "VALIDATION_ERROR"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de agregar pedimento");
                return StatusCode(500, ApiResponse<string>.Error("Error al agregar pedimento", "INTERNAL_ERROR"));
            }
        }
    }
}