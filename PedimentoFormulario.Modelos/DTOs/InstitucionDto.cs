using System.ComponentModel.DataAnnotations;

namespace PedimentoFormulario.Modelos.DTOs
{
    /// <summary>
    /// DTO para instituciones
    /// </summary>
    public class InstitucionDto
    {
        /// <summary>
        /// Código de la institución
        /// </summary>
        public decimal CodInstitucion { get; set; }

        /// <summary>
        /// Nombre de la institución
        /// </summary>
        public string NombreInstitucion { get; set; }

        /// <summary>
        /// Sigla de la institución
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// Indica si la institución está activa
        /// </summary>
        public bool Activo { get; set; }
    }
}

