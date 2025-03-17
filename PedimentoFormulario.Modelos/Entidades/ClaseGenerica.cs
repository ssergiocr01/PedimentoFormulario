using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una clase genérica en el sistema de clasificación
    /// </summary>
    public class ClaseGenerica
    {
        /// <summary>
        /// Código del estrato al que pertenece la clase genérica
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Código de la clase genérica
        /// </summary>
        public decimal CodClaseGen { get; set; }

        /// <summary>
        /// Nombre de la clase genérica
        /// </summary>
        public string NombreGenerica { get; set; }

        /// <summary>
        /// Resolución que establece la clase genérica
        /// </summary>
        public string Resolucion { get; set; }

        /// <summary>
        /// Fecha de la resolución
        /// </summary>
        public string FechaRes { get; set; }

        /// <summary>
        /// Gaceta donde se publicó la resolución
        /// </summary>
        public string Gaceta { get; set; }

        /// <summary>
        /// Fecha de la gaceta
        /// </summary>
        public string FechaGaceta { get; set; }

        /// <summary>
        /// Vínculo al documento PDF
        /// </summary>
        public string VinculoDocPfd { get; set; }

        /// <summary>
        /// Indica si la clase genérica está activa
        /// </summary>
        public bool? Activo { get; set; }

        /// <summary>
        /// Usuario que registró la clase genérica
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la clase genérica
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la clase genérica
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la clase genérica
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Estrato al que pertenece la clase genérica
        /// </summary>
        public virtual Estrato Estrato { get; set; }

        /// <summary>
        /// Clases que pertenecen a esta clase genérica
        /// </summary>
        public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();

        /// <summary>
        /// Solicitudes de pedimento asociadas a esta clase genérica
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

