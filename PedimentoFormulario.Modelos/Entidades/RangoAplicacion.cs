using System;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un rango de aplicación que relaciona clases, especialidades y subespecialidades
    /// </summary>
    public class RangoAplicacion
    {
        /// <summary>
        /// Código de la clase
        /// </summary>
        public string CodClase { get; set; }

        /// <summary>
        /// Código de la especialidad
        /// </summary>
        public decimal CodEspecialidad { get; set; }

        /// <summary>
        /// Código de la subespecialidad
        /// </summary>
        public decimal CodSubEspecialidad { get; set; }

        /// <summary>
        /// Descripción del rango de aplicación
        /// </summary>
        public string Rango { get; set; }

        /// <summary>
        /// Número de gaceta
        /// </summary>
        public string Gaceta { get; set; }

        /// <summary>
        /// Fecha de publicación en gaceta
        /// </summary>
        public DateTime FGaceta { get; set; }

        /// <summary>
        /// Número de resolución
        /// </summary>
        public string Resolucion { get; set; }

        /// <summary>
        /// Fecha de resolución
        /// </summary>
        public DateTime FRes { get; set; }

        /// <summary>
        /// Usuario que registró el rango de aplicación
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó por última vez el rango de aplicación
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Clase asociada al rango de aplicación
        /// </summary>
        public virtual Clase Clase { get; set; }

        /// <summary>
        /// Especialidad asociada al rango de aplicación
        /// </summary>
        public virtual Especialidad Especialidad { get; set; }

        /// <summary>
        /// Subespecialidad asociada al rango de aplicación
        /// </summary>
        public virtual SubEspecialidad SubEspecialidad { get; set; }

        #endregion
    }
}

