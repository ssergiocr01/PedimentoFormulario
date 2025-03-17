using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un horario laboral
    /// </summary>
    public class Horario
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
        /// Detalles adicionales del horario
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si el horario está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el horario
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del horario
        /// </summary>
        public DateTime? FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el horario
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del horario
        /// </summary>
        public DateTime? FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Solicitudes de pedimento asociadas a este horario
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

