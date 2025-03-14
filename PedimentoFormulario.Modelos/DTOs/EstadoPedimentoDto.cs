using System;

namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para estados de pedimentos
    /// </summary>
    public class EstadoPedimentoDto
    {
        /// <summary>
        /// Número del estado
        /// </summary>
        public decimal NumEstado { get; set; }

        /// <summary>
        /// Código del estado
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Nombre del estado
        /// </summary>
        public string NombreEstado { get; set; }

        /// <summary>
        /// Pedimento asociado
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Observaciones del estado
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Anexo del estado
        /// </summary>
        public string Anexo { get; set; }

        /// <summary>
        /// Indica si el estado está activo
        /// </summary>
        public bool? Activo { get; set; }

        /// <summary>
        /// Fecha desde la que rige el estado
        /// </summary>
        public DateTime? FechaRige { get; set; }

        /// <summary>
        /// Fecha en la que vence el estado
        /// </summary>
        public DateTime? FechaVence { get; set; }

        /// <summary>
        /// Usuario que registró el estado
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del estado
        /// </summary>
        public DateTime? FechaReg { get; set; }
    }
}

