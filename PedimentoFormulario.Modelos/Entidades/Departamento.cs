using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un departamento dentro de una institución
    /// </summary>
    public class Departamento
    {
        /// <summary>
        /// Código del departamento
        /// </summary>
        public decimal CodDepartamento { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece el departamento
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Nombre del departamento
        /// </summary>
        public string NombreDepartamento { get; set; }

        /// <summary>
        /// Detalles adicionales del departamento
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Indica si el departamento está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el departamento
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del departamento
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el departamento
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del departamento
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Institución a la que pertenece el departamento
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        /// <summary>
        /// Solicitudes de pedimento asociadas al departamento
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

