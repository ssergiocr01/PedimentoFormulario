using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una jornada laboral
    /// </summary>
    public class Jornada
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
        /// Detalles adicionales de la jornada
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si la jornada está activa
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró la jornada
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la jornada
        /// </summary>
        public DateTime? FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la jornada
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la jornada
        /// </summary>
        public DateTime? FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Solicitudes de pedimento asociadas a esta jornada
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

