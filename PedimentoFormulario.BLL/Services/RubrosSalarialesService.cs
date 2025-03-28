using Microsoft.Extensions.Logging;
using PedimentoFormulario.BLL.Interfaces;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.BLL.Services
{
    /// <summary>
    /// Implementación del servicio de rubros salariales
    /// </summary>
    public class RubrosSalarialesService : IRubrosSalarialesService
    {
        private readonly IRubrosSalarialesRepository _rubrosSalarialesRepository;
        private readonly ILogger<RubrosSalarialesService> _logger;

        /// <summary>
        /// Constructor del servicio de rubros salariales
        /// </summary>
        /// <param name="rubrosSalarialesRepository">Repositorio de rubros salariales</param>
        /// <param name="logger">Logger para registrar eventos</param>
        public RubrosSalarialesService(IRubrosSalarialesRepository rubrosSalarialesRepository, ILogger<RubrosSalarialesService> logger)
        {
            _rubrosSalarialesRepository = rubrosSalarialesRepository;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RubroSalarial>> GetRubrosSalarialesAsync()
        {
            try
            {
                return await _rubrosSalarialesRepository.GetRubrosSalarialesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubros salariales");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RubroSalarial>> GetRubrosSalarialesByInstitucionAsync(decimal codInstitucion)
        {
            try
            {
                return await _rubrosSalarialesRepository.GetRubrosSalarialesByInstitucionAsync(codInstitucion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubros salariales para la institución {CodInstitucion}", codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<RubroSalarial> GetRubroSalarialAsync(decimal codRubroSalarial, decimal codInstitucion)
        {
            try
            {
                return await _rubrosSalarialesRepository.GetRubroSalarialAsync(codRubroSalarial, codInstitucion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubro salarial {CodRubroSalarial} para la institución {CodInstitucion}",
                                codRubroSalarial, codInstitucion);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<RubroPedimentoResultadoDto>> GetRubrosPedimentoAsync()
        {
            try
            {
                return await _rubrosSalarialesRepository.GetRubrosPedimentoAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener rubros salariales por pedimento");
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> AgregarRubroPedimentoAsync(RubroPedimentoDto rubroPedimentoDto)
        {
            try
            {
                // Validar que el rubro salarial exista
                var rubroSalarial = await _rubrosSalarialesRepository.GetRubroSalarialAsync(
                    rubroPedimentoDto.cod_rubro_salaria, rubroPedimentoDto.cod_institucion);

                if (rubroSalarial == null)
                {
                    _logger.LogWarning("El rubro salarial {CodRubroSalarial} para la institución {CodInstitucion} no existe",
                                    rubroPedimentoDto.cod_rubro_salaria, rubroPedimentoDto.cod_institucion);
                    return false;
                }

                return await _rubrosSalarialesRepository.AgregarRubroPedimentoAsync(rubroPedimentoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar rubro salarial {CodRubroSalarial} para el pedimento {Pedimento}",
                        rubroPedimentoDto.cod_rubro_salaria, rubroPedimentoDto.pedimento);
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> ActualizarRubroPedimentoAsync(RubroPedimentoDto rubroPedimentoDto)
        {
            try
            {
                return await _rubrosSalarialesRepository.ActualizarRubroPedimentoAsync(rubroPedimentoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar rubro salarial {CodRubroSalarial} para el pedimento {Pedimento}",
                                rubroPedimentoDto.cod_rubro_salaria, rubroPedimentoDto.pedimento);
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> EliminarRubroPedimentoAsync(decimal codRubroSalarial, decimal codInstitucion, string pedimento)
        {
            try
            {
                return await _rubrosSalarialesRepository.EliminarRubroPedimentoAsync(codRubroSalarial, codInstitucion, pedimento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar rubro salarial {CodRubroSalarial} para el pedimento {Pedimento}",
                                codRubroSalarial, pedimento);
                return false;
            }
        }
    }
}

