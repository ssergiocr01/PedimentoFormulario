using SAGTHE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_DGSC_dependencias")]
    public class Dependencia
    {
        [Key]
        [Column(Order = 1, TypeName = "numeric(4,0)")]
        [Required]
        public decimal CodDependencia { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric(3,0)")]
        [Required]
        public decimal CodInstitucion { get; set; }

        [Required]
        [StringLength(255)]
        [Column("dependencia")]
        public string NombreDependencia { get; set; }

        [StringLength(3000)]
        public string Detalles { get; set; }

        [Required]
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
        [ForeignKey("CodInstitucion")]
        public virtual Institucion Institucion { get; set; }

        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}