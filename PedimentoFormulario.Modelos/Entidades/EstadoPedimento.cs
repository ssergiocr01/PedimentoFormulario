using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_estados_pedimento")]
    public class EstadoPedimento
    {
        [Key]
        [Column(Order = 1, TypeName = "numeric(10,0)")]
        [Required]
        public decimal NumEstado { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric(2,0)")]
        [Required]
        public decimal CodEstado { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric(15,0)")]
        [Required]
        public string Pedimento { get; set; }

        [StringLength(3000)]
        public string Observaciones { get; set; }

        [StringLength(512)]
        public string Anexo { get; set; }

        public bool? Activo { get; set; }

        public DateTime? FechaRige { get; set; }

        public DateTime? FechaVence { get; set; }

        [StringLength(20)]
        public string UsuarioReg { get; set; }

        public DateTime? FechaReg { get; set; }

        [StringLength(20)]
        public string UsuarioMod { get; set; }

        public DateTime? FechaMod { get; set; }

        // Propiedades de navegación
        [ForeignKey("CodEstado")]
        public virtual EstadoParaPedimento EstadoParaPedimento { get; set; }

        [ForeignKey("Pedimento")]
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }
    }
}