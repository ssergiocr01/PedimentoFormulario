using Microsoft.AspNetCore.Mvc;
using PedimentoFormulario.BLL.Servicios.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Responses;

namespace PedimentoFormulario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedimentosController : ControllerBase
    {
        private readonly IPedimentoService _pedimentoService;

        public PedimentosController(IPedimentoService pedimentoService)
        {
            _pedimentoService = pedimentoService ?? throw new ArgumentNullException(nameof(pedimentoService));
        }

        /// <summary>
        /// Obtiene una lista de pedimentos según los criterios especificados
        /// </summary>
        /// <param name="tipoConsulta">Tipo de consulta (0-22)</param>
        /// <param name="mini">Indica si se desea un resultado resumido</param>
        /// <param name="pedimento">Código de pedimento específico (opcional)</param>
        /// <param name="codInstitucion">Código de institución (0 para todas)</param>
        /// <returns>Lista de pedimentos que cumplen con los criterios</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<SolicitudPedimentoPersonalDto>>), 200)]
        [ProducesResponseType(typeof(ApiResponse<string>), 400)]
        [ProducesResponseType(typeof(ApiResponse<string>), 500)]
        public async Task<IActionResult> GetPedimentos(
            [FromQuery] int tipoConsulta = 9,
            [FromQuery] bool mini = false,
            [FromQuery] string? pedimento = null,
            [FromQuery] int codInstitucion = 0)
        {
            try
            {
                var pedimentos = await _pedimentoService.GetPedimentosAsync(tipoConsulta, mini, pedimento, codInstitucion);

                var response = new ApiResponse<IEnumerable<SolicitudPedimentoPersonalDto>>
                {
                    Success = true,
                    Data = pedimentos,
                    Message = "Pedimentos obtenidos exitosamente"
                };

                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                var response = new ApiResponse<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse<string>
                {
                    Success = false,
                    Message = "Error al obtener los pedimentos",
                    Data = ex.Message
                };

                return StatusCode(500, response);
            }
        }
    }
}