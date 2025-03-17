using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un manual de cargos en el sistema de clasificación
    /// </summary>
    public class ManualDeCargos
    {
        /// <summary>
        /// Código del manual
        /// </summary>
        public decimal CodManual { get; set; }

        /// <summary>
        /// Nombre del manual
        /// </summary>
        public string Manual { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Indica si el manual está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha de creación del manual
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Usuario que registró el manual
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del manual
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el manual
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del manual
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Institución asociada al manual
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        /// <summary>
        /// Cargos asociados al manual
        /// </summary>
        public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

        #endregion
    }
}

