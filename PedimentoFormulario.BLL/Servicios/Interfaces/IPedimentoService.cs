using PedimentoFormulario.Modelos.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PedimentoFormulario.BLL.Servicios.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de pedimentos
    /// </summary>
    public interface IPedimentoService
    {
        /// <summary>
        /// Obtiene una lista de solicitudes de pedimento según los criterios especificados
        /// </summary>
        /// <param name="tipoConsulta">Tipo de consulta (0-22)</param>
        /// <param name="mini">Indica si se desea un resultado resumido</param>
        /// <param name="pedimento">Código de pedimento específico (opcional)</param>
        /// <param name="codInstitucion">Código de institución (0 para todas)</param>
        /// <returns>Lista de DTOs de solicitudes de pedimento</returns>
        Task<IEnumerable<SolicitudPedimentoPersonalDto>> GetPedimentosAsync(int tipoConsulta, bool mini, string? pedimento = null, int codInstitucion = 0);
    }
}