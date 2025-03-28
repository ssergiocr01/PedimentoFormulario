using System;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un rubro salarial en el sistema
    /// </summary>
    public class RubroSalarial
    {
        /// <summary>
        /// Código del rubro salarial
        /// </summary>
        public decimal CodRubroSalarial { get; set; }

        /// <summary>
        /// Nombre del rubro salarial
        /// </summary>
        public string NombreRubroSalarial { get; set; }

        /// <summary>
        /// Indica si el rubro salarial está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece el rubro salarial
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Detalles adicionales del rubro salarial
        /// </summary>
        public string Detalles { get; set; }

        /// <summary>
        /// Usuario que registró el rubro salarial
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro
        /// </summary>
        public string FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó por última vez el rubro salarial
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public string FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Institución asociada al rubro salarial
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        #endregion
    }
}

