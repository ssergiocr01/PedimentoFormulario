namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para motivos de vacante
    /// </summary>
    public class MotivoVacanteDto
    {
        /// <summary>
        /// Código del motivo de vacante
        /// </summary>
        public decimal CodMotivo { get; set; }

        /// <summary>
        /// Nombre del motivo de vacante
        /// </summary>
        public string NombreMotivo { get; set; }

        /// <summary>
        /// Detalles del motivo de vacante
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si el motivo de vacante está activo
        /// </summary>
        public bool Activo { get; set; }
    }
}

