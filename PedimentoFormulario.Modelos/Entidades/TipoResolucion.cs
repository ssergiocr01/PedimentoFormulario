using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un tipo de resolución para pedimentos
    /// </summary>
    public class TipoResolucion
    {
        /// <summary>
        /// Código del tipo de resolución
        /// </summary>
        public decimal CodTipoResolucion { get; set; }

        /// <summary>
        /// Nombre del tipo de resolución
        /// </summary>
        public string NombreTipoResolucion { get; set; }

        /// <summary>
        /// Indica si el tipo de resolución está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el tipo de resolución
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del tipo de resolución
        /// </summary>
        public DateTime? FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el tipo de resolución
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del tipo de resolución
        /// </summary>
        public DateTime? FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Solicitudes de pedimento asociadas a este tipo de resolución
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

