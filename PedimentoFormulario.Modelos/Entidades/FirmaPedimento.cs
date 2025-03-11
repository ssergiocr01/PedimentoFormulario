using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_firmas_pedimento")]
    public class FirmaPedimento
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(15)]
        public string Pedimento { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [StringLength(20)]
        public string CodFirma { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric(1,0)")]
        [Required]
        public decimal TipoFirma { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public string Observaciones { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioReg { get; set; }

        [Required]
        public DateTime FechaReg { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioMod { get; set; }

        [Required]
        public DateTime FechaMod { get; set; }

        // Propiedad de navegación
        [ForeignKey("Pedimento")]
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }
    }
}