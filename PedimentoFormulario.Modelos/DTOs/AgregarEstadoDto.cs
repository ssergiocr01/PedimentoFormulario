namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para agregar un estado a un pedimento
    /// </summary>
    public class AgregarEstadoDto
    {
        /// <summary>
        /// Código del estado
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Usuario que registra el estado
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Observaciones del estado
        /// </summary>
        public string Observaciones { get; set; }
    }
}

