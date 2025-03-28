using System;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa la relación entre un rubro salarial y un pedimento
    /// </summary>
    public class RubroPedimento
    {
        /// <summary>
        /// Código del rubro salarial
        /// </summary>
        public decimal CodRubroSalarial { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Identificador del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Detalles adicionales del rubro salarial para el pedimento
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Fecha de registro
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que registró la relación
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public DateTime FechaMod { get; set; }

        /// <summary>
        /// Usuario que modificó por última vez la relación
        /// </summary>
        public string UsuarioMod { get; set; }

        #region Navegación

        /// <summary>
        /// Rubro salarial asociado
        /// </summary>
        public virtual RubroSalarial RubroSalarial { get; set; }

        /// <summary>
        /// Pedimento asociado
        /// </summary>
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }

        #endregion
    }
}

