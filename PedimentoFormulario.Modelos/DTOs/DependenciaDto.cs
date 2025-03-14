namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para dependencias
    /// </summary>
    public class DependenciaDto
    {
        /// <summary>
        /// Código de la dependencia
        /// </summary>
        public decimal CodDependencia { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Nombre de la dependencia
        /// </summary>
        public string NombreDependencia { get; set; }

        /// <summary>
        /// Indica si la dependencia está activa
        /// </summary>
        public bool Activo { get; set; }
    }
}

