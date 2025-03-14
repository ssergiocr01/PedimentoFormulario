namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para clases genéricas
    /// </summary>
    public class ClaseGenericaDto
    {
        /// <summary>
        /// Código de la clase genérica
        /// </summary>
        public decimal CodClaseGen { get; set; }

        /// <summary>
        /// Código del estrato al que pertenece
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Nombre de la clase genérica
        /// </summary>
        public string NombreGenerica { get; set; }

        /// <summary>
        /// Indica si la clase genérica está activa
        /// </summary>
        public bool? Activo { get; set; }
    }
}

