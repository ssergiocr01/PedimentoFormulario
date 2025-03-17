using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un estado de un pedimento específico
    /// </summary>
    public class EstadoPedimento
    {
        /// <summary>
        /// Número secuencial del estado
        /// </summary>
        public decimal NumEstado { get; set; }

        /// <summary>
        /// Código del estado
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Observaciones sobre el estado del pedimento
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Anexo al estado del pedimento
        /// </summary>
        public string Anexo { get; set; }

        /// <summary>
        /// Indica si el estado del pedimento está activo
        /// </summary>
        public bool? Activo { get; set; }

        /// <summary>
        /// Fecha desde la que rige el estado
        /// </summary>
        public DateTime? FechaRige { get; set; }

        /// <summary>
        /// Fecha en la que vence el estado
        /// </summary>
        public DateTime? FechaVence { get; set; }

        /// <summary>
        /// Usuario que registró el estado del pedimento
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del estado del pedimento
        /// </summary>
        public DateTime? FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el estado del pedimento
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del estado del pedimento
        /// </summary>
        public DateTime? FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Estado para pedimento asociado
        /// </summary>
        public virtual EstadoParaPedimento EstadoParaPedimento { get; set; }

        /// <summary>
        /// Solicitud de pedimento asociada
        /// </summary>
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }

        #endregion
    }
}

