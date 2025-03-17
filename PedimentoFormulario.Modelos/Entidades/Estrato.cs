using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa un estrato en el sistema de clasificación
    /// </summary>
    public class Estrato
    {
        /// <summary>
        /// Código del estrato
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Nombre del estrato
        /// </summary>
        public string NombreEstrato { get; set; }

        /// <summary>
        /// Descripción del estrato
        /// </summary>
        public string DescEstratos { get; set; }

        /// <summary>
        /// Resolución que establece el estrato
        /// </summary>
        public string Resolucion { get; set; }

        /// <summary>
        /// Fecha de la resolución
        /// </summary>
        public DateTime? FechaRes { get; set; }

        /// <summary>
        /// Gaceta donde se publicó la resolución
        /// </summary>
        public string Gaceta { get; set; }

        /// <summary>
        /// Fecha de la gaceta
        /// </summary>
        public DateTime FechaGaceta { get; set; }

        /// <summary>
        /// Vínculo al documento PDF
        /// </summary>
        public string VinculoDocPfd { get; set; }

        /// <summary>
        /// Indica si el estrato está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró el estrato
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro del estrato
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó el estrato
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación del estrato
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Clases genéricas que pertenecen a este estrato
        /// </summary>
        public virtual ICollection<ClaseGenerica> ClasesGenericas { get; set; } = new List<ClaseGenerica>();

        /// <summary>
        /// Solicitudes de pedimento asociadas a este estrato
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

