namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para jornadas
    /// </summary>
    public class JornadaDto
    {
        /// <summary>
        /// Código de la jornada
        /// </summary>
        public decimal CodJornada { get; set; }

        /// <summary>
        /// Nombre de la jornada
        /// </summary>
        public string NombreJornada { get; set; }

        /// <summary>
        /// Detalles de la jornada
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si la jornada está activa
        /// </summary>
        public bool Activo { get; set; }
    }
}

