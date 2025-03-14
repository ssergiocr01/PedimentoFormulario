namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para cantones
    /// </summary>
    public class CantonDto
    {
        /// <summary>
        /// Código del cantón
        /// </summary>
        public decimal CodCanton { get; set; }

        /// <summary>
        /// Código de la provincia a la que pertenece
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Nombre del cantón
        /// </summary>
        public string NombreCanton { get; set; }

        /// <summary>
        /// Indica si el cantón está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

