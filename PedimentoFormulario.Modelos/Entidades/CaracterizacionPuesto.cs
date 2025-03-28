using System;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa la caracterización de un puesto asociado a un pedimento
    /// </summary>
    public class CaracterizacionPuesto
    {
        /// <summary>
        /// Código del pedimento al que pertenece esta caracterización
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código del factor de caracterización
        /// </summary>
        public decimal CodFactor { get; set; }

        /// <summary>
        /// Valor de la escala asignada a este factor
        /// </summary>
        public decimal Escala { get; set; }

        /// <summary>
        /// Usuario que registró la caracterización
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la caracterización
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó por última vez la caracterización
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public DateTime FechaMod { get; set; }

        // Propiedades de navegación
        public virtual FactorCaracterizacionPuesto Factor { get; set; }
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }
    }
}

