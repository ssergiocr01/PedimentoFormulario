using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una institución
    /// </summary>
    public class Institucion
    {
        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Nombre de la institución
        /// </summary>
        public string NombreInstitucion { get; set; }

        /// <summary>
        /// Sigla de la institución
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// Indica si la institución tiene reclutamiento
        /// </summary>
        public bool Reclutamiento { get; set; }

        /// <summary>
        /// Indica si la institución está activa
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró la institución
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la institución
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la institución
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la institución
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Dependencias que pertenecen a esta institución
        /// </summary>
        public virtual ICollection<Dependencia> Dependencias { get; set; } = new List<Dependencia>();

        /// <summary>
        /// Departamentos que pertenecen a esta institución
        /// </summary>
        public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();

        /// <summary>
        /// Solicitudes de pedimento asociadas a esta institución
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        /// <summary>
        /// Solicitudes a pedimento asociadas a esta institución
        /// </summary>
        public virtual ICollection<SolicitudAPedimento> SolicitudesAPedimento { get; set; } = new List<SolicitudAPedimento>();

        #endregion
    }
}

