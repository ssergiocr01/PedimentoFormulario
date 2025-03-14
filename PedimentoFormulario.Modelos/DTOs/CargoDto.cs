namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para cargos
    /// </summary>
    public class CargoDto
    {
        /// <summary>
        /// Código del cargo
        /// </summary>
        public decimal CodCargo { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Código de la clase a la que pertenece
        /// </summary>
        public string CodClase { get; set; }

        /// <summary>
        /// Nombre del cargo
        /// </summary>
        public string NombreCargo { get; set; }

        /// <summary>
        /// Indica si el cargo está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

