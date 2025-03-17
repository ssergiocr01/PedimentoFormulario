using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un motivo de vacante
    /// </summary>
    public class MotivoVacante
    {
        /// <summary>
        /// Código del motivo
        /// </summary>
        public decimal CodMotivo { get; set; }

        /// <summary>
        /// Nombre del motivo
        /// </summary>
        public string NombreMotivo { get; set; }

        /// <summary>
        /// Detalles adicionales del motivo
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si el motivo está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el motivo
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del motivo
        /// </summary>
        public DateTime? FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el motivo
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del motivo
        /// </summary>
        public DateTime? FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Solicitudes de pedimento asociadas a este motivo
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        /// <summary>
        /// Solicitudes a pedimento asociadas a este motivo
        /// </summary>
        public virtual ICollection<SolicitudAPedimento> SolicitudesAPedimento { get; set; } = new List<SolicitudAPedimento>();

        #endregion
    }
}

