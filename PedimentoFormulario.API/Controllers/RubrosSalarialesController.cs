using Microsoft.AspNetCore.Mvc;
using PedimentoFormulario.BLL.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;
using PedimentoFormulario.Modelos.Response;

namespace PedimentoFormulario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubrosSalarialesController : ControllerBase
    {
        private readonly IRubrosSalarialesService _rubrosSalarialesService;
        private readonly ILogger<RubrosSalarialesController> _logger;

        public RubrosSalarialesController(IRubrosSalarialesService rubrosSalarialesService, ILogger<RubrosSalarialesController> logger)
        {
            _rubrosSalarialesService = rubrosSalarialesService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los rubros salariales activos
        /// </summary>
        /// <returns>Lista de rubros salariales</returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RubroSalarial>>>> GetRubrosSalariales()
        {
            try
            {
                var rubrosSalariales = await _rubrosSalarialesService.GetRubrosSalarialesAsync();
                return Ok(ApiResponse<IEnumerable<RubroSalarial>>.Ok(rubrosSalariales));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de rubros salariales");
                return StatusCode(500, ApiResponse<IEnumerable<RubroSalarial>>.Error("Error al obtener rubros salariales", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Obtiene los rubros salariales activos de una institución
        /// </summary>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <returns>Lista de rubros salariales</returns>
        [HttpGet("instituciones/{codInstitucion}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<RubroSalarial>>>> GetRubrosSalarialesByInstitucion(decimal codInstitucion)
        {
            try
            {
                var rubrosSalariales = await _rubrosSalarialesService.GetRubrosSalarialesByInstitucionAsync(codInstitucion);
                return Ok(ApiResponse<IEnumerable<RubroSalarial>>.Ok(rubrosSalariales));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de rubros salariales para la institución {CodInstitucion}", codInstitucion);
                return StatusCode(500, ApiResponse<IEnumerable<RubroSalarial>>.Error($"Error al obtener rubros salariales para la institución {codInstitucion}", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Obtiene un rubro salarial por su código e institución
        /// </summary>
        /// <param name="codRubroSalarial">Código del rubro salarial</param>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <returns>Rubro salarial</returns>
        [HttpGet("{codRubroSalarial}/instituciones/{codInstitucion}")]
        public async Task<ActionResult<ApiResponse<RubroSalarial>>> GetRubroSalarial(decimal codRubroSalarial, decimal codInstitucion)
        {
            try
            {
                var rubroSalarial = await _rubrosSalarialesService.GetRubroSalarialAsync(codRubroSalarial, codInstitucion);

                if (rubroSalarial == null)
                {
                    return NotFound(ApiResponse<RubroSalarial>.Error($"No se encontró el rubro salarial {codRubroSalarial} para la institución {codInstitucion}", "NOT_FOUND"));
                }

                return Ok(ApiResponse<RubroSalarial>.Ok(rubroSalarial));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud del rubro salarial {CodRubroSalarial} para la institución {CodInstitucion}",
                                codRubroSalarial, codInstitucion);
                return StatusCode(500, ApiResponse<RubroSalarial>.Error($"Error al obtener el rubro salarial {codRubroSalarial} para la institución {codInstitucion}", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Obtiene los rubros salariales asociados a pedimentos en ciertos estados
        /// </summary>
        /// <returns>Lista de DTOs con los rubros salariales por pedimento</returns>
        [HttpGet("pedimentos")]
        public async Task<ActionResult<ApiResponse<IEnumerable<RubroPedimentoResultadoDto>>>> GetRubrosPedimento()
        {
            try
            {
                var rubrosPedimento = await _rubrosSalarialesService.GetRubrosPedimentoAsync();
                return Ok(ApiResponse<IEnumerable<RubroPedimentoResultadoDto>>.Ok(rubrosPedimento));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud de rubros salariales por pedimento");
                return StatusCode(500, ApiResponse<IEnumerable<RubroPedimentoResultadoDto>>.Error("Error al obtener rubros salariales por pedimento", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Agrega un rubro salarial a un pedimento
        /// </summary>
        /// <param name="rubroPedimentoDto">DTO con la información del rubro salarial para el pedimento</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost("pedimentos")]
        public async Task<ActionResult<ApiResponse<bool>>> AgregarRubroPedimento(RubroPedimentoDto rubroPedimentoDto)
        {
            try
            {
                if (rubroPedimentoDto == null)
                {
                    return BadRequest(ApiResponse<bool>.Error("La información del rubro salarial para el pedimento es requerida", "BAD_REQUEST"));
                }

                var resultado = await _rubrosSalarialesService.AgregarRubroPedimentoAsync(rubroPedimentoDto);

                if (!resultado)
                {
                    return BadRequest(ApiResponse<bool>.Error("No se pudo agregar el rubro salarial al pedimento", "OPERATION_FAILED"));
                }

                return Ok(ApiResponse<bool>.Ok(true, "Rubro salarial agregado al pedimento correctamente"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud para agregar el rubro salarial {CodRubroSalarial} al pedimento {Pedimento}",
                        rubroPedimentoDto?.cod_rubro_salaria, rubroPedimentoDto?.pedimento);
                return StatusCode(500, ApiResponse<bool>.Error("Error al agregar el rubro salarial al pedimento", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Actualiza un rubro salarial de un pedimento
        /// </summary>
        /// <param name="rubroPedimentoDto">DTO con la información actualizada</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("pedimentos")]
        public async Task<ActionResult<ApiResponse<bool>>> ActualizarRubroPedimento(RubroPedimentoDto rubroPedimentoDto)
        {
            try
            {
                if (rubroPedimentoDto == null)
                {
                    return BadRequest(ApiResponse<bool>.Error("La información del rubro salarial para el pedimento es requerida", "BAD_REQUEST"));
                }

                var resultado = await _rubrosSalarialesService.ActualizarRubroPedimentoAsync(rubroPedimentoDto);

                if (!resultado)
                {
                    return BadRequest(ApiResponse<bool>.Error("No se pudo actualizar el rubro salarial del pedimento", "OPERATION_FAILED"));
                }

                return Ok(ApiResponse<bool>.Ok(true, "Rubro salarial del pedimento actualizado correctamente"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud para actualizar el rubro salarial {CodRubroSalarial} del pedimento {Pedimento}",
                        rubroPedimentoDto?.cod_rubro_salaria, rubroPedimentoDto?.pedimento);
                return StatusCode(500, ApiResponse<bool>.Error("Error al actualizar el rubro salarial del pedimento", "INTERNAL_ERROR"));
            }
        }

        /// <summary>
        /// Elimina un rubro salarial de un pedimento
        /// </summary>
        /// <param name="codRubroSalarial">Código del rubro salarial</param>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <param name="pedimento">Identificador del pedimento</param>
        /// <returns>Resultado de la operación</returns>
        [HttpDelete("{codRubroSalarial}/instituciones/{codInstitucion}/pedimentos/{pedimento}")]
        public async Task<ActionResult<ApiResponse<bool>>> EliminarRubroPedimento(decimal codRubroSalarial, decimal codInstitucion, string pedimento)
        {
            try
            {
                var resultado = await _rubrosSalarialesService.EliminarRubroPedimentoAsync(codRubroSalarial, codInstitucion, pedimento);

                if (!resultado)
                {
                    return BadRequest(ApiResponse<bool>.Error("No se pudo eliminar el rubro salarial del pedimento", "OPERATION_FAILED"));
                }

                return Ok(ApiResponse<bool>.Ok(true, "Rubro salarial eliminado del pedimento correctamente"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar la solicitud para eliminar el rubro salarial {CodRubroSalarial} del pedimento {Pedimento}",
                                codRubroSalarial, pedimento);
                return StatusCode(500, ApiResponse<bool>.Error("Error al eliminar el rubro salarial del pedimento", "INTERNAL_ERROR"));
            }
        }
    }
}

