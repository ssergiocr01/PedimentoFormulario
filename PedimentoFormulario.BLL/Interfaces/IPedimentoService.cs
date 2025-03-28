using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Parametros;

namespace PedimentoFormulario.BLL.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de pedimentos de personal
    /// </summary>
    public interface IPedimentoService
    {
        /// <summary>
        /// Consulta pedimentos de personal según los parámetros especificados
        /// </summary>
        /// <param name="parametros">Parámetros de consulta</param>
        /// <returns>Lista de pedimentos que cumplen con los criterios</returns>
        Task<IEnumerable<PedimentoPersonalDto>> ConsultarPedimentosAsync(ConsultaPedimentoParams parametros);

        /// <summary>
        /// Agrega un nuevo pedimento de personal
        /// </summary>
        /// <param name="pedimento">Datos del pedimento a agregar</param>
        /// <returns>Código del pedimento generado</returns>
        Task<string> AgregarPedimentoAsync(InsertarPedimentoPersonalDto pedimento);        
    }
}