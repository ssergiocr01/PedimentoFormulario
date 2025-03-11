using System.ComponentModel.DataAnnotations;

namespace PedimentoFormulario.Modelos.DTOs
{
    public class TareaPuestoDto
    {
        [Required]
        [StringLength(15)]
        public string Pedimento { get; set; }

        public decimal CodTarea { get; set; }

        [Required]
        public string Tarea { get; set; }

        [Required]
        public string DetalleTarea { get; set; }

        [Required]
        [StringLength(1)]
        public string Frecuencia { get; set; }
    }
}