namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para provincias
    /// </summary>
    public class ProvinciaDto
    {
        /// <summary>
        /// Código de la provincia
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Nombre de la provincia
        /// </summary>
        public string NombreProvincia { get; set; }

        /// <summary>
        /// Indica si la provincia está activa
        /// </summary>
        public bool Activo { get; set; }
    }
}

