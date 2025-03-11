using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_clasificacion_cargos")]
    public class Cargo
    {
        public Cargo()
        {
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(5,0)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CodCargo { get; set; }

        [Required]
        [Column(TypeName = "numeric(4,0)")]
        public decimal CodManual { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodInstitucion { get; set; }

        [Required]
        [StringLength(15)]
        public string CodClase { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreCargo { get; set; }

        [StringLength(100)]
        public string VinculoDocPdf { get; set; }

        [Required]
        [Column("estado")]
        public bool Activo { get; set; }

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

        // Propiedades de navegación
        [ForeignKey("CodClase")]
        public virtual Clase Clase { get; set; } // Cambiado de ClaseClasificacion a Clase

        [ForeignKey("CodInstitucion")]
        public virtual Institucion Institucion { get; set; }

        // Nota: Falta la relación con SAGTHE_clasificacion_manuales_de_cargos
        // [ForeignKey("CodManual,CodInstitucion")]
        // public virtual ManualCargo ManualCargo { get; set; }

        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}