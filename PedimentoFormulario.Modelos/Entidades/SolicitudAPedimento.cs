using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una solicitud relacionada con un pedimento
    /// </summary>
    public class SolicitudAPedimento
    {
        /// <summary>
        /// Número de la solicitud
        /// </summary>
        public decimal NumSolicitud { get; set; }

        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Código del tipo de solicitud
        /// </summary>
        public decimal CodTipoSolicitud { get; set; }

        /// <summary>
        /// Código del motivo
        /// </summary>
        public decimal CodMotivo { get; set; }

        /// <summary>
        /// Justificación de la solicitud
        /// </summary>
        public string Justificacion { get; set; }

        /// <summary>
        /// Anexo a la solicitud
        /// </summary>
        public byte[] Anexo { get; set; }

        /// <summary>
        /// Fecha de finalización
        /// </summary>
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// Usuario que registró la solicitud
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la solicitud
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la solicitud
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Código del estado
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Fecha de modificación de la solicitud
        /// </summary>
        public DateTime? FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Institución asociada a la solicitud
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        /// <summary>
        /// Motivo de vacante asociado a la solicitud
        /// </summary>
        public virtual MotivoVacante MotivoVacante { get; set; }

        /// <summary>
        /// Pedimento asociado a la solicitud
        /// </summary>
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }

        #endregion
    }
}

