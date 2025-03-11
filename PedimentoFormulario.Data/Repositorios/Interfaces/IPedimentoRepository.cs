using PedimentoFormulario.Modelos.Entidades;

namespace PedimentoFormulario.Data.Repositorios.Interfaces
{
    public interface IPedimentoRepository
    {
        /// <summary>
        /// Obtiene una lista de solicitudes de pedimento de personal según los criterios de consulta
        /// </summary>
        /// <param name="tipoConsulta">Tipo de consulta (0-22)</param>
        /// <param name="mini">Indica si se desea un resultado resumido</param>
        /// <param name="pedimento">Código de pedimento específico (opcional)</param>
        /// <param name="codInstitucion">Código de institución (0 para todas)</param>
        /// <returns>Lista de solicitudes de pedimento que cumplen con los criterios</returns>
        Task<IEnumerable<SolicitudPedimentoPersonal>> GetPedimentosAsync(int tipoConsulta, bool mini, string? pedimento = null, int codInstitucion = 0);
    }
}