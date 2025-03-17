using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un estado posible para los pedimentos
    /// </summary>
    public class EstadoParaPedimento
    {
        /// <summary>
        /// Código del estado
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Nombre del estado
        /// </summary>
        public string NombreEstado { get; set; }

        /// <summary>
        /// Descripción del estado
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Indica si el estado está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el estado
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del estado
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el estado
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del estado
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Estados de pedimentos que utilizan este estado
        /// </summary>
        public virtual ICollection<EstadoPedimento> EstadosPedimento { get; set; } = new List<EstadoPedimento>();

        #endregion
    }
}

