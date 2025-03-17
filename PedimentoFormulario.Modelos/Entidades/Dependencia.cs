using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una dependencia dentro de una institución
    /// </summary>
    public class Dependencia
    {
        /// <summary>
        /// Código de la dependencia
        /// </summary>
        public decimal CodDependencia { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece la dependencia
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Nombre de la dependencia
        /// </summary>
        public string NombreDependencia { get; set; }

        /// <summary>
        /// Detalles adicionales de la dependencia
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si la dependencia está activa
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró la dependencia
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la dependencia
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la dependencia
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la dependencia
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Institución a la que pertenece la dependencia
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        /// <summary>
        /// Solicitudes de pedimento asociadas a la dependencia
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

