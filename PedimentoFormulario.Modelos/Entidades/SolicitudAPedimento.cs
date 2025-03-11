using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_solicitud_a_pedimento")]
    public class SolicitudAPedimento
    {
        [Key]
        [Column(Order = 1, TypeName = "numeric(10,0)")]
        [Required]
        public decimal NumSolicitud { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [StringLength(15)]
        public string Pedimento { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric(18,0)")]
        [Required]
        public decimal CodInstitucion { get; set; }

        [Required]
        [Column(TypeName = "numeric(18,0)")]
        public decimal CodTipoSolicitud { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodMotivo { get; set; }

        [Required]
        public string Justificacion { get; set; }

        public byte[] Anexo { get; set; }

        public DateTime? FechaFin { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioReg { get; set; }

        [Required]
        public DateTime FechaReg { get; set; }

        [StringLength(20)]
        public string UsuarioMod { get; set; }

        [Required]
        [Column(TypeName = "numeric(18,0)")]
        public decimal CodEstado { get; set; }

        public DateTime? FechaMod { get; set; }

        // Propiedades de navegación
        [ForeignKey("Pedimento")]
        public virtual SolicitudPedimentoPersonal SolicitudPedimento { get; set; }

        [ForeignKey("CodInstitucion")]
        public virtual Institucion Institucion { get; set; }

        [ForeignKey("CodMotivo")]
        public virtual MotivoVacante MotivoVacante { get; set; }
    }
}