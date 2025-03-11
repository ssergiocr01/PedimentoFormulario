using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_clasificacion_estratos")]
    public class Estrato
    {
        public Estrato()
        {
            ClasesGenericas = new HashSet<ClaseGenerica>();
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodEstrato { get; set; }

        [StringLength(100)]
        public string NombreEstrato { get; set; }

        [StringLength(600)]
        public string DescEstratos { get; set; }

        [Required]
        [StringLength(30)]
        public string Resolucion { get; set; }

        public DateTime? FechaRes { get; set; }

        [Required]
        [StringLength(150)]
        public string Gaceta { get; set; }

        [Required]
        public DateTime FechaGaceta { get; set; }

        [StringLength(200)]
        public string VinculoDocPfd { get; set; }

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
        public virtual ICollection<ClaseGenerica> ClasesGenericas { get; set; }
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}