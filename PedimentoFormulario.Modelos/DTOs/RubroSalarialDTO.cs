namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para representar un rubro salarial
    /// </summary>
    public class RubroSalarialDto
    {
        /// <summary>
        /// Código del rubro salarial
        /// </summary>
        public decimal CodRubroSalarial { get; set; }

        /// <summary>
        /// Nombre del rubro salarial
        /// </summary>
        public string NombreRubroSalarial { get; set; }

        /// <summary>
        /// Indica si el rubro salarial está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece el rubro salarial
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Detalles adicionales del rubro salarial
        /// </summary>
        public string Detalles { get; set; }
    }
}

