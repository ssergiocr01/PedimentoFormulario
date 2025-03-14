namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para estratos
    /// </summary>
    public class EstratoDto
    {
        /// <summary>
        /// Código del estrato
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Nombre del estrato
        /// </summary>
        public string NombreEstrato { get; set; }

        /// <summary>
        /// Descripción del estrato
        /// </summary>
        public string DescEstratos { get; set; }

        /// <summary>
        /// Indica si el estrato está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

