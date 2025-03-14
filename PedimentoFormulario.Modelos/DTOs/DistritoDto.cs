namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para distritos
    /// </summary>
    public class DistritoDto
    {
        /// <summary>
        /// Código del distrito
        /// </summary>
        public decimal CodDistrito { get; set; }

        /// <summary>
        /// Código del cantón al que pertenece
        /// </summary>
        public decimal CodCanton { get; set; }

        /// <summary>
        /// Código de la provincia a la que pertenece
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Nombre del distrito
        /// </summary>
        public string NombreDistrito { get; set; }

        /// <summary>
        /// Indica si el distrito está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

