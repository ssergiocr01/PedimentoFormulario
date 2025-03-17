using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una firma en un pedimento
    /// </summary>
    public class FirmaPedimento
    {
        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la firma
        /// </summary>
        public string CodFirma { get; set; }

        /// <summary>
        /// Tipo de firma
        /// </summary>
        public decimal TipoFirma { get; set; }

        /// <summary>
        /// Nombre de la persona que firma
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Observaciones sobre la firma
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Usuario que registró la firma
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la firma
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la firma
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la firma
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Solicitud de pedimento asociada
        /// </summary>
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }

        #endregion
    }
}

