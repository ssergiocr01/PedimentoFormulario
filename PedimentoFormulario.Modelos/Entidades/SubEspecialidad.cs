using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_clasificacion_sub_especialidad")]
    public class SubEspecialidad
    {
        public SubEspecialidad()
        {
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Column(Order = 1, TypeName = "numeric(3,0)")]
        [Required]
        public decimal CodSubEspecialidad { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric(3,0)")]
        [Required]
        public decimal CodEspecialidad { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreSubespecialidad { get; set; }

        [StringLength(350)]
        public string Observaciones { get; set; }

        [Required]
        [StringLength(30)]
        public string Resolucion { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaRes { get; set; }

        [Required]
        [StringLength(150)]
        public string Gaceta { get; set; }

        [Required]
        [StringLength(10)]
        [Column("fehca_gaceta")] // Nota: hay un error de ortografía en el nombre de la columna
        public string FechaGaceta { get; set; }

        [StringLength(500)]
        public string VinculoDocPfd { get; set; }

        public bool? Activo { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioReg { get; set; }

        public DateTime? FechaReg { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioMod { get; set; }

        public DateTime? FechaMod { get; set; }

        [StringLength(500)]
        public string Nota { get; set; }

        // Propiedades de navegación
        [ForeignKey("CodEspecialidad")]
        public virtual Especialidad Especialidad { get; set; }

        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}