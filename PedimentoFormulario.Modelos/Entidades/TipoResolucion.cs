using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_RyS_tipos_resolucion_pedimentos")]
    public class TipoResolucion
    {
        public TipoResolucion()
        {
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodTipoResolucion { get; set; }

        [Required]
        [StringLength(75)]
        [Column("tipo_resolucion")]
        public string NombreTipoResolucion { get; set; }

        [Required]
        public bool Activo { get; set; }

        [StringLength(20)]
        public string UsuarioReg { get; set; }

        public DateTime? FechaReg { get; set; }

        [StringLength(20)]
        public string UsuarioMod { get; set; }

        public DateTime? FechaMod { get; set; }

        // Propiedad de navegación
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}