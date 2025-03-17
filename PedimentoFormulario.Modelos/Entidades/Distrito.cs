using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un distrito (división administrativa)
    /// </summary>
    public class Distrito
    {
        /// <summary>
        /// Código del distrito
        /// </summary>
        public decimal CodDistrito { get; set; }

        /// <summary>
        /// Código del cantón al que pertenece el distrito
        /// </summary>
        public decimal CodCanton { get; set; }

        /// <summary>
        /// Código de la provincia a la que pertenece el distrito
        /// </summary>
        public decimal CodProvincia { get; set; }

        /// <summary>
        /// Nombre del distrito
        /// </summary>
        public string NombreDistrito { get; set; }

        /// <summary>
        /// Indica si el distrito está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el distrito
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del distrito
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el distrito
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del distrito
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Cantón al que pertenece el distrito
        /// </summary>
        public virtual Canton Canton { get; set; }

        /// <summary>
        /// Solicitudes de pedimento asociadas al distrito
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

