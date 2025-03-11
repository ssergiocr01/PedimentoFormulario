using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_clasificacion_especialidades")]
    public class Especialidad
    {
        public Especialidad()
        {
            SubEspecialidades = new HashSet<SubEspecialidad>();
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(3,0)")]
        public decimal CodEspecialidad { get; set; }

        [Required]
        [StringLength(150)]
        public string NombreEspecialidad { get; set; }

        [StringLength(512)]
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
        public string FechaGaceta { get; set; }

        [StringLength(250)]
        public string VinculoDocPfd { get; set; }

        public bool? Activo { get; set; }

        [StringLength(20)]
        public string UsuarioReg { get; set; }

        public DateTime? FechaReg { get; set; }

        [Required]
        [StringLength(20)]
        public string UsuarioMod { get; set; }

        public DateTime? FechaMod { get; set; }

        [StringLength(500)]
        public string Observ { get; set; }

        // Propiedades de navegación
        public virtual ICollection<SubEspecialidad> SubEspecialidades { get; set; }
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}