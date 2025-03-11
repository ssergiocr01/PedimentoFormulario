using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedimentoFormulario.Modelos.Entidades
{
    [Table("SAGTHE_DGSC_provincias")]
    public class Provincia
    {
        public Provincia()
        {
            Cantones = new HashSet<Canton>();
            SolicitudesPedimento = new HashSet<SolicitudPedimentoPersonal>();
        }

        [Key]
        [Required]
        [Column(TypeName = "numeric(2,0)")]
        public decimal CodProvincia { get; set; }

        [Required]
        [StringLength(35)]
        [Column("provincia")]
        public string NombreProvincia { get; set; }

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
        public virtual ICollection<Canton> Cantones { get; set; }
        public virtual ICollection<SolicitudPedimentoPersonal> SolicitudesPedimento { get; set; }
    }
}