using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una provincia (división administrativa)
    /// </summary>
    public class Provincia
    {
        /// <summary>
        /// Código de la provincia
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Nombre de la provincia
        /// </summary>
        public string NombreProvincia { get; set; }

        /// <summary>
        /// Indica si la provincia está activa
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró la provincia
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la provincia
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la provincia
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la provincia
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Cantones que pertenecen a esta provincia
        /// </summary>
        public virtual ICollection<Canton> Cantones { get; set; } = new List<Canton>();

        /// <summary>
        /// Solicitudes de pedimento asociadas a esta provincia
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

