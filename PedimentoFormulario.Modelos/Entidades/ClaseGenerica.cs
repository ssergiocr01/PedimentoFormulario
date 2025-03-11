using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_clasificacion_clase_generica")]
    public class ClaseGenerica
    {
        public ClaseGenerica()
        {
            Clases = new HashSet<Clase>(); // Cambiado de ClasesClasificacion a Clases
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Column(Order = 1, TypeName = "numeric(2,0)")]
        [Required]
        public decimal CodClaseGen { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric(2,0)")]
        [Required]
        public decimal CodEstrato { get; set; }

        [StringLength(100)]
        public string NombreGenerica { get; set; }

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

        [StringLength(200)]
        public string VinculoDocPfd { get; set; }

        public bool? Activo { get; set; }

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
        [ForeignKey("CodEstrato")]
        public virtual Estrato Estrato { get; set; }

        public virtual ICollection<Clase> Clases { get; set; } // Cambiado de ClasesClasificacion a Clases
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}