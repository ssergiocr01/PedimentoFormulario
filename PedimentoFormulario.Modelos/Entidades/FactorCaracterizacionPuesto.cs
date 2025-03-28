using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un factor para la caracterización de puestos
    /// </summary>
    public class FactorCaracterizacionPuesto
    {
        public FactorCaracterizacionPuesto()
        {
            Caracterizaciones = new HashSet<CaracterizacionPuesto>();
        }

        /// <summary>
        /// Código único del factor
        /// </summary>
        public decimal CodFactor { get; set; }

        /// <summary>
        /// Nombre o descripción del factor
        /// </summary>
        public string Factor { get; set; }

        /// <summary>
        /// Valor mínimo de la escala para este factor
        /// </summary>
        public decimal EscalaMinima { get; set; }

        /// <summary>
        /// Valor máximo de la escala para este factor
        /// </summary>
        public decimal EscalaMaxima { get; set; }

        /// <summary>
        /// Código del factor superior (si es un subfactor)
        /// </summary>
        public decimal? CodFactorSup { get; set; }

        /// <summary>
        /// Nivel jerárquico del factor
        /// </summary>
        public decimal Nivel { get; set; }

        /// <summary>
        /// Valor para el nivel 1
        /// </summary>
        public string N1 { get; set; }

        /// <summary>
        /// Valor para el nivel 2
        /// </summary>
        public string N2 { get; set; }

        /// <summary>
        /// Valor para el nivel 3
        /// </summary>
        public string N3 { get; set; }

        /// <summary>
        /// Valor para el nivel 4
        /// </summary>
        public string N4 { get; set; }

        /// <summary>
        /// Indica si el factor está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el factor
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del factor
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó por última vez el factor
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public DateTime FechaMod { get; set; }

        // Propiedades de navegación
        public virtual ICollection<CaracterizacionPuesto> Caracterizaciones { get; set; }
    }
}

