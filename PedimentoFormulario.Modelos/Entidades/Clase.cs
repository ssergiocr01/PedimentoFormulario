using System;
using System.Collections.Generic;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa una clase en el sistema de clasificación
    /// </summary>
    public class Clase
    {
        /// <summary>
        /// Código de la clase
        /// </summary>
        public string CodClase { get; set; }

        /// <summary>
        /// Código del estrato al que pertenece la clase
        /// </summary>
        public decimal CodEstrato { get; set; }

        /// <summary>
        /// Código de la clase genérica a la que pertenece la clase
        /// </summary>
        public decimal CodClaseGen { get; set; }

        /// <summary>
        /// Código de la clase en el sistema IA
        /// </summary>
        public decimal CodClasIa { get; set; }

        /// <summary>
        /// Grupo al que pertenece la clase
        /// </summary>
        public decimal Grupo { get; set; }

        /// <summary>
        /// Código de la institución a la que pertenece la clase
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Título de la clase
        /// </summary>
        public string TituloDeLaClase { get; set; }

        /// <summary>
        /// Nivel salarial de la clase
        /// </summary>
        public decimal? NivelSalarial { get; set; }

        /// <summary>
        /// Resolución que establece la clase
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
        public string VinculoDocPdf { get; set; }

        /// <summary>
        /// Indica si la clase está activa
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Usuario que registró la clase
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la clase
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la clase
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la clase
        /// </summary>
        public DateTime FechaMod { get; set; }

        #region Navegación

        /// <summary>
        /// Clase genérica a la que pertenece la clase
        /// </summary>
        public virtual ClaseGenerica ClaseGenerica { get; set; }

        /// <summary>
        /// Institución a la que pertenece la clase
        /// </summary>
        public virtual Institucion Institucion { get; set; }

        /// <summary>
        /// Cargos asociados a esta clase
        /// </summary>
        public virtual ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();

        /// <summary>
        /// Solicitudes de pedimento asociadas a esta clase
        /// </summary>
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; } = new List<SolicitudPedimentoPersonal>();

        #endregion
    }
}

