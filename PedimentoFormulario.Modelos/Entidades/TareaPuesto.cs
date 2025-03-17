using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una tarea asociada a un puesto
    /// </summary>
    public class TareaPuesto
    {
        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la tarea (auto-incrementable)
        /// </summary>
        public decimal CodTarea { get; set; }

        /// <summary>
        /// Descripción de la tarea
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

        /// <summary>
        /// Usuario que modificó la tarea
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la tarea
        /// </summary>
        public DateTime? FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Solicitud de pedimento asociada
        /// </summary>
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }

        #endregion
    }
}

