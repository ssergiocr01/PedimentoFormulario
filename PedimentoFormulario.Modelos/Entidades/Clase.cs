using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_clasificacion_clase")]
    public class Clase
    {
        public Clase()
        {
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
            Cargos = new HashSet<Cargo>();
        }

        [Key]
        [Required]
        [StringLength(15)]
        public string CodClase { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodEstrato { get; set; }

        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodClaseGen { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodClasIa { get; set; }

        [Required]
        [Column(TypeName = "numeric(18,0)")]
        public decimal Grupo { get; set; }

        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodInstitucion { get; set; }

        [Required]
        [StringLength(100)]
        public string TituloDeLaClase { get; set; }

        [Column(TypeName = "numeric(3,0)")]
        public decimal? NivelSalarial { get; set; }

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
        public string FechaGaceta { get; set; }

        [StringLength(250)]
        public string VinculoDocPdf { get; set; }

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
        [ForeignKey("CodEstrato,CodClaseGen")]
        public virtual ClaseGenerica ClaseGenerica { get; set; }

        [ForeignKey("CodInstitucion")]
        public virtual Institucion Institucion { get; set; }

        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}