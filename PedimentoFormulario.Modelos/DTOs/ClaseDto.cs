namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para clases
    /// </summary>
    public class ClaseDto
    {
        /// <summary>
        /// Código de la clase
        /// </summary>
        public string CodClase { get; set; }

        /// <summary>
        /// Código del estrato al que pertenece
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Código de la clase genérica a la que pertenece
        /// </summary>
        public decimal CodClaseGen { get; set; }

        /// <summary>
        /// Título de la clase
        /// </summary>
        public string TituloDeLaClase { get; set; }

        /// <summary>
        /// Indica si la clase está activa
        /// </summary>
        public bool Activo { get; set; }
    }
}

