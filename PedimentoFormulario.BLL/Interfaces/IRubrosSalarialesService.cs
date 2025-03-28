using PedimentoFormulario.Modelos.DTOs;
using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.BLL.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de rubros salariales
    /// </summary>
    public interface IRubrosSalarialesService
    {
        /// <summary>
        /// Obtiene todos los rubros salariales activos
        /// </summary>
        /// <returns>Lista de rubros salariales</returns>
        Task<IEnumerable<RubroSalarial>> GetRubrosSalarialesAsync();

        /// <summary>
        /// Obtiene los rubros salariales activos de una institución
        /// </summary>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <returns>Lista de rubros salariales</returns>
        Task<IEnumerable<RubroSalarial>> GetRubrosSalarialesByInstitucionAsync(decimal codInstitucion);

        /// <summary>
        /// Obtiene un rubro salarial por su código e institución
        /// </summary>
        /// <param name="codRubroSalarial">Código del rubro salarial</param>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <returns>Rubro salarial</returns>
        Task<RubroSalarial> GetRubroSalarialAsync(decimal codRubroSalarial, decimal codInstitucion);

        /// <summary>
        /// Obtiene los rubros salariales asociados a pedimentos en ciertos estados
        /// </summary>
        /// <returns>Lista de DTOs con los rubros salariales por pedimento</returns>
        Task<IEnumerable<RubroPedimentoResultadoDto>> GetRubrosPedimentoAsync();

        /// <summary>
        /// Agrega un rubro salarial a un pedimento
        /// </summary>
        /// <param name="rubroPedimentoDto">DTO con la información del rubro salarial para el pedimento</param>
        /// <returns>True si se agregó correctamente, False en caso contrario</returns>
        Task<bool> AgregarRubroPedimentoAsync(RubroPedimentoDto rubroPedimentoDto);

        /// <summary>
        /// Actualiza un rubro salarial de un pedimento
        /// </summary>
        /// <param name="rubroPedimentoDto">DTO con la información actualizada</param>
        /// <returns>True si se actualizó correctamente, False en caso contrario</returns>
        Task<bool> ActualizarRubroPedimentoAsync(RubroPedimentoDto rubroPedimentoDto);

        /// <summary>
        /// Elimina un rubro salarial de un pedimento
        /// </summary>
        /// <param name="codRubroSalarial">Código del rubro salarial</param>
        /// <param name="codInstitucion">Código de la institución</param>
        /// <param name="pedimento">Identificador del pedimento</param>
        /// <returns>True si se eliminó correctamente, False en caso contrario</returns>
        Task<bool> EliminarRubroPedimentoAsync(decimal codRubroSalarial, decimal codInstitucion, string pedimento);
    }
}

