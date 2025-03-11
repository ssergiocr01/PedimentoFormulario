using System.ComponentModel.DataAnnotations;

namespace PedimentoFormulario.Modelos.DTOs
{
    public class FirmaPedimentoDto
    {
        [Required]
        [StringLength(15)]
        public string Pedimento { get; set; }

        [Required]
        [StringLength(20)]
        public string CodFirma { get; set; }

        [Required]
        public decimal TipoFirma { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public string Observaciones { get; set; }
    }
}