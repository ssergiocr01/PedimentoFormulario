namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para especialidades
    /// </summary>
    public class EspecialidadDto
    {
        /// <summary>
        /// Código de la especialidad
        /// </summary>
        public decimal CodEspecialidad { get; set; }

        /// <summary>
        /// Nombre de la especialidad
        /// </summary>
        public string NombreEspecialidad { get; set; }

        /// <summary>
        /// Indica si la especialidad está activa
        /// </summary>
        public bool? Activo { get; set; }
    }
}

