using System;

namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para firmas de pedimentos
    /// </summary>
    public class FirmaPedimentoDto
    {
        /// <summary>
        /// Pedimento asociado
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
        /// Observaciones de la firma
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
    }
}

