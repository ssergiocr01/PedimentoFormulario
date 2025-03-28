namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para la inserción de un nuevo estado de pedimento
    /// </summary>
    public class InsertarEstadoPedimentoDto
    {
        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Usuario que realiza la operación
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Código del estado a asignar
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Observaciones sobre el cambio de estado
        /// </summary>
        public string Observaciones { get; set; }
    }
}

