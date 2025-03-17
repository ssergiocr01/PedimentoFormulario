using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una especialidad en el sistema de clasificación
    /// </summary>
    public class Especialidad
    {
        /// <summary>
        /// Código de la especialidad
        /// </summary>
        public decimal CodEspecialidad { get; set; }

        /// <summary>
        /// Nombre de la especialidad
        /// </summary>
        public string NombreEspecialidad { get; set; }

        /// <summary>
        /// Observaciones sobre la especialidad
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Resolución que establece la especialidad
        /// </summary>
        public string Resolucion { get; set; }

        /// <summary>
        /// Fecha de la resolución
        /// </summary>
        public string FechaRes { get; set; }

        /// <summary>
        /// Gaceta donde se publicó la resolución
        /// </summary>
        public string Gaceta { get; set; }

        /// <summary>
        /// Fecha de la gaceta
        /// </summary>
        public string FechaGaceta { get; set; }

        /// <summary>
        /// Vínculo al documento PDF
        /// </summary>
        public string VinculoDocPfd { get; set; }

        /// <summary>
        /// Indica si la especialidad está activa
        /// </summary>
        public bool? Activo { get; set; }

        /// <summary>
        /// Usuario que registró la especialidad
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la especialidad
        /// </summary>
        public DateTime? FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la especialidad
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la especialidad
        /// </summary>
        public DateTime? FechaMod { get; set; }

        /// <summary>
        /// Observaciones adicionales
        /// </summary>
        public string Observ { get; set; }

        #region Navegación

        /// <summary>
        /// Subespecialidades que pertenecen a esta especialidad
        /// </summary>
        public virtual ICollection<SubEspecialidad> SubEspecialidades { get; set; } = new List<SubEspecialidad>();

        /// <summary>
        /// Solicitudes de pedimento asociadas a esta especialidad
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

