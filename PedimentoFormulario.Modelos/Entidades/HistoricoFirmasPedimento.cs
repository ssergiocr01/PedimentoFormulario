using System;

namespace PedimentoFormulario.Modelos.Entidades
{
    /// <summary>
    /// Representa el historial de firmas de un pedimento
    /// </summary>
    public class HistoricoFirmasPedimento
    {
        /// <summary>
        /// Código único del registro histórico
        /// </summary>
        public decimal CodHistorico { get; set; }

        /// <summary>
        /// Código del pedimento
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la firma
        /// </summary>
        public string CodFirma { get; set; }

        /// <summary>
        /// Tipo de firma
        /// </summary>
        public decimal TipoFirma { get; set; }

        /// <summary>
        /// Nombre del firmante
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Observaciones sobre la firma
        /// </summary>
        public string Observaciones { get; set; }

        /// <summary>
        /// Usuario que registró la firma
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la firma
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó por última vez la firma
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de la última modificación
        /// </summary>
        public DateTime FechaMod { get; set; }
    }
}

