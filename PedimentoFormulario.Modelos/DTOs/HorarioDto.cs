namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para horarios
    /// </summary>
    public class HorarioDto
    {
        /// <summary>
        /// Código del horario
        /// </summary>
        public decimal CodHorario { get; set; }

        /// <summary>
        /// Nombre del horario
        /// </summary>
        public string NombreHorario { get; set; }

        /// <summary>
        /// Detalles del horario
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si el horario está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

