using SAGTHE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_DGSC_departamentos")]
    public class Departamento
    {
        [Key]
        [Column(Order = 1, TypeName = "numeric(6,0)")]
        [Required]
        public decimal CodDepartamento { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric(3,0)")]
        [Required]
        public decimal CodInstitucion { get; set; }

        [Required]
        [StringLength(75)]
        [Column("departamento")]
        public string NombreDepartamento { get; set; }

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