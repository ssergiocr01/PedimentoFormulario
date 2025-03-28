using Microsoft.Extensions.Logging;
using PedimentoFormulario.BLL.Interfaces;
using PedimentoFormulario.Data.Interfaces;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Parametros;

namespace PedimentoFormulario.BLL.Services
{
    public class PedimentoService : IPedimentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PedimentoService> _logger;

        public PedimentoService(IUnitOfWork unitOfWork, ILogger<PedimentoService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PedimentoPersonalDto>> ConsultarPedimentosAsync(ConsultaPedimentoParams parametros)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de pedimentos con parámetros: {@Parametros}", parametros);

                var pedimentos = await _unitOfWork.Pedimentos.ConsultarPedimentosAsync(parametros);

                _logger.LogInformation("Consulta de pedimentos completada exitosamente");

                return pedimentos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al consultar pedimentos con parámetros: {@Parametros}", parametros);
                throw;
            }
        }

        /// <inheritdoc/>
        public async Task<string> AgregarPedimentoAsync(InsertarPedimentoPersonalDto pedimento)
        {
            try
            {
                _logger.LogInformation("Iniciando proceso de agregar pedimento para institución {CodInstitucion}, dependencia {CodDependencia}, puesto {NumPuesto}",
                    pedimento.CodInstitucion, pedimento.CodDependencia, pedimento.NumPuesto);

                // Validaciones de negocio (si son necesarias)
                if (string.IsNullOrEmpty(pedimento.Usuario))
                {
                    throw new ArgumentException("El usuario es requerido para agregar un pedimento");
                }

                var codigoPedimento = await _unitOfWork.Pedimentos.AgregarPedimentoAsync(pedimento);

                _logger.LogInformation("Pedimento agregado exitosamente con código {CodigoPedimento}", codigoPedimento);

                return codigoPedimento;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar pedimento para institución {CodInstitucion}, dependencia {CodDependencia}, puesto {NumPuesto}",
                    pedimento.CodInstitucion, pedimento.CodDependencia, pedimento.NumPuesto);
                throw;
            }
        }



    }
}