using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_DGSC_distritos")]
    public class Distrito
    {
        public Distrito()
        {
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Column(Order = 1, TypeName = "numeric(3,0)")]
        [Required]
        public decimal CodDistrito { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric(3,0)")]
        [Required]
        public decimal CodCanton { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric(2,0)")]
        [Required]
        public decimal CodProvincia { get; set; }

        [Required]
        [StringLength(100)]
        [Column("distrito")]
        public string NombreDistrito { get; set; }

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
        [ForeignKey("CodCanton,CodProvincia")]
        public virtual Canton Canton { get; set; }

        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}