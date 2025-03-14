namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para departamentos
    /// </summary>
    public class DepartamentoDto
    {
        /// <summary>
        /// Código del departamento
        /// </summary>
        public decimal CodDepartamento { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Nombre del departamento
        /// </summary>
        public string NombreDepartamento { get; set; }

        /// <summary>
        /// Indica si el departamento está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

