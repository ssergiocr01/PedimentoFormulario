namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para tipos de resolución (para combos)
    /// </summary>
    public class TipoResolucionDto
    {
        /// <summary>
        /// Código del tipo de resolución
        /// </summary>
        public decimal CodTipoResolucion { get; set; }

        /// <summary>
        /// Nombre del tipo de resolución
        /// </summary>
        public string NombreTipoResolucion { get; set; }

        /// <summary>
        /// Indica si el tipo de resolución está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

