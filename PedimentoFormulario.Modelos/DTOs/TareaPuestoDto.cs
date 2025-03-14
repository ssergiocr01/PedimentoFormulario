using System;

namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para tareas de puesto
    /// </summary>
    public class TareaPuestoDto
    {
        /// <summary>
        /// Pedimento asociado
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la tarea
        /// </summary>
        public decimal CodTarea { get; set; }

        /// <summary>
        /// Nombre de la tarea
        /// </summary>
        public string Tarea { get; set; }

        /// <summary>
        /// Detalle de la tarea
        /// </summary>
        public string DetalleTarea { get; set; }

        /// <summary>
        /// Frecuencia de la tarea
        /// </summary>
        public string Frecuencia { get; set; }

        /// <summary>
        /// Usuario que registró la tarea
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la tarea
        /// </summary>
        public DateTime? FechaReg { get; set; }
    }
}

