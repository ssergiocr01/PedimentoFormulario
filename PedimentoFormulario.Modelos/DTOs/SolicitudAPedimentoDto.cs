using System;

namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para solicitudes a pedimentos
    /// </summary>
    public class SolicitudAPedimentoDto
    {
        /// <summary>
        /// Número de la solicitud
        /// </summary>
        public decimal NumSolicitud { get; set; }

        /// <summary>
        /// Pedimento asociado
        /// </summary>
        public string Pedimento { get; set; }

        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Nombre de la institución
        /// </summary>
        public string NombreInstitucion { get; set; }

        /// <summary>
        /// Código del tipo de solicitud
        /// </summary>
        public decimal CodTipoSolicitud { get; set; }

        /// <summary>
        /// Código del motivo
        /// </summary>
        public decimal CodMotivo { get; set; }

        /// <summary>
        /// Nombre del motivo
        /// </summary>
        public string NombreMotivo { get; set; }

        /// <summary>
        /// Justificación de la solicitud
        /// </summary>
        public string Justificacion { get; set; }

        /// <summary>
        /// Anexo de la solicitud
        /// </summary>
        public byte[] Anexo { get; set; }

        /// <summary>
        /// Fecha de finalización
        /// </summary>
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// Usuario que registró la solicitud
        /// </summary>
        public string UsuarioReg { get; set; }

        /// <summary>
        /// Fecha de registro de la solicitud
        /// </summary>
        public DateTime FechaReg { get; set; }

        /// <summary>
        /// Usuario que modificó la solicitud
        /// </summary>
        public string UsuarioMod { get; set; }

        /// <summary>
        /// Fecha de modificación de la solicitud
        /// </summary>
        public DateTime? FechaMod { get; set; }

        /// <summary>
        /// Código del estado
        /// </summary>
        public decimal CodEstado { get; set; }

        /// <summary>
        /// Nombre del estado
        /// </summary>
        public string NombreEstado { get; set; }
    }
}

