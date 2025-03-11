using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_tareas_puesto")]
    public class TareaPuesto
    {
        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(15)]
        public string Pedimento { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric(18,0)")]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CodTarea { get; set; }

        [Required]
        public string Tarea { get; set; }

        [Required]
        [Column("detalle_tarea")]
        public string DetalleTarea { get; set; }

        [Required]
        [StringLength(1)]
        public string Frecuencia { get; set; }

        [StringLength(20)]
        public string UsuarioReg { get; set; }

        public DateTime? FechaReg { get; set; }

        [StringLength(20)]
        public string UsuarioMod { get; set; }

        public DateTime? FechaMod { get; set; }

        // Propiedad de navegación
        [ForeignKey("Pedimento")]
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }
    }
}