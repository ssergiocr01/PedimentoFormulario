using System.Collections.Generic;
using System.Threading.Tasks;
using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Parametros;

namespace PedimentoFormulario.Data.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de pedimentos de personal
    /// </summary>
    public interface IPedimentoRepository
    {
        #region Métodos existentes

        /// <summary>
        /// Consulta pedimentos según los parámetros especificados
        /// </summary>
        /// <param name="parametros">Parámetros de consulta</param>
        /// <returns>Lista de pedimentos que cumplen con los criterios</returns>
        Task<IEnumerable<PedimentoPersonalDto>> ConsultarPedimentosAsync(ConsultaPedimentoParams parametros);

        /// <summary>
        /// Agrega un nuevo pedimento
        /// </summary>
        /// <param name="pedimento">DTO con la información del pedimento</param>
        /// <returns>Código del pedimento generado</returns>
        Task<string> AgregarPedimentoAsync(InsertarPedimentoPersonalDto pedimento);       

        #endregion
    }
}

