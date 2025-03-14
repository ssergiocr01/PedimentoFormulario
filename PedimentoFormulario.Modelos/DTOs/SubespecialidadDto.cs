namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para subespecialidades
    /// </summary>
    public class SubespecialidadDto
    {
        /// <summary>
        /// Código de la subespecialidad
        /// </summary>
        public decimal CodSubEspecialidad { get; set; }

        /// <summary>
        /// Código de la especialidad a la que pertenece
        /// </summary>
        public decimal CodEspecialidad { get; set; }

        /// <summary>
        /// Nombre de la subespecialidad
        /// </summary>
        public string NombreSubespecialidad { get; set; }

        /// <summary>
        /// Indica si la subespecialidad está activa
        /// </summary>
        public bool? Activo { get; set; }
    }
}

