using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una subespecialidad en el sistema de clasificación
    /// </summary>
    public class SubEspecialidad
    {
        /// <summary>
        /// Código de la subespecialidad
        /// </summary>
        public decimal CodSubEspecialidad { get; set; }

        /// <summary>
        /// Código de la especialidad a la que pertenece la subespecialidad
        /// </summary>
        public decimal CodEspecialidad { get; set; }

        /// <summary>
        /// Nombre de la subespecialidad
        /// </summary>
        public string NombreSubespecialidad { get; set; }

        /// <summary>
        /// Observaciones sobre la subespecialidad
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Resolución que establece la subespecialidad
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
        /// Indica si la subespecialidad está activa
        /// </summary>
        public bool? Activo { get; set; }

        /// <summary>
        /// Usuario que registró la subespecialidad
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la subespecialidad
        /// </summary>
        public DateTime? FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la subespecialidad
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la subespecialidad
        /// </summary>
        public DateTime? FechaMod { get; set; }

        /// <summary>
        /// Nota adicional sobre la subespecialidad
        /// </summary>
        public string Nota { get; set; }

        #region Navegación

        /// <summary>
        /// Especialidad a la que pertenece la subespecialidad
        /// </summary>
        public virtual Especialidad Especialidad { get; set; }

        /// <summary>
        /// Solicitudes de pedimento asociadas a esta subespecialidad
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

