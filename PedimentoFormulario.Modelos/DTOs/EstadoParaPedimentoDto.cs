namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para estados para pedimentos
    /// </summary>
    public class EstadoParaPedimentoDto
    {
        /// <summary>
        /// Código del estado
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Nombre del estado
        /// </summary>
        public string NombreEstado { get; set; }

        /// <summary>
        /// Descripción del estado
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Indica si el estado está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

